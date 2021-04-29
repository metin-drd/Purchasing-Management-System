using Metin.Command;
using Metin.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Metin.Data
{
    public class DDocumentFile
    {
        SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=DBMYPROJECT; Integrated Security=true;");

        public int Insert(CDocumentFile DocumentFileData)
        {
            SqlCommand cmd = new SqlCommand("HSP_TDocumentFile_Insert", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@file_location", DocumentFileData.file_location);

            conn.Open();
            int result = 0;
            try
            {
                result = (Int32)(sqlFunctions.sqlNullValueAssigner(cmd).ExecuteScalar());
            }
            catch (Exception ex)
            {
                result = 0;
            }
            conn.Close();
            return result;
        }

        public bool Update(CDocumentFile DocumentFileData)
        {
            SqlCommand cmd = new SqlCommand("HSP_TDocumentFile_Update", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@document_file_id", DocumentFileData.document_file_id);
            cmd.Parameters.AddWithValue("@file_location", DocumentFileData.file_location);

            conn.Open();
            int result = 0;

            try
            {
                result = sqlFunctions.sqlNullValueAssigner(cmd).ExecuteNonQuery();
            }
            catch
            {
                result = 0;
            }
            conn.Close();

            if (0 < result)
                return true;
            else
                return false;

        }

        public bool Delete(CDocumentFile DocumentFileData)
        {
            SqlCommand cmd = new SqlCommand("HSP_TDocumentFile_Delete", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@document_file_id", DocumentFileData.document_file_id);

            conn.Open();
            int result = 0;

            try
            {
                result = sqlFunctions.sqlNullValueAssigner(cmd).ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                result = 0;
            }
            conn.Close();

            if (0 < result)
                return true;
            else
                return false;
        }

        public DataTable Browse(CDocumentFile DocumentFileData)
        {

            SqlCommand cmd = new SqlCommand("HSP_TDocumentFile_Browse", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@document_file_id", DocumentFileData.document_file_id);

            conn.Open();

            DataTable dt = new DataTable();
            SqlDataReader reader = sqlFunctions.sqlNullValueAssigner(cmd).ExecuteReader();
            dt.Load(reader);
            conn.Close();
            return dt;

        }

        //public DataTable Search(CDocumentFile DocumentFileData)  /// altyapı değişitiği için kaldırıldı
        //{
        //    SqlCommand cmd = new SqlCommand("HSP_TDocumentFile_Search", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;

        //    cmd.Parameters.AddWithValue("@requisition_id", DocumentFileData.requisition_id);

        //    conn.Open();

        //    DataTable dt = new DataTable();
        //    SqlDataReader reader = sqlFunctions.sqlNullValueAssigner(cmd).ExecuteReader();
        //    dt.Load(reader);
        //    conn.Close();
        //    return dt;
        //}
    }
}