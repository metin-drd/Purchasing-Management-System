using Metin.Business;
using Metin.Command;
using Metin.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Metin.Web.UserControls
{
    public partial class ucFile : System.Web.UI.UserControl
    {
        #region Properties
        private int _form_id;
        public int form_id
        {
            get
            {
                if (_form_id < 1)
                    _form_id = bConvert.ToInt32(ViewState["form_id"]);

                return _form_id;
            }
            set { ViewState["form_id"] = value; }
        }

        private int _file_type;
        public int file_type
        {
            get
            {
                if (_file_type < 1)
                    _file_type = bConvert.ToInt32(ViewState["file_type"]);

                return _file_type;
            }
            set { ViewState["file_type"] = value; }
        }

        private string _form_id_property_name;
        public string form_id_property_name
        {
            get
            {
                if (string.IsNullOrEmpty(_form_id_property_name))
                    _form_id_property_name = bConvert.ToString(ViewState["form_id_property_name"]);

                return _form_id_property_name;
            }
            set { ViewState["form_id_property_name"] = value; }
        }

        private DataTable _dtFile = null;
        public DataTable dtFile
        {
            get
            {
                if (_dtFile == null && ViewState["dtFile"] == null)
                {
                    _dtFile = new DataTable();
                    _dtFile.Columns.Add("file_id", typeof(int));
                    _dtFile.Columns.Add("file_location", typeof(string));
                    _dtFile.Columns.Add("comment", typeof(string));

                    ViewState["dtFile"] = _dtFile;
                }

                if (_dtFile == null)
                    _dtFile = ViewState["dtFile"] as DataTable;

                return _dtFile;
            }
            set
            {
                ViewState["dtFile"] = value;
            }
        }

        public int file_id
        {
            get { return bConvert.ToInt32(ViewState["file_id"]); }
            set { ViewState["file_id"] = value; }
        }
        #endregion

        #region Genel

        BFile _bFile = null;
        public BFile bFile
        {
            get
            {
                if (_bFile == null)
                    _bFile = new BFile();

                return _bFile;
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

        #region Page Load
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!IsPostBack)
            {
                if (string.IsNullOrEmpty(form_id_property_name))
                {
                    return;
                }
                else
                {
                    GridList();
                }

            }
        }
        #endregion

        #region Button Events
        protected void imbDocumentSave_Click(object sender, EventArgs e)
        {
            SaveFileData();
        }
        #endregion

        #region Grid Related

        protected void tgDocumentFile_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region Delete
            if (e.CommandName == "btnFileDelete")
            {
                int rowIndex = bConvert.ToInt32(e.CommandArgument);
                int selected_file_id = bConvert.ToInt32(tgDocumentFile.DataKeys[rowIndex].Values["file_id"]);
                string file_location = "";
                bool sonuc = false;

                if (selected_file_id > 0)
                {
                    CFile FileData = bFile.BrowseOne(selected_file_id);
                    if (FileData == null || FileData.file_id < 1)
                    {
                        // lblMessage.Text = "Data not found!";
                        // lblMessage.ForeColor = Color.Red;
                        return;
                    }

                    string file_type_name = ((bConstants.FileType)file_type).ToString();
                    CDocumentFile DocumentFileData = new CDocumentFile();
                    DocumentFileData = bDocumentFile.BrowseOne(FileData.document_file_id);
                    file_location = DocumentFileData.file_location;

                    sonuc = bFile.DeletOne(selected_file_id);

                    if (sonuc)
                    {
                        sonuc = bDocumentFile.DeletOne(FileData.document_file_id);
                        File.Delete(Server.MapPath("~/Web/Files/" + file_type_name + "/" + file_location));
                    }
                }

                else
                {
                    DataRow dr = dtFile.Select("file_id = '" + selected_file_id + "'").FirstOrDefault();
                    if (dr == null)
                        sonuc = false;
                    else
                    {
                        string file_type_name = ((bConstants.FileType)file_type).ToString();
                        File.Delete(Server.MapPath("~/Web/Files/" + file_type_name + "/" + dr["file_location"].ToString()));

                        dtFile.Rows.Remove(dr);
                        sonuc = true;
                    }

                }

                if (sonuc)
                {
                    // lblMessage.ForeColor = Color.Green;
                    //lblMessage.Text = "Your data has been successfully deleted.!";
                    GridList();
                }
                else
                {
                    //lblMessage.ForeColor = Color.Red;
                    // lblMessage.Text = "An error occured while deleting the data!";
                }
            }
            #endregion

            #region Open
            if (e.CommandName == "btnOpenFile")
            {
                int rowIndex = bConvert.ToInt32(e.CommandArgument);
                string selected_file_location = bConvert.ToString(tgDocumentFile.DataKeys[rowIndex].Values["file_location"]);
                string file_type_name = ((bConstants.FileType)file_type).ToString();

                Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('../Web/Files/" + file_type_name + "/" + selected_file_location + "', '_newtab');", true);

            }
            #endregion

        }
        #endregion

        #region Functions
        private string UploadFile()
        {
            string file_type_name = ((bConstants.FileType)file_type).ToString();


            if (!txtDocumentFileUpload.Visible)
                return "";
            else if (txtDocumentFileUpload.PostedFile.ContentLength < 1)
                return "";
            else
            {
                string postedfilename = txtDocumentFileUpload.PostedFile.FileName;
                string filename = Server.MapPath("~/Web/Files/" + file_type_name + "/") + DateTime.Now.Ticks + postedfilename.Substring(postedfilename.LastIndexOf("."));

                string dosya_adi = filename.Substring(filename.LastIndexOf("\\") + 1);
                byte[] postedfile = new byte[txtDocumentFileUpload.PostedFile.ContentLength];
                txtDocumentFileUpload.PostedFile.InputStream.Read(postedfile, 0, txtDocumentFileUpload.PostedFile.ContentLength);

                System.IO.FileStream fs = System.IO.File.Create(filename);
                if (fs == null)
                {
                    //lblMessage.Text = "File cannot be created!";
                    // lblMessage.ForeColor = Color.Red;
                    return "";
                }

                fs.Write(postedfile, 0, postedfile.Length);
                fs.Flush();
                fs.Close();
                fs = null;
                return dosya_adi;
            }
        }

        public void GridList()
        {
            CFile FileData = new CFile();
            bMethods.SetPropertyValue(FileData, form_id_property_name, form_id);
            DataTable dt;

            if (form_id > 0)
                dt = bFile.Search(FileData);

            else
                dt = dtFile;

            tgDocumentFile.DataSource = dt;
            tgDocumentFile.DataKeyNames = new string[] { "file_id", "file_location" };
            tgDocumentFile.SelectedIndex = -1;
            tgDocumentFile.DataBind();
        }

        public bool SaveFileData()
        {
            int return_document_id;

            #region Kontrol
            CFile FileData = new CFile();

            if (file_id > 0)
            {
                FileData = bFile.BrowseOne(file_id);
                if (FileData == null || FileData.file_id < 1)
                {
                    return false;
                }
            }
            #endregion

            #region Kayıt

            string file_location = UploadFile();
            bool sonuc = true;

            if (string.IsNullOrEmpty(file_location))
            {
                //lblMessage.Text = "Data not found!";
                //lblMessage.ForeColor = Color.Red;
            }

            else if (form_id > 0)
            {
                CDocumentFile DocumentFileData = new CDocumentFile();

                DocumentFileData.file_location = file_location;
                sonuc = bDocumentFile.Insert(DocumentFileData);
                if (sonuc)
                {
                    return_document_id = bDocumentFile.ReturnValue;

                    bMethods.SetPropertyValue(FileData, form_id_property_name, form_id);
                    FileData.comment = txtDocumentComment.Text;
                    FileData.document_file_id = return_document_id;

                    sonuc = bFile.Insert(FileData);

                }
                GridList();
            }

            else
            {
                DataRow drFile;
                if (file_id == 0)
                {
                    drFile = dtFile.NewRow();

                    if (dtFile.Rows.Count == 0)
                        drFile["file_id"] = -1;
                    else
                    {
                        DataRow lastRow = dtFile.Rows[dtFile.Rows.Count - 1];
                        drFile["file_id"] = bConvert.ToInt32(lastRow["file_id"]) - 1;
                    }
                }
                else
                {
                    drFile = dtFile.Select("file_id = '" + file_id + "'").FirstOrDefault();
                }

                drFile["file_location"] = file_location;
                drFile["comment"] = txtDocumentComment.Text;
                bMethods.SetPropertyValue(FileData, form_id_property_name, form_id);


                if (file_id == 0)
                    dtFile.Rows.Add(drFile);

                sonuc = true;

                GridList();
            }

            if (sonuc)
            {
                //  lblMessage.Text = "Your data has been successfully saved.!";
                //  lblMessage.ForeColor = Color.Green; 
                txtDocumentComment.Text = "";
            }
            else
            {
                // lblMessage.Text = "An error occured while saving the data!";
                // lblMessage.ForeColor = Color.Red;
            }

            return sonuc;

            #endregion
        }

        public bool SaveUCFile(int new_form_id)
        {
            bool sonuc = true;

            CFile FileData = new CFile();
            CDocumentFile DocumentFileData = new CDocumentFile();

            foreach (DataRow item in dtFile.Rows)
            {
                DocumentFileData.file_location = bConvert.ToString(item["file_location"]);
                sonuc = bDocumentFile.Insert(DocumentFileData);

                FileData.comment = bConvert.ToString(item["comment"]);
                FileData.document_file_id = bDocumentFile.ReturnValue;
                bMethods.SetPropertyValue(FileData, form_id_property_name, new_form_id);
                sonuc = bFile.Insert(FileData);
                if (!sonuc)
                    break;
            }
            return sonuc;
        }

        public bool DeleteUCFile()
        {
            bool sonuc = true; ;

            CFile FileData = new CFile();

            bMethods.SetPropertyValue(FileData, form_id_property_name, form_id);

            if (form_id > 0)
            {
                DataTable dtFile = bFile.Search(FileData);

                foreach (DataRow item in dtFile.Rows)
                {
                    int document_file_id = bConvert.ToInt32(item["document_file_id"]);

                    CDocumentFile DocumentFileData = new CDocumentFile();
                    DocumentFileData = bDocumentFile.BrowseOne(document_file_id);
                    File.Delete(Server.MapPath("~/Web/Files/" + DocumentFileData.file_location));

                    if (sonuc)
                        sonuc = bFile.DeletOne(bConvert.ToInt32(item["file_id"]));

                    if (sonuc)
                        sonuc = bDocumentFile.DeletOne(document_file_id);

                    if (!sonuc)
                        return false;

                }
            }
            return sonuc;
        }
        #endregion

    }
}