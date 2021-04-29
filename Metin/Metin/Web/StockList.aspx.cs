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
    public partial class StockList : BaseWeb
    {
        #region General
        BStock _bStock = null;
        BStock bStock
        {
            get
            {
                if (_bStock == null)
                    _bStock = new BStock();

                return _bStock;
            }
        }
        #endregion

        #region Properties
        public int stock_id
        {
            get
            {
                return bConvert.ToInt32(ViewState["stock_id"]);
            }
            set
            {
                ViewState["stock_id"] = value;
            }
        }
        #endregion

        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                bFill.StockCategory(ddlStockCategory, null, bConstants.FillTypes.Choose);

                FormClear();

            }
            lblMessage.Text = "";
        }
        #endregion

        #region Other Events
        #endregion

        #region Button Events
        protected void imbSave_Click(object sender, EventArgs e)
        {
            SaveForm();
        }

        protected void tgStock_SelectedIndexChanged(object sender, EventArgs e)
        {
            stock_id = bConvert.ToInt32(tgStock.SelectedValue);

            CStock StokData = bStock.BrowseOne(stock_id);

            if (StokData == null || StokData.stock_id < 1)
            {
                lblMessage.Text = "Data no found";
                lblMessage.ForeColor = Color.Red;
                stock_id = 0;
                return;
            }

            txtStockName.Text = StokData.stock_name;
            ddlStockCategory.SelectedValue =bConvert.ToString(StokData.stock_category_id);
            imbCancel.Visible = true;
            imbSave.Text = "Save";

        }

        protected void tgStock_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "btnDelete")
            {
                int rowIndex = bConvert.ToInt32(e.CommandArgument);
                int selected_stock_id = bConvert.ToInt32(tgStock.DataKeys[rowIndex].Values[0]);


                CStock StockData = bStock.BrowseOne(selected_stock_id);
                if (StockData == null || StockData.stock_id < 1)
                {
                    lblMessage.Text = "Data not found!";
                    lblMessage.ForeColor = Color.Red;
                    return;
                }

                bool sonuc = bStock.DeleteOne(selected_stock_id);
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

        protected void imbCancel_Click(object sender, EventArgs e)
        {
            FormClear();

        }

        #endregion

        #region Functions
        public void FormClear()
        {
            txtStockName.Text = "";
            stock_id = 0;
            ddlStockCategory.SelectedIndex = -1;

            imbSave.Text = "Add";
            imbCancel.Visible = false;

            FillGrid();
        }

        public void FillGrid()
        {            
            CStock StockData = new CStock();
            DataTable dt = bStock.Search(StockData);
            tgStock.DataSource = dt;
            tgStock.DataKeyNames = new string[] { "stock_id" };
            tgStock.SelectedIndex = -1;
            tgStock.DataBind();
        }

        public void SaveForm()
        {
            CStock StockData = new CStock();

            if (stock_id > 0)
            {
                StockData = bStock.BrowseOne(stock_id);
                if (StockData == null || StockData.stock_id < 1)
                {
                    lblMessage.Text = "Data not found!";
                    lblMessage.ForeColor = Color.Red;
                    return;
                }
            }

            StockData.stock_name = txtStockName.Text;
            StockData.stock_category_id =bConvert.ToInt32(ddlStockCategory.SelectedValue);

            bool sonuc = false;

            if (stock_id == 0)
                sonuc = bStock.Insert(StockData);

            else
                sonuc = bStock.Update(StockData);


            if (sonuc)
            {
                lblMessage.Text = "Your data has been successfully saved.!";
                lblMessage.ForeColor = Color.Green;
                FormClear();
            }
            else
            {
                lblMessage.Text = "An error occured while saving the data!";
                lblMessage.ForeColor = Color.Red;
            }
        }

        #endregion

        









    }
}