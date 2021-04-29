using Metin.Business;
using Metin.Command;
using Metin.Utility;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Metin.Web
{
    public partial class Personnel : BaseWeb
    {
        #region General
        BPersonnel _bPersonnel = null;
        BPersonnel bPersonnel
        {
            get
            {
                if (_bPersonnel == null)
                    _bPersonnel = new BPersonnel();

                return _bPersonnel;
            }
        }
        #endregion

        #region Properties
        private int personnel_id
        {
            get { return bConvert.ToInt32(ViewState["personnel_id"]); }
            set { ViewState["personnel_id"] = value; }
        }

        #endregion

        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            if (!IsPostBack)
            {
                personnel_id = bConvert.ToInt32(Request.QueryString["personnel_id"]);

                bFill.Department(ddlDepartment, null, bConstants.FillTypes.Choose);
                bFill.Rank(ddlRank, null, bConstants.FillTypes.Choose);

                imbDeleteAndExit.Visible = false;

                if (personnel_id > 0)
                    FillForm();
            }
        }

        #endregion

        #region Other Events
        #endregion

        #region Button Events
        protected void imbSave_Click(object sender, EventArgs e)
        {
            if (SaveForm())
                FillForm();
        }

        protected void imbSaveAndExit_Click(object sender, EventArgs e)
        {
            if (SaveForm())
                Response.Redirect("PersonnelList.aspx?is_saved=" + (short)bConstants.EvetHayir.Evet);
            else
            {
                lblMessage.ForeColor = Color.Red;
                lblMessage.Text = "An error occured while saved the data!";
            }
        }

        protected void imbCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("PersonnelList.aspx");
        }

        protected void imbDeleteAndExit_Click(object sender, EventArgs e)
        {
            if (DeleteForm())
            {
                Response.Redirect("PersonnelList.aspx?is_deleted=" + (short)bConstants.EvetHayir.Evet);
            }
            else
            {
                lblMessage.ForeColor = Color.Red;
                lblMessage.Text = "An error occured while deleting the data!";
            }
        }

        #endregion

        #region Functions
        private bool SaveForm()
        {
            #region Kontroller
            CPersonnel PersonnelData = new CPersonnel();
            if (personnel_id > 0)
            {
                PersonnelData = bPersonnel.BrowseOne(personnel_id);
                if (PersonnelData == null || PersonnelData.personnel_id < 1)
                {
                    lblMessage.Text = "Data not found!";
                    lblMessage.ForeColor = Color.Red;
                    return false;
                }
            }
            #endregion

            #region Kayıt Hazırla
            PersonnelData.name = txtName.Text;
            PersonnelData.surname = txtSurname.Text;
            PersonnelData.tc_no = txtTcNo.Text;
            PersonnelData.rank_id = bConvert.ToInt32(ddlRank.SelectedValue);
            PersonnelData.department_id = bConvert.ToInt32(ddlDepartment.SelectedValue);
            PersonnelData.phone_number = txtPhoneNumber.Text;
            PersonnelData.email = txtEmail.Text;
            PersonnelData.home_address = txtHomeAddress.Text;
            PersonnelData.firm_date = dpFirmDate.SelectedDate;
            PersonnelData.quit_date = dpQuitDate.SelectedDate;
            #endregion

            #region Kaydet
            bool sonuc = false;

            if (personnel_id > 0)
                sonuc = bPersonnel.Update(PersonnelData);
            else
                sonuc = bPersonnel.Insert(PersonnelData);

            if (sonuc)
            {
                lblMessage.ForeColor = Color.Green;
                lblMessage.Text = "Your data has been successfully saved.!";
                if (personnel_id == 0)
                    personnel_id = bPersonnel.ReturnValue;
            }
            else
            {
                lblMessage.ForeColor = Color.Red;
                lblMessage.Text = "An error occured while saving the data!";
            }

            return sonuc;
            #endregion
        }

        private void FillForm()
        {
            CPersonnel PersonnelData = bPersonnel.BrowseOne(personnel_id);
            if (PersonnelData == null || PersonnelData.personnel_id < 1)
            {
                lblMessage.Text = "Data not found!";
                lblMessage.ForeColor = Color.Red;
                return;
            }

            txtName.Text = PersonnelData.name;
            txtSurname.Text = PersonnelData.surname;
            txtTcNo.Text = PersonnelData.tc_no;
            ddlRank.SelectedValue = bConvert.ToString(PersonnelData.rank_id);
            ddlDepartment.SelectedValue = bConvert.ToString(PersonnelData.department_id);
            txtPhoneNumber.Text = PersonnelData.phone_number;
            txtEmail.Text = PersonnelData.email;
            txtHomeAddress.Text = PersonnelData.home_address;
            dpFirmDate.SelectedDate = PersonnelData.firm_date;
            dpQuitDate.SelectedDate = PersonnelData.quit_date;

            imbDeleteAndExit.Visible = true;

        }

        private bool DeleteForm()
        {
            #region Kontroller

            if (personnel_id == 0)
            {
                return false;
            }
            #endregion

            #region Sil
            bool result = false;
            result = bPersonnel.DeletOne(personnel_id);


            return result;
            #endregion
        }
        #endregion
    }
}