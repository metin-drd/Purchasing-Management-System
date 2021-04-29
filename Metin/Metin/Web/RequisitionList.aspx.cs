using Metin.Business;
using Metin.Command;
using Metin.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Metin.Web
{
    public partial class RequisitionList : BaseWeb
    {
        #region Properties
        private int requisition_id
        {
            get
            {
                return bConvert.ToInt32(ViewState["requisition_id"]);
            }
            set
            {
                ViewState["requisition_id"] = value;
            }
        }
        #endregion

        #region General
        BRequisition _bRequisition = null;
        public BRequisition bRequisition
        {
            get
            {
                if (_bRequisition == null)
                    _bRequisition = new BRequisition();

                return _bRequisition;
            }
        }
        #endregion

        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridList();
                bFill.Fill_SabitDeger(ddlStatus, bConstants.SabitDegerTipi.RequisitionStatus, bConstants.FillTypes.All);
                bFill.Department(ddlDepartment, null, bConstants.FillTypes.All);
            }
        }
        #endregion

        #region Grid Events
        protected void tgRequisition_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("Requisition.aspx?requisition_id=" + bConvert.ToString(tgRequisition.SelectedValue));
        }
        protected void tgRequisition_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "btnDocumentComment")
            {
                int rowIndex = bConvert.ToInt32(e.CommandArgument);
                string document_location = bConvert.ToString(tgRequisition.DataKeys[rowIndex].Values["document_location"]);

                if (!string.IsNullOrEmpty(document_location))
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('../Web/Files/" + document_location + "', '_newtab');", true);
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
            FormClear();
        }

        protected void imbNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("Requisition.aspx");
        }
        #endregion

        #region Other Events
        #endregion

        #region Functions
        public void GridList()
        {
            CRequisition RequisitionData = new CRequisition();
            RequisitionData.status = bConvert.ToInt16(ddlStatus.SelectedValue);
            RequisitionData.start_date = dpStartDate.SelectedDate;
            RequisitionData.end_date = dpEndDate.SelectedDate;


            if (KullaniciRol.Purchase || KullaniciRol.FleetManager)
                RequisitionData.responsible_department_id = bConvert.ToInt32(ddlDepartment.SelectedValue);
            else
            {
                RequisitionData.responsible_department_id = Kullanici.department_id;
                ddlDepartment.SelectedValue = bConvert.ToString(Kullanici.department_id);
                ddlDepartment.Enabled = false;
            }


            DataTable dt = bRequisition.Search(RequisitionData);
            tgRequisition.DataSource = dt;
            tgRequisition.DataKeyNames = new string[] { "requisition_id" };
            tgRequisition.SelectedIndex = -1;
            tgRequisition.DataBind();
        }

        public void FormClear()
        {
            lblMessage.Text = "";
            ddlStatus.SelectedIndex = -1;
            dpStartDate.SelectedDate = DateTime.MinValue;
            dpEndDate.SelectedValue = DateTime.MinValue;
            ddlDepartment.SelectedIndex = -1;

            GridList();

        }

        #endregion




    }
}