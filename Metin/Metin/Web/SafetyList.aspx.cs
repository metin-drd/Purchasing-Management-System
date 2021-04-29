using Metin.Business;
using Metin.Command;
using Metin.Utility;
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
    public partial class SafetyList1 : System.Web.UI.Page
    {
        #region Properties
        BSafety _bSafety = null;
        public BSafety bSafety
        {
            get
            {
                if (_bSafety == null)
                    _bSafety = new BSafety();

                return _bSafety;
            }
        }
        #endregion

        #region General

        public bool is_saved
        {
            get { return bConvert.ToInt32(Request.QueryString["is_saved"]) == (int)bConstants.EvetHayir.Evet ? true : false; }
        }

        public bool is_deleted
        {
            get { return bConvert.ToInt32(Request.QueryString["is_deleted"]) == (int)bConstants.EvetHayir.Evet ? true : false; }
        }

        #endregion

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "";

            if (!IsPostBack)
            {
                GridList();
                rdoVessel.Checked = true;
                bFill.Vessel(ddlVesselDepartment, null, bConstants.FillTypes.Choose);

                if (is_saved)
                {
                    lblMessage.Text = "Your data has been successfully saved.!";
                    lblMessage.ForeColor = Color.Green;
                }

                if (is_deleted)
                {
                    lblMessage.Text = "Your data has been successfully deleted.!";
                    lblMessage.ForeColor = Color.Green;
                }
            }
        }

        #endregion

        #region Other Events

        protected void tgSafety_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView dr = (DataRowView)e.Row.DataItem;
                int is_published = bConvert.ToInt32(dr["is_published"]);
                if (is_published != (int)bConstants.EvetHayir.Evet)
                    e.Row.ForeColor = Color.Red;
           
                DataRowView dr2 = (DataRowView)e.Row.DataItem;
                DateTime deneme = DateTime.Now.AddMonths(-1);
                bool sonuc = deneme < bConvert.ToDateTime(dr2["issued_date"]);

                if (sonuc)
                {
                    e.Row.Font.Bold = true;
                }
            }
        }

        #endregion

        #region Button Events

        protected void imbSearch_Click(object sender, EventArgs e)
        {
            GridList();
        }

        protected void imbClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        protected void rdoVessel_CheckedChanged(object sender, EventArgs e)
        {
            FillDdl();
        }

        protected void rdoDepartment_CheckedChanged(object sender, EventArgs e)
        {
            FillDdl();
        }

        protected void imbNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("Safety.aspx");
        }

        protected void tgSafety_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("Safety.aspx?safety_id=" + bConvert.ToInt32(tgSafety.SelectedValue));
        }

        #endregion

        #region Functions

        public void GridList()
        {
            CSafety SafetyData = new CSafety();

            SafetyData.is_published = cbxIsPublished.Checked ? (short)bConstants.EvetHayir.Evet : (short)bConstants.EvetHayir.Hayir;
            SafetyData.safety_no = txtSafetyNo.Text;
            SafetyData.issued_date = bConvert.ToDateTime(txtIssuedDate.Text);
            if (rdoDepartment.Checked)
                SafetyData.department_id = bConvert.ToInt16(ddlVesselDepartment.SelectedValue);
            else if (rdoVessel.Checked)
            {
                SafetyData.vessel_id = bConvert.ToInt16(ddlVesselDepartment.SelectedValue);
            }

            DataTable dt = bSafety.Search(SafetyData);
            tgSafety.DataSource = dt;
            tgSafety.DataKeyNames = new string[] { "safety_id" };
            tgSafety.SelectedIndex = -1;
            tgSafety.DataBind();

            lblAdet.Text= dt.Rows.Count.ToString();
        }

        public void ClearForm()
        {
            txtIssuedDate.Text = "";
            txtSafetyNo.Text = "";
            ddlVesselDepartment.SelectedIndex = -1;
            cbxIsPublished.Checked = false;
        }

        public void FillDdl()
        {
            if (rdoVessel.Checked)
                bFill.Vessel(ddlVesselDepartment, null, bConstants.FillTypes.Choose);
            else
                bFill.Department(ddlVesselDepartment, null, bConstants.FillTypes.Choose);
        }

        #endregion

    }
}