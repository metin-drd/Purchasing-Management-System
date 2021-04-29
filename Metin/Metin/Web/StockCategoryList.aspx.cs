using Metin.Business;
using Metin.Command;
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
    public partial class StockCategoryList : System.Web.UI.Page
    {
        
        #region Properties
        private int stock_category_id
        {
            get
            {
                return bConvert.ToInt32(ViewState["stock_category_id"]);
            }
            set
            {
                ViewState["stock_category_id"] = value;
            }
        }
        #endregion

        #region General
        BStockCategory _bStockCategory = null;
        public BStockCategory bStockCategory
        {
            get
            {
                if (_bStockCategory == null)
                    _bStockCategory = new BStockCategory();

                return _bStockCategory;
            }
        }
        #endregion

        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClearForm();
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

        protected void imbCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        protected void tgStockCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            stock_category_id = bConvert.ToInt32(tgStockCategory.SelectedValue);

            CStockCategory StockCategoryData = bStockCategory.BrowseOne(stock_category_id);
            if (StockCategoryData == null || StockCategoryData.stock_category_id < 1)
            {
                lblMessage.Text = "Data not found!";
                lblMessage.ForeColor = Color.Red;
                stock_category_id = 0;
                return;
            }

            txtName.Text = StockCategoryData.name;
            imbCancel.Visible = true;
            imbSave.Text = "Save";
        }

        protected void tgStockCategory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "btnDelete")
            {
                int rowIndex = bConvert.ToInt32(e.CommandArgument);
                int selected_StockCategory_id = bConvert.ToInt32(tgStockCategory.DataKeys[rowIndex].Values[0]);


                CStockCategory StockCategoryData = bStockCategory.BrowseOne(selected_StockCategory_id);
                if (StockCategoryData == null || StockCategoryData.stock_category_id < 1)
                {
                    lblMessage.Text = "Data not found!";
                    lblMessage.ForeColor = Color.Red;
                    return;
                }

                bool sonuc = bStockCategory.DeletOne(selected_StockCategory_id);
                if (sonuc)
                {
                    lblMessage.ForeColor = Color.Green;
                    lblMessage.Text = "Your data has been successfully deleted.!";
                    ClearForm();
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

        public void SaveForm()
        {
            #region Kontrol
            CStockCategory StockCategoryData = new CStockCategory();

            if (stock_category_id > 0)
            {
                StockCategoryData = bStockCategory.BrowseOne(stock_category_id);
                if (StockCategoryData == null || StockCategoryData.stock_category_id < 1)
                {
                    lblMessage.Text = "Data not found!";
                    lblMessage.ForeColor = Color.Red;
                    return;
                }
            }
            #endregion

            #region Kayıt
            StockCategoryData.name = txtName.Text;

            bool sonuc = false;

            if (stock_category_id == 0)
                sonuc = bStockCategory.Insert(StockCategoryData);
            else
                sonuc = bStockCategory.Update(StockCategoryData);


            if (sonuc)
            {
                lblMessage.ForeColor = Color.Green;
                lblMessage.Text = "Your data has been successfully saved.!";
                ClearForm();
            }
            else
            {
                lblMessage.ForeColor = Color.Red;
                lblMessage.Text = "An error occured while saving the data!";
            }
            #endregion
        }

        public void ClearForm()
        {
            txtName.Text = "";
            stock_category_id = 0;
            tgStockCategory.SelectedIndex = -1;

            imbSave.Text = "Add";
            imbCancel.Visible = false;

            GridFill();
        }

        public void GridFill()
        {
            CStockCategory StockCategoryData = new CStockCategory();
            DataTable dt = bStockCategory.Search(StockCategoryData);
            tgStockCategory.DataSource = dt;
            tgStockCategory.DataKeyNames = new string[] { "stock_category_id" };
            tgStockCategory.SelectedIndex = -1;
            tgStockCategory.DataBind();
        }

        #endregion


    }
}