using Metin.Command;
using Metin.Data;
using Metin.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Metin.Business
{
    public class BDocumentFile : BaseBusiness
    {

        public DDocumentFile dDocumentFile = new DDocumentFile();

        public bool Insert(CDocumentFile DocumentFileData)
        {
            ReturnValue = dDocumentFile.Insert(DocumentFileData);
            return ReturnValue > 0 ? true : false;
        }

        public bool Update(CDocumentFile DocumentFileData)
        {
            return dDocumentFile.Update(DocumentFileData);
        }

        public bool Delete(CDocumentFile DocumentFileData)
        {
            return dDocumentFile.Delete(DocumentFileData);
        }

        public DataTable Search(CDocumentFile DocumentFileData)
        {
            return null;

            // dDocumentFile.Search(DocumentFileData);           altyapı değiştiği için yorum satırı yapılıdı
        }

        public DataTable Browse(CDocumentFile DocumentFileData)
        {
            return dDocumentFile.Browse(DocumentFileData);
        }

        public CDocumentFile BrowseOne(int document_file_id)
        {
            if (document_file_id < 1)
                return null;

            CDocumentFile DocumentFileData = new CDocumentFile();
            DataTable dtDocumentFile = new DataTable();

            DocumentFileData.document_file_id = document_file_id;
            dtDocumentFile = dDocumentFile.Browse(DocumentFileData);

            if (dtDocumentFile == null || dtDocumentFile.Rows.Count == 0)
                return null;

            DocumentFileData.FromDataRow(dtDocumentFile.Rows[0]);
            return DocumentFileData;
        }

        public bool DeletOne(int document_file_id)
        {
            if (document_file_id < 1)
                return false;

            CDocumentFile DocumentFile = new CDocumentFile();
            DocumentFile.document_file_id = document_file_id;

            return dDocumentFile.Delete(DocumentFile);
        }



    }
}