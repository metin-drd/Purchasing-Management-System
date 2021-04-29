using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Metin.Utility;
using Metin.Command;
using Metin.Business;
using System.Drawing;
using System.Data;
using System.IO;
using System.Text;
using Metin.Web.UserControls;

namespace Metin.Web
{
    public partial class Requisition : BaseWeb
    {
        #region General

        BRequisition _bRequisition = null;
        BRequisition bRequisition
        {
            get
            {
                if (_bRequisition == null)
                    _bRequisition = new BRequisition();

                return _bRequisition;
            }
        }

        BDepartment _bDepartment = null;
        BDepartment bDepartment
        {
            get
            {
                if (_bDepartment == null)
                    _bDepartment = new BDepartment();

                return _bDepartment;
            }
        }

        BRequisitionItem _bRequisitionItem = null;
        BRequisitionItem bRequisitionItem
        {
            get
            {
                if (_bRequisitionItem == null)
                    _bRequisitionItem = new BRequisitionItem();

                return _bRequisitionItem;
            }
        }

        BDocumentFile _bDocumentFile = null;
        BDocumentFile bDocumentFile
        {
            get
            {
                if (_bDocumentFile == null)
                    _bDocumentFile = new BDocumentFile();

                return _bDocumentFile;
            }
        }

        #endregion

        #region Properties

        private int requisition_id
        {
            get { return bConvert.ToInt32(ViewState["requisition_id"]); }
            set { ViewState["requisition_id"] = value; }
        }

        private int requisition_item_id
        {
            get { return bConvert.ToInt32(ViewState["requisition_item_id"]); }
            set { ViewState["requisition_item_id"] = value; }
        }

        private DataTable _dtRequisitionItem = null;
        private DataTable dtRequisitionItem
        {
            get
            {
                if (_dtRequisitionItem == null && ViewState["dtRequisitionItem"] == null)
                {
                    _dtRequisitionItem = new DataTable();
                    _dtRequisitionItem.Columns.Add("requisition_item_id", typeof(int));
                    // _dtRequisitionItem.Columns.Add("requisition_id", typeof(int));
                    _dtRequisitionItem.Columns.Add("stock_id", typeof(int));
                    _dtRequisitionItem.Columns.Add("unit_price", typeof(decimal));
                    _dtRequisitionItem.Columns.Add("quantity", typeof(int));
                    _dtRequisitionItem.Columns.Add("stock_category_id", typeof(int));
                    _dtRequisitionItem.Columns.Add("stock_name", typeof(string));
                    _dtRequisitionItem.Columns.Add("total_price", typeof(decimal));
                    ViewState["dtRequisitionItem"] = _dtRequisitionItem;
                }

                if (_dtRequisitionItem == null)
                    _dtRequisitionItem = ViewState["dtRequisitionItem"] as DataTable;

                return _dtRequisitionItem;
            }
            set
            {
                ViewState["dtRequisitionItem"] = value;
            }
        }

        private ucFile _File = null;
        private ucFile File
        {
            get
            {
                if (_File == null)
                {//_File = FindControlBase("ucFile1") as ucFile;
                    _File = ucFile1;
                }
                return _File;
            }
        }

        #endregion

        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                requisition_id = bConvert.ToInt32(Request.QueryString["requisition_id"]);

                bFill.Department(ddlResponsibleDepartment, null, bConstants.FillTypes.Choose);
                ddlResponsibleDepartment.SelectedValue = bConvert.ToString(Kullanici.department_id);

                bFill.StockCategory(ddlStockCategory, null, bConstants.FillTypes.Choose);

                txtTotalPrice.Enabled = false;
                imbApprove.Visible = imbReject.Visible = imbPurchase.Visible = imbDeleteAndExit.Visible = imbItemCancel.Visible = false;

                if (requisition_id > 0)
                    FillForm();
                else
                {
                    lblPersonnelName.Text = Kullanici.personnel_full_name;
                    lblStatusName.Text = "New";
                }

                txtUnitPrice.Attributes.Add("onblur", "CalculateItemTotalPrice('" + txtUnitPrice.ClientID.ToString() + "','" + txtQuantity.ClientID.ToString() + "','" + txtItemTotalPrice.ClientID.ToString() + "')");
                txtQuantity.Attributes.Add("onblur", "CalculateItemTotalPrice('" + txtUnitPrice.ClientID.ToString() + "','" + txtQuantity.ClientID.ToString() + "','" + txtItemTotalPrice.ClientID.ToString() + "')");

                File.form_id_property_name = "requisition_id";
                File.file_type = (int)bConstants.FileType.Purchasing;
            }

