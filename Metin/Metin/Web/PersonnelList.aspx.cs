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
    public partial class PersonnelList : BaseWeb
    {
        public bool is_saved
        {
            get { return bConvert.ToInt32(Request.QueryString["is_saved"]) == (int)bConstants.EvetHayir.Evet ? true : false; }
        }

        public bool is_deleted 
        {
            get { return bConvert.ToInt32(Request.QueryString["is_deleted"]) == (int)bConstants.EvetHayir.Evet ? true : false; }
        }

        BPersonnel _bPersonnel = null;
        public BPersonnel bPersonnel
        {
            get
            {
                if (_bPersonnel == null)
                    _bPersonnel = new BPersonnel();

                return _bPersonnel;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "";

            if (!IsPostBack)
            {
                if (is_saved)
                {
                    lblMessage.Text = "Your data has been successfully saved.!";
                    lblMessage.ForeColor = Color.Green;
                }

                if (is_deleted)
                {
                    lblMessage.Text="Your data has been successfully deleted.!";
                    lblMessage.ForeColor = Color.Green;
                }
                bFill.Department(ddlDepartment, null, bConstants.FillTypes.All);
                GridList();
            }
        }

        private void GridList()
        {
            CPersonnel PersonneltData = new CPersonnel();
            PersonneltData.name = txtName.Text;
            PersonneltData.surname = txtSurname.Text;
            PersonneltData.department_id = bConvert.ToInt32(ddlDepartment.SelectedValue);
            PersonneltData.is_active = cbxIsActive.Checked ? (short)bConstants.EvetHayir.Evet : (short)0;

            DataTable dt = bPersonnel.Search(PersonneltData);
            tgPersonnel.DataSource = dt;
            tgPersonnel.DataKeyNames = new string[] { "personnel_id" };
            tgPersonnel.SelectedIndex = -1;
            tgPersonnel.DataBind();
        }

        protected void imbSearch_Click(object sender, EventArgs e)
        {
            GridList();
        }

        protected void tgPersonnel_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("Personnel.aspx?personnel_id=" + bConvert.ToInt32(tgPersonnel.SelectedValue));
        }

        protected void imbNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("Personnel.aspx");
        }

        protected void imbClear_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtSurname.Text = "";
            ddlDepartment.SelectedValue = "0";
            cbxIsActive.Checked = false;

            GridList();
        }

    }
}
