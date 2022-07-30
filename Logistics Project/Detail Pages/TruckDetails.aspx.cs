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
    public partial class TruckDetails : System.Web.UI.Page
    {
        VendorAccess vendorAccess;
        TruckAccess truckAccess;
        protected void Page_Load(object sender, EventArgs e)
        {
            truckAccess = new TruckAccess();
            if(!IsPostBack)
            {
                vendorAccess = new VendorAccess();
                List<Vendor> vendorList = vendorAccess.Get();
                lstVendors.Items.Add("Select Vendor");
                lstVendors.Items.FindByText("Select Vendor").Selected = true;
                lstVendors.Items.FindByText("Select Vendor").Attributes.Add("disabled","disabled");
                foreach(var vendor in vendorList)
                {
                    lstVendors.Items.Add(vendor.vendorName);
                    lstVendors.Items.FindByText(vendor.vendorName).Value = vendor.vendorID.ToString();
                }
                Loader();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Truck truck = new Truck
            {
                truckID = txtname.Text,
                costPerKM = Convert.ToInt32(txtcharges.Text),
                vendorID = Convert.ToInt32(lstVendors.SelectedValue),
                assignedTripID = 0
            };
            try
            {
                truckAccess.Create(truck);
                Loader();
            }
            catch(Exception ex)
            {
                lblstatus.Text = ex.Message;
            }
            
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            txtcharges.Text = String.Empty;
            txtname.Text = String.Empty;
            lstVendors.ClearSelection();
            lstVendors.Items.FindByText("Select Vendor").Selected = true;
        }

        void Loader()
        {
            try
            {
                List<Truck> l = truckAccess.Get();
                details.DataSource = l.Select(o => new
                { ID = o.truckID, VendorID = o.vendorID, CostPerKM = o.costPerKM}).ToList();

                 details.DataBind();
             }
            catch (Exception ex)
            {
                lblstatus.Text = ex.Message;
            }
        }
    }
}