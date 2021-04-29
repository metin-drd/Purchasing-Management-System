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
    public partial class RequisitionReport : System.Web.UI.Page
    {

        #region Properties
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
                bFill.Fill_SabitDeger(ddlDepartmentCategory,bConstants.SabitDegerTipi.ReportType, bConstants.FillTypes.Choose);
            }
        }
        #endregion

        #region Grid Events
        #endregion

        #region Button Events
        protected void imbReport_Click(object sender, EventArgs e)
        {
            GridList();
        }
        #endregion

        #region Functions

        public void GridList()
        {
            CRequisition RequisitionData = new CRequisition();

            RequisitionData.start_date = dpStartDate.SelectedDate;
            RequisitionData.end_date = dpEndDate.SelectedDate;
            RequisitionData.report_type =bConvert.ToInt32(ddlDepartmentCategory.SelectedValue);

            DataTable dt = bRequisition.Report(RequisitionData);

            tgRequisitionReport.DataSource = dt;
            tgRequisitionReport.SelectedIndex = -1;
            tgRequisitionReport.DataBind();

            
        }
        #endregion


      

      
    }
}