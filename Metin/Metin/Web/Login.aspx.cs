using Metin.Business;
using Metin.Command;
using Metin.Utility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Metin.Web
{
    public partial class Login : BaseWeb
    {
        public string target_url
        {
            get
            {
                return bConvert.ToString(Request.QueryString["url"]);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            BKullanici bKullanici = new BKullanici();
            CKullanici KullaniciData = bKullanici.Login(txtUsername.Value, txtPassword.Value);

            if (KullaniciData != null && KullaniciData.personnel_id > 0)
            {
                Session.Add("personnel_id", KullaniciData.personnel_id);
                Session.Add("personnel_full_name", KullaniciData.personnel_full_name);
                Session.Add("Kullanici", KullaniciData);

                if (String.IsNullOrEmpty(target_url))
                {
                    string main_page_url = ConfigurationManager.AppSettings["MainPage"];
                    Response.Redirect(main_page_url);
                }
                else
                    Response.Redirect(target_url);
            }
            else
            {
                lblError.Text = "Invalid username or password. Please try again";
            }
        }
    }
}