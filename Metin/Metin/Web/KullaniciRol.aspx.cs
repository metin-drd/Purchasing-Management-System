using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Metin.Utility;
using Metin.Business;
using Metin.Command;
using System.Data;
using System.Drawing;

namespace Metin.Web
{
    public partial class KullaniciRol : System.Web.UI.Page
    {
        #region General
        BKullaniciRol _bKullaniciRol = null;
        BKullaniciRol bKullaniciRol
        {
            get
            {
                if (_bKullaniciRol == null)
                    _bKullaniciRol = new BKullaniciRol();

                return _bKullaniciRol;
            }
        }
        #endregion

        #region Properties
        int kullanici_rol_id;      
        #endregion

        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillGrid();
                bFill.Kullanici(ddlKullanici, null, bConstants.FillTypes.Choose);
                bFill.Fill_SabitDeger(ddlRol, bConstants.SabitDegerTipi.Rol, bConstants.FillTypes.Choose);
                imbCancel.Visible = false;
            }

            lblMessage.Text = "";
        }
        #endregion

        #region Other Events

        #endregion

        #region Button Events
        protected void imbSave_Click(object sender, EventArgs e)
        {
            FormSave();
            FillGrid();
        }

        protected void imbCancel_Click(object sender, EventArgs e)
        {
            FormClear();
        }

        protected void tgKullaniciRol_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "btnDelete")
            {
                int rowIndex = bConvert.ToInt32(e.CommandArgument);
                int selected_kullanici_rol_id = bConvert.ToInt32(tgKullaniciRol.DataKeys[rowIndex].Values[0]);


                CKullaniciRol KullaniciRolData = bKullaniciRol.BrowseOne(selected_kullanici_rol_id);
                if (KullaniciRolData == null || KullaniciRolData.kullanici_rol_id < 1)
                {
                    lblMessage.Text = "Data not found!";
                    lblMessage.ForeColor = Color.Red;
                    return;
                }

                bool sonuc = bKullaniciRol.DeletOne(selected_kullanici_rol_id);
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

        #endregion

        #region Functions

        public void FormClear()
        {
            ddlKullanici.SelectedIndex = -1;
            ddlRol.SelectedIndex = -1;

            FillGrid();
        }

        public void FillGrid()
        {
            //BKullaniciRol bKullaniciRol = new BKullaniciRol();
            CKullaniciRol KullaniciRolData = new CKullaniciRol();
            DataTable dt = bKullaniciRol.Search(KullaniciRolData);

            tgKullaniciRol.DataSource = dt;
            tgKullaniciRol.DataKeyNames = new string[] { "kullanici_rol_id" };
            tgKullaniciRol.SelectedIndex = -1;
            tgKullaniciRol.DataBind();
        }

        public void FormSave()
        {
            #region Kontrol
            CKullaniciRol KullaniciRolData = new CKullaniciRol();

            if (kullanici_rol_id > 0)
            {
                KullaniciRolData = bKullaniciRol.BrowseOne(kullanici_rol_id);
                if (KullaniciRolData == null || KullaniciRolData.kullanici_rol_id < 1)
                {
                    lblMessage.Text = "Data not found";
                    lblMessage.ForeColor = Color.Red;

                    return;
                }
            }

            CKullaniciRol KullaniciRolData2 = new CKullaniciRol();
            KullaniciRolData2.kullanici_id = bConvert.ToInt32(ddlKullanici.SelectedValue);
            KullaniciRolData2.rol = bConvert.ToInt16(ddlRol.SelectedValue);
            DataTable dt = bKullaniciRol.Search(KullaniciRolData2);

            if (dt == null || dt.Rows.Count > 0)
            {
                lblMessage.Text = "Such a record already exists";
                lblMessage.ForeColor = Color.Red;
                return;
            }
            #endregion

            #region Hazırlık
            KullaniciRolData.kullanici_id = bConvert.ToInt32(ddlKullanici.SelectedValue);
            KullaniciRolData.rol = bConvert.ToInt16(ddlRol.SelectedValue);
            #endregion

            #region Kayıt
            bool sonuc = false;

            if (kullanici_rol_id > 0)
                sonuc = bKullaniciRol.Update(KullaniciRolData);
            else
                sonuc = bKullaniciRol.Insert(KullaniciRolData);

            if (sonuc)
            {
                lblMessage.Text = "Your data has been successfully saved.!";
                lblMessage.ForeColor = Color.Green;
            }
            else
            {
                lblMessage.Text = "An error occured while saving the data!";
                lblMessage.ForeColor = Color.Green;
            }
            #endregion
        }

        #endregion

    }
}