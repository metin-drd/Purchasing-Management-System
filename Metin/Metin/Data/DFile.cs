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
    public class DFile
    {
        SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=DBMYPROJECT; Integrated Security=true;");

        public int Insert(CFile FileData)
        {
            SqlCommand cmd = new SqlCommand("HSP_TFile_Insert", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@document_file_id", FileData.document_file_id);
            cmd.Parameters.AddWithValue("@requisition_id", FileData.requisition_id);
            cmd.Parameters.AddWithValue("@comment", FileData.comment);
            cmd.Parameters.AddWithValue("@safety_id", FileData.safety_id);

            conn.Open();
            int result = 0;
            try
            {
                result = (Int32)(sqlFunctions.sqlNullValueAssigner(cmd).ExecuteScalar());
            }
            catch
            {
                result = 0;
            }
            conn.Close();
            return result;
        }

        public bool Update(CFile FileData)
        {
            SqlCommand cmd = new SqlCommand("HSP_TFile_Update", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@file_id", FileData.file_id);
            cmd.Parameters.AddWithValue("@document_file_id", FileData.document_file_id);
            cmd.Parameters.AddWithValue("@commen", FileData.comment);
            cmd.Parameters.AddWithValue("@requisition_id", FileData.requisition_id);

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

        public bool Delete(CFile FileData)
        {
            SqlCommand cmd = new SqlCommand("HSP_TFile_Delete", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@file_id", FileData.file_id);

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

        public DataTable Browse(CFile FileData)
        {

            SqlCommand cmd = new SqlCommand("HSP_TFile_Browse", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@file_id", FileData.file_id);

            conn.Open();

            DataTable dt = new DataTable();
            SqlDataReader reader = sqlFunctions.sqlNullValueAssigner(cmd).ExecuteReader(); 
            dt.Load(reader);
            conn.Close();
            return dt;
        }

        public DataTable Search(CFile FileData)
        {

            SqlCommand cmd = new SqlCommand("HSP_TFile_Search", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@requisition_id", FileData.requisition_id);
            cmd.Parameters.AddWithValue("@safety_id", FileData.safety_id);
            
            conn.Open();

            DataTable dt = new DataTable();
            SqlDataReader reader = sqlFunctions.sqlNullValueAssigner(cmd).ExecuteReader(); 
            dt.Load(reader);
            conn.Close();
            return dt;
        }

    }
}