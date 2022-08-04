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
    public partial class DestinationDetails : System.Web.UI.Page
    {
        DestinationAccess destinationAccess;
        protected void Page_Load(object sender, EventArgs e)
        {
            destinationAccess= new DestinationAccess();
            if (!IsPostBack)
            {
                Loader();
                //List<Driver> drivers = driverAccess.Get();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Destination dest = new Destination();
            dest.destinationCity = txtdstC.Text;
            dest.destinationState = txtdstS.Text;
            dest.distance = Convert.ToInt32(txtDis.Text);
            try
            {
                destinationAccess.Create(dest);
            }
            catch (Exception ex)
            {
                lblstatus.Text = ex.Message;
            }

            Loader();

        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            txtDis.Text = String.Empty;
            txtdstC.Text = String.Empty;
            txtdstS.Text = String.Empty;
        }

        private void Loader()
        {
            try
            {
                details.DataSource = destinationAccess.Get();
                details.DataBind();
            }
            catch (Exception ex)
            {
                lblstatus.Text = ex.Message;
            }
        }
    }
}