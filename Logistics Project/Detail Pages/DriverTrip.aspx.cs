using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogisticsDataAccess;
using LogisticsEntities;

namespace Logistics_Project.Detail_Pages
{
    public partial class DriverTrip : System.Web.UI.Page
    {
        DestinationAccess destinationAccess;
        DriverAccess driverAccess;
        TripAccess tripAccess;
        TruckAccess truckAccess;
        protected void Page_Load(object sender, EventArgs e)
        {
            destinationAccess = new DestinationAccess();
            driverAccess = new DriverAccess();
            tripAccess = new TripAccess();
            truckAccess = new TruckAccess();
           
            if (!IsPostBack)
            {
                lstname.Items.Add("Select your Details");
                lstname.Items.FindByText("Select your Details").Selected = true;
                //lstname.Items.FindByText("Select your Details").Attributes.Add("disabled", "disabled");
                List<Driver> drives = driverAccess.Get();
                foreach(Driver drive in drives)
                {
                    lstname.Items.Add(drive.driverName + " " + drive.driverID);
                    lstname.Items.FindByText(drive.driverName + " " + drive.driverID).Value = drive.driverID.ToString();
                }
            }
            lstname.Items.FindByText("Select your Details").Attributes.Add("disabled", "disabled");

        }

        protected void txtdate_TextChanged(object sender, EventArgs e)
        {
            int driverID = Convert.ToInt32(lstname.SelectedValue);
            Trip trip = tripAccess.GetOngoingTripusingDriverID(driverID).First();
            string sDate = trip.startDate;
            string d = txtdate.Text.ToString();
            DateTime date = DateTime.Parse(d);
            DateTime startDate = DateTime.Parse(sDate);
            DateTime todaydate = DateTime.Now;
            if (startDate.Date > date.Date)
            {
                lblstatus.Text = "Date invalid!!";
                txtdate.Text = todaydate.ToString();
            } else
            {
                lblstatus.Text = String.Empty;
            }

            return;
        }

        protected void lstname_TextChanged(object sender, EventArgs e)
        {
            Loader();
        }

        private void Loader()
        {
            txtdate.Text = String.Empty;
            txtDis.Text = String.Empty;
            txtExtra.Text = String.Empty;
            txtMaintainece.Text = String.Empty;
            txtToll.Text = String.Empty;
            List<Destination> destinations = destinationAccess.Get();

            DestTable.DataSource = destinations;
            DestTable.DataBind();

            int driverID = Convert.ToInt32(lstname.SelectedValue);
            List<Trip> trips = tripAccess.GetOngoingTripusingDriverID(driverID);
            tripAssigned.DataSource = trips.Select(o => new
            { ID = o.tripID, StartDate = o.startDate, DestinationID = o.destinationID, TruckID = o.truckID,DriverID = o.driverID }).ToList(); ;
            tripAssigned.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string endDate = txtdate.Text;
            int toll = Convert.ToInt32(txtToll.Text);
            int extraDis = Convert.ToInt32(txtDis.Text);
            int mcharges = Convert.ToInt32(txtMaintainece.Text);
            int extraCharges = Convert.ToInt32(txtExtra.Text);
            int driverID = Convert.ToInt32(lstname.SelectedValue);
            Trip trip = tripAccess.GetOngoingTripusingDriverID(driverID).First();
            
            try
            {
               
                tripAccess.UpdateCompleted(trip.tripID, toll, mcharges, extraCharges, extraDis, endDate);
                Trip t = tripAccess.Get(trip.tripID);
                driverAccess.changeStatus(t.driverID, 0);
                truckAccess.changeStatus(t.truckID, 0);
                Loader();

            }
            catch(Exception ex)
            {
                lblstatus.Text = ex.Message;
            }
        }
    }
}