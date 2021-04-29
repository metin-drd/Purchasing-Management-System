using Metin.Business;
using Metin.Command;
using Metin.Utility;
using Metin.Web.UserControls;
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
    public partial class SafetyList : BaseWeb
    {
        #region Properties
        public int safety_id
        {
            get { return bConvert.ToInt32(ViewState["safety_id"]); }
            set { ViewState["safety_id"] = value; }
        }


        #endregion

        #region General
        BSafety _bSafety = null;
        BSafety bSafety
        {
            get
            {
                if (_bSafety == null)
                    _bSafety = new BSafety();

                return _bSafety;
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

        BVesselApproval _bVesselApproval = null;
        BVesselApproval bVesselApproval
        {
            get
            {
                if (_bVesselApproval == null)
                    _bVesselApproval = new BVesselApproval();

                return _bVesselApproval;
            }
        }

        #endregion

        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                trVesselApproval.Visible = false;
                trGrid.Visible = false;

                safety_id = bConvert.ToInt32(Request.QueryString["safety_id"]);

                bFill.Vessel(ddlVesselDepartment, null, bConstants.FillTypes.Choose);
                rdoVessel.Checked = true;
                imbDeleteandExit.Visible = false;

                if (safety_id > 0)
                {
                    FillForm();
                    GridList();
                }

                File.form_id_property_name = "safety_id";
                File.file_type =(int)bConstants.FileType.HSEQ;
            }
            lblMessage.Text = "";
        }
        #endregion

        #region Other Events

        #endregion

        #region Button Events

        protected void imbSave_Click(object sender, EventArgs e)
        {
            if (SaveForm())
                FillForm();
        }

        protected void imbSaveandExit_Click(object sender, EventArgs e)
        {
            if (SaveForm())
                Response.Redirect("SafetyList.aspx?is_saved=" + (short)bConstants.EvetHayir.Evet);

        }

        protected void imbCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("SafetyList.aspx");
        }

        protected void rdoVessel_CheckedChanged(object sender, EventArgs e)
        {
            FillDdl();
        }

        protected void rdoDepartment_CheckedChanged(object sender, EventArgs e)
        {
            FillDdl();
        }

        protected void imbDeleteandExit_Click(object sender, EventArgs e)
        {
            if (DeleteForm())
                Response.Redirect("SafetyList.aspx?is_deleted=" + (short)bConstants.EvetHayir.Evet);

        }

        protected void imbVesselApprovalSave_Click(object sender, EventArgs e)
        {
            SaveVesselApproval();
        }

        protected void tgVesselApproval_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selected_id = bConvert.ToInt32(tgVesselApproval.SelectedValue);

            CVesselApproval VesselApprovalData = new CVesselApproval();

            VesselApprovalData = bVesselApproval.BrowseOne(selected_id);


            if (VesselApprovalData.vessel_id == WebCommon.VesselID || KullaniciRol.HSEQ)
            {
                dpClosed_Date.SelectedValue = VesselApprovalData.closed_date;
                txtVAComment.Text = VesselApprovalData.comment;
                trVesselApproval.Visible = true;
            }
            else
            {
                dpClosed_Date.SelectedValue = DateTime.MinValue;
                txtVAComment.Text = "";
                trVesselApproval.Visible = false;
            }
        }

        #endregion

        #region Functions

        public bool SaveForm()
        {
            #region Kontrol
            CSafety SafetyData = new CSafety();

            if (safety_id > 0)
            {
                SafetyData = bSafety.BrowseOne(safety_id);
                if (SafetyData == null || SafetyData.safety_id < 1)
                {
                    lblMessage.Text = "Data not found!";
                    lblMessage.ForeColor = Color.Red;
                    return false;
                }
            }
            #endregion

            #region Hazırlık

            SafetyData.comment = txtComment.Text;
            SafetyData.is_published = bConvert.ToInt16(cbxIsPublished.Checked);
            SafetyData.issued_date = bConvert.ToDateTime(dpIssuedDate.SelectedValue);
            SafetyData.safety_no = txtSafetyNo.Text;
            SafetyData.subject = txtSubject.Text;
            SafetyData.is_published = cbxIsPublished.Checked ? (short)bConstants.EvetHayir.Evet : (short)bConstants.EvetHayir.Hayir;

            if (rdoDepartment.Checked)
                SafetyData.department_id = bConvert.ToInt32(ddlVesselDepartment.SelectedValue);
            else if (rdoVessel.Checked)
                SafetyData.vessel_id = bConvert.ToInt32(ddlVesselDepartment.SelectedValue);
            #endregion

            #region Kayıt

            bool sonuc = true;

            try
            {
                if (safety_id > 0)
                    sonuc = bSafety.Update(SafetyData);

                else
                {
                    sonuc = bSafety.Insert(SafetyData);

                    if (sonuc)
                        File.SaveUCFile(bSafety.ReturnValue);


                }
            }
            catch (Exception ex)
            {

                throw;
            }

            if (sonuc)
            {
                lblMessage.Text = "Your data has been successfully saved.!";
                lblMessage.ForeColor = Color.Green;
                if (safety_id == 0)
                    safety_id = bSafety.ReturnValue;
            }
            else
            {
                lblMessage.Text = "An error occured while saving the data!";
                lblMessage.ForeColor = Color.Red;
            }

            return sonuc;
            #endregion
        }

        public void FillDdl()
        {
            if (rdoVessel.Checked)
                bFill.Vessel(ddlVesselDepartment, null, bConstants.FillTypes.Choose);
            else
                bFill.Department(ddlVesselDepartment, null, bConstants.FillTypes.Choose);
        }

        public void FillForm()
        {
            CSafety SafetyData = bSafety.BrowseOne(safety_id);
            if (SafetyData == null || SafetyData.safety_id < 1)
            {
                lblMessage.Text = "Data not found!";
                lblMessage.ForeColor = Color.Red;
                return;
            }
            File.form_id = safety_id;

            txtComment.Text = SafetyData.comment;
            dpIssuedDate.SelectedValue = SafetyData.issued_date;
            txtSafetyNo.Text = SafetyData.safety_no;
            txtSubject.Text = SafetyData.subject;
            cbxIsPublished.Checked = SafetyData.is_published == (short)bConstants.EvetHayir.Evet ? true : false;

            if (WebCommon.VesselID > 0)
            {
                CVessel VesselData = new CVessel();
                BVessel bVessel = new BVessel();
                VesselData = bVessel.BrowseOne(WebCommon.VesselID);
                lblVesselName.Text = VesselData.ship_name;
            }

            if (SafetyData.vessel_id > 0)
            {
                rdoDepartment.Checked = true;
                bFill.Department(ddlVesselDepartment, null, bConstants.FillTypes.Choose);
            }
            else if (SafetyData.department_id > 0)
            {
                rdoVessel.Checked = true;
                bFill.Vessel(ddlVesselDepartment, null, bConstants.FillTypes.Choose);
            }

            imbDeleteandExit.Visible = true;


            if (WebCommon.VesselID > 0 && safety_id > 0)
            {
                CVesselApproval VesselApprovalData = new CVesselApproval();
                VesselApprovalData.safety_id = safety_id;
                VesselApprovalData.vessel_id = WebCommon.VesselID;
                DataTable dt = bVesselApproval.Search(VesselApprovalData);

                if (dt.Rows.Count == 0)
                {
                    trVesselApproval.Visible = true;
                    dpClosed_Date.SelectedValue = DateTime.Now;
                }
            }

        }

        public bool DeleteForm()
        {
            #region Kontrol

            if (safety_id == 0)
                return false;

            #endregion

            #region Sil
            bool sonuc = true;

            if (sonuc)
            {
                CDocumentFile DocumentFileData = new CDocumentFile();
                BDocumentFile bDocumentFile = new BDocumentFile();

                CFile FileData = new CFile();
                FileData.safety_id = safety_id;
                BFile bFile = new BFile();
                DataTable dt = bFile.Search(FileData);

                foreach (DataRow item in dt.Rows)
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
            }
            else
            {
                lblMessage.ForeColor = Color.Red;
                lblMessage.Text = "An error occured while deleting the data!";
            }

            if (sonuc)
            {
                CVesselApproval VesselApprovalData = new CVesselApproval();
                VesselApprovalData.safety_id = safety_id;
                DataTable dt = bVesselApproval.Search(VesselApprovalData);

                foreach (DataRow item in dt.Rows)
                {
                    if (sonuc)
                        sonuc = bVesselApproval.DeletOne(bConvert.ToInt32(item["vessel_approval_id"]));

                    if (!sonuc)
                        return false;
                }
            }

            if (sonuc)
                sonuc = bSafety.DeletOne(safety_id);

            return sonuc;

            #endregion
        }

        public bool SaveVesselApproval()
        {
            bool sonuc = true;
            if (safety_id > 0)
            {
                CVesselApproval VesselApprovalData = new CVesselApproval();

                if (dpClosed_Date.SelectedValue == DateTime.MinValue)
                    dpClosed_Date.SelectedValue = DateTime.Now;


                VesselApprovalData.closed_date = bConvert.ToDateTime(dpClosed_Date.SelectedValue);
                VesselApprovalData.comment = txtVAComment.Text;
                VesselApprovalData.safety_id = safety_id;
                VesselApprovalData.vessel_id = WebCommon.VesselID;



                if (sonuc)
                {
                    sonuc = bVesselApproval.Insert(VesselApprovalData);
                    GridList();

                    dpClosed_Date.SelectedValue = DateTime.MinValue;
                    txtVAComment.Text = "";

                    trVesselApproval.Visible = false;
                    trGrid.Visible = true;
                }
            }
            return sonuc;
        }

        public void GridList()
        {
            if (safety_id > 0)
            {
                CVesselApproval TVesselApprovalData = new CVesselApproval();
                TVesselApprovalData.safety_id = safety_id;

                DataTable dt = bVesselApproval.Search(TVesselApprovalData);
                tgVesselApproval.DataSource = dt;
                tgVesselApproval.DataKeyNames = new string[] { "vessel_approval_id" };
                tgVesselApproval.SelectedIndex = -1;
                tgVesselApproval.DataBind();

                DataTable dtUnapprovedShips = bVesselApproval.UnapprovedShips(safety_id);

                if (dtUnapprovedShips.Rows.Count > 0)
                {
                    trUnapprovedShips.Visible = true;
                    lblUnapprovedShips.Text = "Unapproved Ships = ";
                    int dongu = 0;
                    foreach (DataRow item in dtUnapprovedShips.Rows)
                    {
                        if (dongu == 0)
                            lblUnapprovedShips.Text += bConvert.ToString(item["ship_name"]);
                        else
                            lblUnapprovedShips.Text += ", " + bConvert.ToString(item["ship_name"]);
                        dongu++;
                    }
                }
                else
                    trUnapprovedShips.Visible = false;

                if (dt.Rows.Count > 0)
                    trGrid.Visible = true;
            }


        }

        #endregion


    }
}