            lblMessage.Text = "";
        }
        #endregion

        #region Other Events
        protected void ddlStockCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            CStock StockData = new CStock();
            StockData.stock_category_id = bConvert.ToInt32(ddlStockCategory.SelectedValue);
            bFill.Stock(ddlStock, StockData, bConstants.FillTypes.Choose);
        }
        #endregion

        #region Button Events
        protected void imbSave_Click(object sender, EventArgs e)
        {
            if (SaveForm(ButtonType.Save))
                FillForm();

        }

        protected void imbSaveAndExit_Click(object sender, EventArgs e)
        {
            if (SaveForm(ButtonType.Save))
                Response.Redirect("RequisitionList.aspx?is_saved=" + bConstants.EvetHayir.Evet);
        }

        protected void imbCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("RequisitionList.aspx");
        }

        protected void imbDeleteAndExit_Click(object sender, EventArgs e)
        {
            if (DeleteForm())
            {
                Response.Redirect("RequisitionList.aspx?is_deleted=" + (int)bConstants.EvetHayir.Evet);
            }
            else
            {
                lblMessage.Text = "An error occured while deleting the data!";
                lblMessage.ForeColor = Color.Red;
            }
        }

        protected void imbItemSave_Click(object sender, EventArgs e)
        {
            if (SaveItem())
            {
                FillGridItem();
                ClearItem();
                imbItemCancel.Visible = false;

                ClearItem();
            }
        }

        protected void imbItemCancel_Click(object sender, EventArgs e)
        {
            ClearItem();
        }

        protected void imbPurchase_Click(object sender, EventArgs e)
        {
            if (SaveForm(ButtonType.Purchase))
                FillForm();
        }

        protected void imbReject_Click(object sender, EventArgs e)
        {
            if (SaveForm(ButtonType.Reject))
                FillForm();
        }

        protected void imbApprove_Click(object sender, EventArgs e)
        {
            if (SaveForm(ButtonType.Approve))
                FillForm();
        }
        #endregion

        #region Grid Events
        protected void tgRequisitionItem_SelectedIndexChanged(object sender, EventArgs e)
        {

            requisition_item_id = bConvert.ToInt32(tgRequisitionItem.SelectedValue);

            if (requisition_id > 0)
            {
                CRequisitionItem RequisitionItemData = bRequisitionItem.BrowseOne(requisition_item_id);

                if (RequisitionItemData == null || RequisitionItemData.requisition_item_id < 1)
                {
                    lblMessage.Text = "Data not found!";
                    lblMessage.ForeColor = Color.Red;
                    requisition_item_id = 0;
                    return;
                }


                ddlStockCategory.SelectedValue = bConvert.ToString(RequisitionItemData.stock_cat_id);

                CStock StockData = new CStock();
                StockData.stock_category_id = bConvert.ToInt32(ddlStockCategory.SelectedValue);
                bFill.Stock(ddlStock, StockData, bConstants.FillTypes.Choose);

                ddlStock.SelectedValue = bConvert.ToString(RequisitionItemData.stock_id);

                txtUnitPrice.Text = bConvert.ToString(RequisitionItemData.unit_price);
                txtQuantity.Text = bConvert.ToString(RequisitionItemData.quantity);
            }
            else
            {
                DataRow drRequisitionItem = dtRequisitionItem.Select("requisition_item_id = '" + requisition_item_id + "'").FirstOrDefault();

                ddlStockCategory.SelectedValue = bConvert.ToString(drRequisitionItem["stock_category_id"]);

                CStock StockData = new CStock();
                BStock bStock = new BStock();
                StockData.stock_category_id = bConvert.ToInt32(ddlStockCategory.SelectedValue);
                bFill.Stock(ddlStock, StockData, bConstants.FillTypes.Choose);
                StockData = bStock.BrowseOne(bConvert.ToInt32(ddlStock.SelectedValue));


                ddlStock.SelectedValue = bConvert.ToString(drRequisitionItem["stock_id"]);
                txtUnitPrice.Text = bConvert.ToString(drRequisitionItem["unit_price"]);
                txtQuantity.Text = bConvert.ToString(drRequisitionItem["quantity"]);
            }


            imbItemCancel.Visible = true;
        }

        protected void tgRequisitionItem_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "btnDelete")
            {
                int rowIndex = bConvert.ToInt32(e.CommandArgument);
                int selected_requisitionitem_id = bConvert.ToInt32(tgRequisitionItem.DataKeys[rowIndex].Values[0]);

                bool sonuc = false;

                if (requisition_id > 0)
                {
                    CRequisitionItem RequisitionItemData = bRequisitionItem.BrowseOne(selected_requisitionitem_id);
                    if (RequisitionItemData == null || RequisitionItemData.requisition_item_id < 1)
                    {
                        lblMessage.Text = "Data not found!";
                        lblMessage.ForeColor = Color.Red;
                        return;
                    }
                    sonuc = bRequisitionItem.DeletOne(selected_requisitionitem_id);

                    if (sonuc)
                    {
                        CRequisitionItem RequisitionItemData2 = new CRequisitionItem();
                        RequisitionItemData2.requisition_id = requisition_id;
                        DataTable dt = bRequisitionItem.Search(RequisitionItemData2);

                        decimal total = 0;
                        foreach (DataRow item in dt.Rows)
                        {
                            total += bConvert.ToDecimal(item["unit_price"]) * bConvert.ToDecimal(item["quantity"]);
                        }

                        txtTotalPrice.Text = bConvert.ToString(total);
                    }
                }

                else
                {
                    DataRow dr = dtRequisitionItem.Select("requisition_item_id = '" + selected_requisitionitem_id + "'").FirstOrDefault();
                    if (dr == null)
                        sonuc = false;
                    else
                    {
                        dtRequisitionItem.Rows.Remove(dr);
                        sonuc = true;
                    }
                }

                if (sonuc)
                {
                    lblMessage.ForeColor = Color.Green;
                    lblMessage.Text = "Your data has been successfully deleted.!";
                    ClearItem();
                    FillGridItem();
                }
                else
                {
                    lblMessage.ForeColor = Color.Red;
                    lblMessage.Text = "An error occured while deleting the data!";
                }

                if (sonuc)
                {
                    decimal total_price = 0;
                    foreach (DataRow item in dtRequisitionItem.Rows)
                    {
                        total_price += bConvert.ToDecimal(item["total_price"]);
                    }
                    txtTotalPrice.Text = bConvert.ToString(total_price);
                }
            }


        }
        #endregion

        #region Functions
        public bool SaveForm(ButtonType button_type)
        {
            #region Kontroller
            CRequisition RequisitionData = new CRequisition();


            if (requisition_id > 0)
            {
                RequisitionData = bRequisition.BrowseOne(requisition_id);
                if (RequisitionData == null || RequisitionData.requisition_id < 1)
                {
                    lblMessage.Text = "Data not found!";
                    lblMessage.ForeColor = Color.Red;
                    return false;
                }
            }
            #endregion

            #region Kayıt Hazırla
            RequisitionData.request_date = dpRequestDate.SelectedDate;
            RequisitionData.purchased_date = dpPurchasedDate.SelectedDate;
            RequisitionData.responsible_department_id = bConvert.ToInt32(ddlResponsibleDepartment.SelectedValue);
            RequisitionData.comment = txtComment.Text;



            if (requisition_id == 0)
                RequisitionData.request_personnel_id = Kullanici.personnel_id;

            // status belirleme
            if (requisition_id == 0)
                RequisitionData.status = (short)bConstants.RequisitionStatus.Requested;
            else if (button_type == ButtonType.Reject)
                RequisitionData.status = (short)bConstants.RequisitionStatus.Rejected;
            else if (button_type == ButtonType.Approve && RequisitionData.status == (int)bConstants.RequisitionStatus.Requested)
                RequisitionData.status = (short)bConstants.RequisitionStatus.ApprovedDepartmentManager;
            else if (button_type == ButtonType.Approve && RequisitionData.status == (int)bConstants.RequisitionStatus.ApprovedDepartmentManager)
                RequisitionData.status = (short)bConstants.RequisitionStatus.ApprovedGeneralManager;
            else if (button_type == ButtonType.Purchase)
            {
                RequisitionData.status = (short)bConstants.RequisitionStatus.Purchased;
                RequisitionData.purchased_date = DateTime.Now;
            }

            #endregion

            #region Kaydet
            bool sonuc = true;
            string error_message = "";

            try
            {
                if (requisition_id > 0)
                    sonuc = bRequisition.Update(RequisitionData);

                else
                {
                    if (sonuc)
                        sonuc = bRequisition.Insert(RequisitionData);

                    if (sonuc)
                    {
                        CRequisitionItem RequisitionItemData = new CRequisitionItem();
                        foreach (DataRow item in dtRequisitionItem.Rows)
                        {
                            RequisitionItemData.FromDataRow(item);
                            RequisitionItemData.requisition_id = bRequisition.ReturnValue;
                            sonuc = bRequisitionItem.Insert(RequisitionItemData);
                            if (!sonuc)
                                break;
                        }
                    }
                    if (sonuc)
                        File.SaveUCFile(bRequisition.ReturnValue);

                }
            }
            catch (Exception ex)
            {
                sonuc = false;
                error_message = ex.Message;
            }


            if (sonuc)
            {
                lblMessage.Text = "Your data has been successfully saved.!";
                lblMessage.ForeColor = Color.Green;

                if (requisition_id == 0)
                    requisition_id = bRequisition.ReturnValue;
            }
            else
            {
                lblMessage.Text = "An error occured while saving the data! - " + error_message;
                lblMessage.ForeColor = Color.Red;
            }

            return sonuc;

            #endregion
        }

        public bool DeleteForm()
        {
            #region Kontroller
            if (requisition_id == 0)
                return false;

            #endregion

            #region Sil
            bool sonuc = true;


            CRequisitionItem RequisitionItemData = new CRequisitionItem();
            RequisitionItemData.requisition_id = requisition_id;
            DataTable dtSilinecekItems = bRequisitionItem.Search(RequisitionItemData);

            if (sonuc)
            {
                foreach (DataRow row in dtSilinecekItems.Rows)
                {
                    sonuc = bRequisitionItem.DeletOne(bConvert.ToInt32(row["requisition_item_id"]));
                    if (!sonuc)
                        break;
                }
            }


            // File ve DocumentFile ve Fiziksel dosyayı siler
            CDocumentFile DocumentFileData = new CDocumentFile();
            CFile FileData = new CFile();
            BFile bFile = new BFile();
            FileData.requisition_id = requisition_id;
            DataTable dtFile = bFile.Search(FileData);

            foreach (DataRow item in dtFile.Rows)
            {
                int document_file_id = bConvert.ToInt32(item["document_file_id"]);

                DocumentFileData = bDocumentFile.BrowseOne(document_file_id);

                System.IO.File.Delete(Server.MapPath("~/Web/Files/" + DocumentFileData.file_location));

                if (sonuc)
                    sonuc = bFile.DeletOne(bConvert.ToInt32(item["file_id"]));

                if (sonuc)
                    sonuc = bDocumentFile.DeletOne(document_file_id);

                if (!sonuc)
                    return false;
            }
            ////////////////////////////////////

            if (sonuc)
                sonuc = bRequisition.DeletOne(requisition_id);

            return sonuc;
            #endregion
        }

        public void FillForm()
        {
            CRequisition RequisitionData = bRequisition.BrowseOne(requisition_id);

            if (RequisitionData == null || RequisitionData.requisition_id < 1)
            {
                lblMessage.Text = "Data not found.!";
                lblMessage.ForeColor = Color.Red;
                return;
            }


            lblPersonnelName.Text = RequisitionData.request_personnel_name;
            lblStatusName.Text = RequisitionData.status_name;
            dpRequestDate.SelectedDate = RequisitionData.request_date;
            dpPurchasedDate.SelectedDate = RequisitionData.purchased_date;
            txtComment.Text = bConvert.ToString(RequisitionData.comment);
            ddlResponsibleDepartment.SelectedValue = bConvert.ToString(RequisitionData.responsible_department_id);
            txtTotalPrice.Text = bConvert.ToString(RequisitionData.total_price);


            FillGridItem();
            CDepartment DepartmentData = bDepartment.BrowseOne(RequisitionData.responsible_department_id);


            imbApprove.Visible = imbReject.Visible =
                (DepartmentData.manager_personnel_id == Kullanici.personnel_id && RequisitionData.status == (int)bConstants.RequisitionStatus.Requested) ||
                (KullaniciRol.FleetManager && RequisitionData.status == (int)bConstants.RequisitionStatus.ApprovedDepartmentManager);


            imbPurchase.Visible = dpPurchasedDate.Enabled = (KullaniciRol.Purchase && RequisitionData.status == (int)bConstants.RequisitionStatus.ApprovedGeneralManager);

            imbDeleteAndExit.Visible =
            (
                RequisitionData.status != (int)bConstants.RequisitionStatus.Purchased &&
                (
                    KullaniciRol.Purchase ||
                    (RequisitionData.status == (int)bConstants.RequisitionStatus.Requested && Kullanici.department_id == RequisitionData.responsible_department_id)
                )
            );

            File.form_id = requisition_id;
        }

        public bool SaveItem()
        {
            bool sonuc = false;
            if (requisition_id > 0)
            {
                CRequisitionItem RequisitionItemData = new CRequisitionItem();

                if (requisition_item_id > 0)
                {
                    RequisitionItemData = bRequisitionItem.BrowseOne(requisition_item_id);
                    if (RequisitionItemData == null || RequisitionItemData.requisition_item_id == 0)
                    {
                        lblMessage.Text = "Data not found!";
                        lblMessage.ForeColor = Color.Red;
                    }
                }

                RequisitionItemData.requisition_id = requisition_id;
                RequisitionItemData.stock_id = bConvert.ToInt32(ddlStock.SelectedValue);
                RequisitionItemData.unit_price = bConvert.ToDecimal(txtUnitPrice.Text);
                RequisitionItemData.quantity = bConvert.ToInt32(txtQuantity.Text);

                if (requisition_item_id > 0)
                    sonuc = bRequisitionItem.Update(RequisitionItemData);
                else
                    sonuc = bRequisitionItem.Insert(RequisitionItemData);

                if (sonuc)
                {
                    CRequisitionItem RequisitionItemData2 = new CRequisitionItem();
                    RequisitionItemData2.requisition_id = requisition_id;
                    DataTable dt = bRequisitionItem.Search(RequisitionItemData2);

                    decimal total = 0;
                    foreach (DataRow item in dt.Rows)
                    {
                        total += bConvert.ToDecimal(item["unit_price"]) * bConvert.ToDecimal(item["quantity"]);
                    }

                    txtTotalPrice.Text = bConvert.ToString(total);
                }

            }
            else
            {
                DataRow drRequisitionItem;
                if (requisition_item_id == 0)
                {
                    drRequisitionItem = dtRequisitionItem.NewRow();

                    if (dtRequisitionItem.Rows.Count == 0)
                        drRequisitionItem["requisition_item_id"] = -1;
                    else
                    {
                        DataRow lastRow = dtRequisitionItem.Rows[dtRequisitionItem.Rows.Count - 1];
                        drRequisitionItem["requisition_item_id"] = bConvert.ToInt32(lastRow["requisition_item_id"]) - 1;
                    }
                }
                else
                {
                    drRequisitionItem = dtRequisitionItem.Select("requisition_item_id = '" + requisition_item_id + "'").FirstOrDefault();
                }

                drRequisitionItem["stock_category_id"] = bConvert.ToInt32(ddlStockCategory.SelectedValue);
                drRequisitionItem["stock_id"] = bConvert.ToInt32(ddlStock.SelectedValue);
                drRequisitionItem["unit_price"] = bConvert.ToDecimal(txtUnitPrice.Text);
                drRequisitionItem["quantity"] = bConvert.ToInt32(txtQuantity.Text);
                drRequisitionItem["stock_name"] = ddlStock.SelectedItem.Text;
                drRequisitionItem["total_price"] = (bConvert.ToDecimal(txtUnitPrice.Text)) * (bConvert.ToInt32(txtQuantity.Text));


                if (requisition_item_id == 0)
                    dtRequisitionItem.Rows.Add(drRequisitionItem);

                sonuc = true;
            }

            if (sonuc)
            {
                lblMessage.Text = "Your data has been successfully saved.!";
                lblMessage.ForeColor = Color.Green;
            }
            else
            {
                lblMessage.Text = "An error occured while saving the data!";
                lblMessage.ForeColor = Color.Red;
            }

            if (sonuc)
            {
                decimal total_price = 0;
                foreach (DataRow item in dtRequisitionItem.Rows)
                {
                    total_price += bConvert.ToDecimal(item["total_price"]);
                }
                txtTotalPrice.Text = bConvert.ToString(total_price);
            }


            return sonuc;
        }

        public void ClearItem()
        {
            requisition_item_id = 0;

            ddlStockCategory.SelectedIndex = -1;
            ddlStock.SelectedIndex = -1;
            txtUnitPrice.Text = "";
            txtQuantity.Text = "";
            tgRequisitionItem.SelectedIndex = -1;
            imbItemCancel.Visible = false;
        }

        public void FillGridItem()
        {
            if (requisition_id > 0)
            {
                CRequisitionItem RequisitionItemData = new CRequisitionItem();
                RequisitionItemData.requisition_id = requisition_id;


                DataTable dt = bRequisitionItem.Search(RequisitionItemData);
                tgRequisitionItem.DataSource = dt;
                tgRequisitionItem.DataKeyNames = new string[] { "requisition_item_id" };
                tgRequisitionItem.SelectedIndex = -1;
                tgRequisitionItem.DataBind();
            }
            else
            {
                tgRequisitionItem.DataSource = dtRequisitionItem;
                tgRequisitionItem.DataKeyNames = new string[] { "requisition_item_id" };
                tgRequisitionItem.SelectedIndex = -1;
                tgRequisitionItem.DataBind();
            }

        }


        #endregion

        public enum ButtonType
        {
            Save,
            Approve,
            Reject,
            Purchase
        }



    }
}