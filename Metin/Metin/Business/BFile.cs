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
    public class BFile : BaseBusiness
    {
        private DFile dFile = new DFile();

        public bool Insert(CFile FileData)
        {
            ReturnValue = dFile.Insert(FileData);
            return ReturnValue > 0 ? true : false;
        }

        public bool Update(CFile FileData)
        {
            return dFile.Update(FileData);
        }

        public bool Delete(CFile FileData)
        {
            return dFile.Delete(FileData);
        }

        public DataTable Browse(CFile FileData)
        {
            return dFile.Browse(FileData);
        }

        public DataTable Search(CFile FileData)
        {
            return dFile.Search(FileData);
        }

        public CFile BrowseOne(int file_id)
        {
            if (file_id < 1)
                return null;


            CFile FileData = new CFile();
            FileData.file_id = file_id;

            DataTable dtFile = Browse(FileData);
            if (dtFile == null || dtFile.Rows.Count != 1)
                return null;

            FileData.FromDataRow(dtFile.Rows[0]);
            return FileData;
        }

        public bool DeletOne(int file_id)
        {
            if (file_id < 1)
                return false;

            CFile fileData = new CFile();
            fileData.file_id = file_id;

            return dFile.Delete(fileData);
        }

    }
}