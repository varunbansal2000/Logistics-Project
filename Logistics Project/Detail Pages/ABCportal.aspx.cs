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
    public partial class ABCportal : System.Web.UI.Page
    {
        DestinationAccess destinationAccess;
        TripAccess tripAccess;
        protected void Page_Load(object sender, EventArgs e)
        {
            destinationAccess = new DestinationAccess();
            tripAccess = new TripAccess();
            if(!IsPostBack)
            {
                List<Destination> destinations = destinationAccess.Get();
                lstDest.Items.Add("Select Destination");
                lstDest.Items.FindByText("Select Destination").Selected = true;
                lstDest.Items.FindByText("Select Destination").Attributes.Add("disabled", "disabled");
                foreach (var dest in destinations)
                {
                    lstDest.Items.Add(dest.destinationState + " " + dest.destinationCity + " " + dest.distance);
                    lstDest.Items.FindByText(dest.destinationState + " " + dest.destinationCity + " " + dest.distance).Value = dest.destinationID.ToString();
                }
                Loader();
                List<Destination> l = destinationAccess.Get();
                DestDetails.DataSource = l;
                DestDetails.DataBind();
            }
        }

        protected void txtdate_TextChanged(object sender, EventArgs e)
        {
            string d = txtdate.Text.ToString();
            DateTime date = DateTime.Parse(d);
            DateTime todaydate = DateTime.Now;
            if(todaydate.Date > date.Date)
            {
                lblstatus.Text = "Date invalid!!";
                txtdate.Text = todaydate.ToString();
            }
            
            return;

        }
        private void Loader()
        {
            try 
            { 

                 List<Trip> t = tripAccess.GetNewTrips();
                details.DataSource = t.Select(o => new
                { ID = o.tripID, StartDate = o.startDate, DestinationID = o.destinationID}).ToList();

                 details.DataBind();
             }
            catch (Exception ex)
            {
                lblstatus.Text = ex.Message;
            }

}

        protected void btnNew_Click(object sender, EventArgs e)
        {
            txtdate.Text = String.Empty;
            lstDest.ClearSelection();
            lstDest.Items.FindByText("Select Destination").Selected = true;

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                String date = txtdate.Text.ToString();
                int destID = Convert.ToInt32(lstDest.SelectedValue);
                Trip t = new Trip()
                {
                    startDate = date,
                    destinationID = destID
                };
                tripAccess.CreateforABC(t);
                Loader();
            }
            catch(Exception ex)
            {
                lblstatus.Text = ex.Message;
            }
        }
    }
}