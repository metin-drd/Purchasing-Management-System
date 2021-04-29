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
    public partial class EmissionList : BaseWeb
    {
        #region Properties
        public int emission_id
        {
            get { return bConvert.ToInt32(ViewState["emission_id"]); }
            set { ViewState["emission_id"] = value; }
        }
        #endregion

        #region General
        BEmission _bEmission = null;
        BEmission bEmission
        {
            get
            {
                if (_bEmission == null)
                    _bEmission = new BEmission();

                return _bEmission;
            }
        }
        #endregion

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bFill.Vessel(ddlVessel, null, bConstants.FillTypes.All);
                GridList();
            }
        }
        #endregion

        #region Other Events
        
        #endregion

        #region Button Events

        protected void imbSearch_Click(object sender, EventArgs e)
        {

        }

        protected void imbClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        protected void imbNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("Emission.aspx");
        }


        #endregion

        #region Function
        
        public void GridList()
        {
            CEmission EmissionData = new CEmission();
            EmissionData.vessel_id =bConvert.ToInt32( ddlVessel.SelectedValue);
            EmissionData.start_date = dpStartDate.SelectedDate;
            EmissionData.end_date = dpEndDate.SelectedDate;

            DataTable dt = bEmission.Search(EmissionData);
            tgEmission.DataSource = dt;
            tgEmission.DataKeyNames= new string[] {"emission_id"};
            tgEmission.SelectedIndex = -1;
            tgEmission.DataBind();

        }

        public void ClearForm()
        {
            ddlVessel.SelectedIndex = -1;
            dpStartDate.Clear();
            dpEndDate.Clear();
        }

        #endregion

    
   

     

      

        
    }
}