using Metin.Business;
using Metin.Command;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Metin.Web
{
    public partial class VesselList : System.Web.UI.Page
    {

        #region Properties
        public int VesselID
        {
            get
            {
                return bConvert.ToInt32(ViewState["vessel_id"]);
            }
            set
            {
                ViewState["vessel_id"] = value;
            }
        }
        #endregion

        #region General
        BVessel _bVessel;
        public BVessel bVessel
        {
            get
            {
                if (_bVessel == null)
                    _bVessel = new BVessel();
                return _bVessel;
            }
        }

        #endregion

        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillGrid();
            }
            lblMessage.Text = "";
        }
        #endregion

        #region Grid Events

        #endregion

        #region Button Events

        protected void tgVessel_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "btnDelete")
            {
                int rowIndex = bConvert.ToInt32(e.CommandArgument);
                int selected_vessel_id = bConvert.ToInt32(tgVessel.DataKeys[rowIndex].Values[0]);


                CVessel VesselData = bVessel.BrowseOne(selected_vessel_id);
                if (VesselData == null || VesselData.vessel_id < 1)
                {
                    lblMessage.Text = "Data not found!";
                    lblMessage.ForeColor = Color.Red;
                    return;
                }

                bool sonuc = bVessel.DeletOne(selected_vessel_id);
                if (sonuc)
                {
                    lblMessage.ForeColor = Color.Green;
                    lblMessage.Text = "Your data has been successfully deleted.!";
                    ClearForm();
                }
                else
                {
                    lblMessage.ForeColor = Color.Red;
                    lblMessage.Text = "An error occured while deleting the data!";
                }

            }

        }

        protected void tgVessel_SelectedIndexChanged(object sender, EventArgs e)
        {
            VesselID = bConvert.ToInt32(tgVessel.SelectedValue);

            CVessel VesselData = bVessel.BrowseOne(VesselID);
            if (VesselData == null || VesselData.vessel_id < 1)
            {
                lblMessage.Text = "Data not found!";
                lblMessage.ForeColor = Color.Red;
                VesselID = 0;
                return;
            }

            txtShipName.Text = VesselData.ship_name;
            txtShipAcronymName.Text = VesselData.ship_acronym_name;
            chxIsActive.Checked = bConvert.ToBoolean(VesselData.is_active);
            imbSave.Text = "Save";
        }

        protected void imbSave_Click(object sender, EventArgs e)
        {
            SaveForm();
        }

        protected void imbCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
        }


        #endregion

        #region Functions

        public void FillGrid()
        {
            CVessel VesselData = new CVessel();
            DataTable dt = bVessel.Search(VesselData);
            tgVessel.DataSource = dt;
            tgVessel.DataKeyNames = new string[] { "vessel_id" };
            tgVessel.SelectedIndex = -1;
            tgVessel.DataBind();

        }

        public void SaveForm()
        {

            #region Kontrol
            CVessel VesselData = new CVessel();

            if (VesselID > 0)
            {
                VesselData = bVessel.BrowseOne(VesselID);

                if (VesselData == null || VesselData.vessel_id < 1)
                {
                    lblMessage.Text = "Data not found!";
                    lblMessage.ForeColor = Color.Red;
                    return;
                }
            }
            #endregion

            #region Hazırlık

            VesselData.ship_name = txtShipName.Text;
            VesselData.ship_acronym_name = txtShipAcronymName.Text;
            VesselData.is_active = bConvert.ToInt16(chxIsActive.Checked);

            #endregion

            #region Kaydet

            bool sonuc = false;

            if (VesselID == 0)
                sonuc = bVessel.Insert(VesselData);
            else
                sonuc = bVessel.Update(VesselData);

            if (sonuc)
            {
                lblMessage.Text = "Your data has been successfully saved.!";
                lblMessage.ForeColor = Color.Green;
                ClearForm();
            }
            else
            {
                lblMessage.Text = "An error occured while saving the data!";
                lblMessage.ForeColor = Color.Red;
            }

            #endregion




        }

        public void ClearForm()
        {
            txtShipName.Text = "";
            txtShipAcronymName.Text = "";
            chxIsActive.Checked = false;

            FillGrid();
        }

        #endregion










    }
}