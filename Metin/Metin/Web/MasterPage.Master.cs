using Metin.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Metin.Web
{
    public partial class MasterPage : BaseMasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["personnel_id"] == null)
                Response.Redirect("Login.aspx?url=" + Request.RawUrl);

            if (Session["personnel_full_name"] != null)
                lblUser.Text = bConvert.ToString(Session["personnel_full_name"]);


            if (!KullaniciRol.Admin)
            {
                aUserDefinition.HRef = "";
                aUserDefinition.Style.Add("color", "lightgray");
                aUserDefinition.Title = "You do not have permission to access the page";
            }

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");

        }
    }
}