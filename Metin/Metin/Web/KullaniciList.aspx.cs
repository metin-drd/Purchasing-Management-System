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
    public partial class KullaniciList : BaseWeb
    {
        #region General
        BKullanici _bKullanici = null;
        BKullanici bKullanici
        {
            get
            {
                if (_bKullanici == null)
                    _bKullanici = new BKullanici();

                return _bKullanici;
            }
        }
        #endregion

        #region Properties
        private int kullanici_id
        {
            get { return bConvert.ToInt32(ViewState["kullanici_id"]); }
            set { ViewState["kullanici_id"] = value; }
        }
        #endregion

        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            if (!IsPostBack)
            {
                FormClear();
                bFill.Personnel(ddlPersonnel, null, bConstants.FillTypes.Choose);
            }
        }

        #endregion

        #region Grid Events
        protected void tgKullanici_SelectedIndexChanged(object sender, EventArgs e)
        {
            kullanici_id = bConvert.ToInt32(tgKullanici.SelectedValue);
            CKullanici KullaniciData = bKullanici.BrowseOne(kullanici_id);
            
            if (KullaniciData == null && KullaniciData.kullanici_id < 1)
            {
                lblMessage.ForeColor = Color.Red;
                lblMessage.Text = "Data not found";
                kullanici_id = 0;
                return;
            }

            ddlPersonnel.SelectedValue = KullaniciData.personnel_id.ToString();
            txtKullaniciKodu.Text = KullaniciData.kullanici_kodu;

            imbCancel.Visible = true;
            imbSave.Text = "Save";
            ddlPersonnel.Enabled = false;
        }

        protected void tgKullanici_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "btnDelete")
            {

                int row_index = bConvert.ToInt32(e.CommandArgument);
                int selected_kullanici_id = bConvert.ToInt32(tgKullanici.DataKeys[row_index].Values[0]);

                CKullanici KullaniciData = bKullanici.BrowseOne(selected_kullanici_id);

                if (KullaniciData == null || KullaniciData.kullanici_id == 0)
                {
                    lblMessage.Text = "Data not found.!";
                    lblMessage.ForeColor = Color.Red;
                    return;
                }


                bool sonuc = bKullanici.DeletOne(selected_kullanici_id);
                if (sonuc)
                {
                    lblMessage.Text = "Your data has been successfully deleted.!";
                    lblMessage.ForeColor = Color.Green;
                    FormClear();
                }
                else
                {
                    lblMessage.Text = "An error occured while deleting the data!";
                    lblMessage.ForeColor = Color.Red;
                }


            }
        }

        #endregion

        #region Button Events
        protected void imbSave_Click(object sender, EventArgs e)
        {
            if (FormSave())
                FormClear();
        }

        protected void imbCancel_Click(object sender, EventArgs e)
        {
            FormClear();
        }

        #endregion

        #region Functions
        public bool FormSave()
        {
            #region Kontroller
            int selected_personnel_id = bConvert.ToInt32(ddlPersonnel.SelectedValue);
            CKullanici KullaniciSearchData = new CKullanici();
            KullaniciSearchData.personnel_id = selected_personnel_id;
            DataTable dtKullanici = bKullanici.Search(KullaniciSearchData);

            if (kullanici_id == 0 && dtKullanici != null && dtKullanici.Rows.Count > 0)
            {
                lblMessage.Text = "Error: Duplicate record!";
                lblMessage.ForeColor = Color.Red;
                return false;
            }

            if (txtSifre.Text != txtSifreTekrar.Text)
            {
                lblMessage.Text = "Passwords did not match!";
                lblMessage.ForeColor = Color.Red;
                return false;
            }

            CKullanici KullaniciData = new CKullanici();
            if (kullanici_id > 0)
            {
                KullaniciData = bKullanici.BrowseOne(kullanici_id);
                if (KullaniciData == null || KullaniciData.kullanici_id == 0)
                {
                    lblMessage.Text = "Data not found!";
                    lblMessage.ForeColor = Color.Red;
                    return false;
                }

            }
            #endregion

            #region Kayıt Hazırla
            //KullaniciData = new CKullanici();
            //KullaniciData.kullanici_id = kullanici_id;
            KullaniciData.kullanici_kodu = txtKullaniciKodu.Text;
            KullaniciData.personnel_id = bConvert.ToInt32(ddlPersonnel.SelectedValue);
            KullaniciData.sifre = txtSifre.Text;
            #endregion

            #region Save
            bool sonuc = false;

            if (kullanici_id == 0)
                sonuc = bKullanici.Insert(KullaniciData);
            else
                sonuc = bKullanici.Update(KullaniciData);


            if (sonuc)
            {
                lblMessage.ForeColor = Color.Green;
                lblMessage.Text = "Your data has been successfully saved.!";
            }
            else
            {
                lblMessage.Text = "An error occured while saving the data!";
                lblMessage.ForeColor = Color.Red;
            }


            return sonuc;
            #endregion
        }

        public void FormClear()
        {
            kullanici_id = 0;

            txtKullaniciKodu.Text = "";
            txtSifre.Text = "";
            txtSifreTekrar.Text = "";
            ddlPersonnel.SelectedIndex = 0;

            imbSave.Text = "Add";
            imbCancel.Visible = false;
            ddlPersonnel.Enabled = true;

            CKullanici KullaniciData = new CKullanici();
            DataTable dt = bKullanici.Search(KullaniciData);

            tgKullanici.DataSource = dt;
            tgKullanici.DataKeyNames = new string[] { "kullanici_id" };
            tgKullanici.SelectedIndex = -1;
            tgKullanici.DataBind();
        }

        #endregion

    }
}