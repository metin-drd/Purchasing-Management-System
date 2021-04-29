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
    public partial class DepartmentList : BaseWeb
    {
        private int department_id
        {
            get
            {
                return bConvert.ToInt32(ViewState["department_id"]);
            }
            set
            {
                ViewState["department_id"] = value;
            }
        }
       
        BDepartment _bDepartment = null;
        public BDepartment bDepartment
        {
            get
            {
                if (_bDepartment == null)
                    _bDepartment = new BDepartment();

                return _bDepartment;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FormClear();
                bFill.Personnel(ddlManagerPersonnel, null, bConstants.FillTypes.Choose);
            }

            lblMessage.Text = "";
        }

        protected void imbSave_Click(object sender, EventArgs e)
        {
            CDepartment DepartmentData = new CDepartment();

            if (department_id > 0)
            {
                DepartmentData = bDepartment.BrowseOne(department_id);
                if (DepartmentData == null || DepartmentData.department_id < 1)
                {
                    lblMessage.Text = "Data not found!";
                    lblMessage.ForeColor = Color.Red;
                    return;
                }
            }


            DepartmentData.name = txtName.Text;
            DepartmentData.manager_personnel_id = bConvert.ToInt32(ddlManagerPersonnel.SelectedValue);

            bool sonuc = false;

            if (department_id == 0)
                sonuc = bDepartment.Insert(DepartmentData);
            else
                sonuc = bDepartment.Update(DepartmentData);


            if (sonuc)
            {
                lblMessage.ForeColor = Color.Green;
                lblMessage.Text = "Your data has been successfully saved.!";
                FormClear();
            }
            else
            {
                lblMessage.ForeColor = Color.Red;
                lblMessage.Text = "An error occured while saving the data!";
            }
        }

        protected void imbCancel_Click(object sender, EventArgs e)
        {
            FormClear();
        }

        private void FormClear()
        {
            txtName.Text = "";
            ddlManagerPersonnel.SelectedValue = "0";
            department_id = 0;

            imbSave.Text = "Add";
            imbCancel.Visible = false;


            BDepartment bdepartment = new BDepartment();
            CDepartment DepartmentData = new CDepartment();
            DataTable dt = bdepartment.Search(DepartmentData);
            tgDepartment.DataSource = dt;
            tgDepartment.DataKeyNames = new string[] { "department_id" };
            tgDepartment.SelectedIndex = -1;
            tgDepartment.DataBind();
        }

        protected void tgDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {

            department_id = bConvert.ToInt32(tgDepartment.SelectedValue);

            CDepartment DepartmentData = bDepartment.BrowseOne(department_id);
            if (DepartmentData == null || DepartmentData.department_id < 1)
            {
                lblMessage.Text = "Data not found!";
                lblMessage.ForeColor = Color.Red;
                department_id = 0;
                return;
            }

            txtName.Text = DepartmentData.name;
            ddlManagerPersonnel.SelectedValue = bConvert.ToString(DepartmentData.manager_personnel_id);
            imbCancel.Visible = true;
            imbSave.Text = "Save";
        }

        protected void tgDepartment_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "btnDelete")
            {
                int rowIndex = bConvert.ToInt32(e.CommandArgument);
                int selected_department_id = bConvert.ToInt32(tgDepartment.DataKeys[rowIndex].Values[0]);

                CDepartment DepartmentData = bDepartment.BrowseOne(selected_department_id);
                if (DepartmentData == null || DepartmentData.department_id < 1)
                {
                    lblMessage.Text = "Data not found!";
                    lblMessage.ForeColor = Color.Red;
                    return;
                }

                bool sonuc = bDepartment.DeletOne(selected_department_id);
                if (sonuc)
                {
                    lblMessage.ForeColor = Color.Green;
                    lblMessage.Text = "Your data has been successfully deleted.!";
                    FormClear();
                }
                else
                {
                    lblMessage.ForeColor = Color.Red;
                    lblMessage.Text = "An error occured while deleting the data!";
                }
            }

        }

        protected void Modal_Delete_Click(object sender, EventArgs e)
        {

            
        }







    }
}