using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogisticsEntities;
using LogisticsDataAccess;

namespace Logistics_Project.Detail_Pages
{
    public partial class YSVPortal : System.Web.UI.Page
    {

        TripAccess tripAccess;
        DriverAccess driverAccess;
        TruckAccess truckAccess;
        SummaryAccess summaryAccess;

        protected void Page_Load(object sender, EventArgs e)
        {
            tripAccess = new TripAccess();
            driverAccess = new DriverAccess();
            truckAccess = new TruckAccess();
            summaryAccess = new SummaryAccess();

            if (!IsPostBack)
            {
                lstDriverName.Items.Add("Select Driver");
                lstDriverName.Items.FindByText("Select Driver").Selected = true;
                lstDriverName.Items.FindByText("Select Driver").Attributes.Add("disabled", "disabled");
                lstTrucks.Items.Add("Select Truck");
                lstTrucks.Items.FindByText("Select Truck").Selected = true;
                lstTrucks.Items.FindByText("Select Truck").Attributes.Add("disabled", "disabled");
                lstTripID.Items.Add("Select Trip");
                lstTripID.Items.FindByText("Select Trip").Selected = true;
                lstTripID.Items.FindByText("Select Trip").Attributes.Add("disabled", "disabled");
                List<Driver> freeDrivers = driverAccess.GetFreeDrivers();
                foreach (Driver driver in freeDrivers)
                {
                    lstDriverName.Items.Add(driver.driverName + " " + driver.driverID);
                    lstDriverName.Items.FindByText(driver.driverName + " " + driver.driverID).Value = driver.driverID.ToString();
                }

                List<Truck> freeTrucks = truckAccess.GetFreeTrucks();
                foreach (Truck truck in freeTrucks)
                {
                    lstTrucks.Items.Add(truck.truckID + " " + truck.costPerKM);
                    lstTrucks.Items.FindByText(truck.truckID + " " + truck.costPerKM).Value = truck.truckID;
                }

                List<Trip> trips = tripAccess.GetNewTrips();
                foreach (Trip trip in trips)
                {
                    lstTripID.Items.Add(trip.tripID.ToString());
                    lstTripID.Items.FindByText(trip.tripID.ToString()).Value = trip.tripID.ToString();
                }
               
            }
            //lstTripID.Items.Clear();
            //lstDriverName.Items.Clear();
            //lstTrucks.Items.Clear();

            Loader();

        }



        private void Loader()
        {
            try
            {

                List<Trip> t = tripAccess.GetNewTrips();
                Gridtrips.DataSource = t.Select(o => new
                { ID = o.tripID, StartDate = o.startDate, DestinationID = o.destinationID }).ToList();

                Gridtrips.DataBind();

                GridDrivers.DataSource = driverAccess.GetFreeDrivers();
                GridDrivers.DataBind();

                GridTrucks.DataSource = truckAccess.GetFreeTrucks();
                GridTrucks.DataBind();

                summary.DataSource = summaryAccess.Get();
                summary.DataBind();
            }
            catch (Exception ex)
            {
                lblstatus.Text = ex.Message;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            string truckID = lstTrucks.SelectedValue;
            int driverID = Convert.ToInt32(lstDriverName.SelectedValue);
            int tripID = Convert.ToInt32(lstTripID.SelectedValue);
            try {

                tripAccess.update(tripID, truckID, driverID);
                driverAccess.changeStatus(driverID, tripID);
                truckAccess.changeStatus(truckID, tripID);
                lstDriverName.Items.Remove(lstDriverName.SelectedItem);
                lstTrucks.Items.Remove(lstTrucks.SelectedItem);
                lstTripID.Items.Remove(lstTripID.SelectedItem);
                Loader();
            } catch(Exception ex)
            {
                lblstatus.Text = ex.Message;
            }
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            lstDriverName.ClearSelection();
            lstDriverName.Items.FindByText("Select Driver").Selected = true;
            lstTripID.ClearSelection();
            lstTripID.Items.FindByText("Select Trip").Selected = true;
            lstTrucks.ClearSelection();
            lstTrucks.Items.FindByText("Select Truck").Selected = true;
        }
    }
}