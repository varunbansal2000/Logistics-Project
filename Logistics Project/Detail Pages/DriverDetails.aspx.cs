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
    public partial class WebForm1 : System.Web.UI.Page
    {
        DriverAccess driverAccess;
        protected void Page_Load(object sender, EventArgs e)
        {
            driverAccess = new DriverAccess();
            if(!IsPostBack)
            {
                Loader();
                //List<Driver> drivers = driverAccess.Get();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Driver driver = new Driver();
            driver.driverName = txtname.Text;
            driver.driverContact = txtcontact.Text;
            driver.driverCharges = Convert.ToInt32(txtcharges.Text);
            try
            {
                driverAccess.Create(driver);
            } catch (Exception ex)
            {
                lblstatus.Text = ex.Message;
            }
            
            Loader();

        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            txtcharges.Text = String.Empty;
            txtname.Text = String.Empty;
            txtcontact.Text = String.Empty;
        }

        private void Loader()
        {
            try
            {
                details.DataSource = driverAccess.Get().Select(o => new
                {ID = o.driverID, Name = o.driverName, Contact = o.driverContact, CostPerKM = o.driverCharges}).ToList();
                
                details.DataBind();
            }
            catch (Exception ex)
            {
                lblstatus.Text = ex.Message;
            }
        }
    }
}