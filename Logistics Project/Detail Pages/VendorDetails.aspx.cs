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
    public partial class VendorDetails : System.Web.UI.Page
    {

        VendorAccess vendorAccess = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            vendorAccess = new VendorAccess();
            if(!IsPostBack)
            {
                Loader();
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Vendor v = new Vendor
            {
                vendorContact = txtcontact.Text,
                vendorName = txtname.Text
            };
            try
            {


                vendorAccess.Create(v);
            }
            catch(Exception ex)
            {
                lblstatus.Text = ex.Message;
            }
                Loader();
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            txtcontact.Text = string.Empty;
            txtname.Text = string.Empty;

        }

        void Loader()
        {
            try
            {
                List<Vendor> vendorList = vendorAccess.Get();
                details.DataSource = vendorList;
                details.DataBind();
            }
            catch(Exception ex)
            {
                lblstatus.Text = ex.Message;
            }
        }
    }
}