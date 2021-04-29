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
    public partial class RankList : BaseWeb
    {
        private int rank_id
        {
            get
            {
                return bConvert.ToInt32(ViewState["rank_id"]);
            }
            set
            {
                ViewState["rank_id"] = value;
            }
        }

        BRank _bRank = null;
        public BRank bRank
        {
            get
            {
                if (_bRank == null)
                    _bRank = new BRank();

                return _bRank;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FormClear();
            }

            lblMessage.Text = "";
        }

        protected void imbSave_Click(object sender, EventArgs e)
        {
            CRank RankData = new CRank();

            if (rank_id > 0)
            {
                RankData = bRank.BrowseOne(rank_id);
                if (RankData == null || RankData.rank_id < 1)
                {
                    lblMessage.Text = "Data not found!";
                    lblMessage.ForeColor = Color.Red;
                    return;
                }
            }


            RankData.name = txtName.Text;

            bool sonuc = false;

            if (rank_id == 0)
                sonuc = bRank.Insert(RankData);
            else
                sonuc = bRank.Update(RankData);


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
            rank_id = 0;

            imbSave.Text = "Add";
            imbCancel.Visible = false;

            BRank brank = new BRank();
            CRank RankData = new CRank();
            DataTable dt = brank.Search(RankData);
            tgRank.DataSource = dt;
            tgRank.DataKeyNames = new string[] { "rank_id" };
            tgRank.SelectedIndex = -1;
            tgRank.DataBind();
        }

        protected void tgRank_SelectedIndexChanged(object sender, EventArgs e)
        {
            rank_id = bConvert.ToInt32(tgRank.SelectedValue);

            CRank RankData = bRank.BrowseOne(rank_id);
            if (RankData == null || RankData.rank_id < 1)
            {
                lblMessage.Text = "Data not found!";
                lblMessage.ForeColor = Color.Red;
                rank_id = 0;
                return;
            }

            txtName.Text = RankData.name;
            imbCancel.Visible = true;
            imbSave.Text = "Save";
        }

        protected void tgRank_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "btnDelete")
            {
                int rowIndex = bConvert.ToInt32(e.CommandArgument);
                int selected_rank_id = bConvert.ToInt32(tgRank.DataKeys[rowIndex].Values[0]);


                CRank RankData = bRank.BrowseOne(selected_rank_id);
                if (RankData == null || RankData.rank_id < 1)
                {
                    lblMessage.Text = "Data not found!";
                    lblMessage.ForeColor = Color.Red;
                    return;
                }

                bool sonuc = bRank.DeletOne(selected_rank_id);
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








    }
}