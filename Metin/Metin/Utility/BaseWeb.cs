using Metin.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Metin.Utility
{
    public class BaseWeb : System.Web.UI.Page
    {
        public CKullanici Kullanici
        {
            get { return (CKullanici)Session["Kullanici"]; }
            //set { ViewState["Kullanici"] = value; }
        }

        public bPrincipal KullaniciRol
        {
            get { return new bPrincipal(Kullanici); }
        }
    }
}