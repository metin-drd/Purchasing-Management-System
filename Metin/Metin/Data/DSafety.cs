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
    public class DSafety
    {
        SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=DBMYPROJECT; Integrated Security=true;");

        public int Insert(CSafety SafetyData)
        {
            SqlCommand cmd = new SqlCommand("HSP_TSafety_Insert", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@safety_no", SafetyData.safety_no);
            cmd.Parameters.AddWithValue("@issued_date", SafetyData.issued_date);
            cmd.Parameters.AddWithValue("@vessel_id", SafetyData.vessel_id);
            cmd.Parameters.AddWithValue("@department_id", SafetyData.department_id);
            cmd.Parameters.AddWithValue("@subject", SafetyData.subject);
            cmd.Parameters.AddWithValue("@comment", SafetyData.comment);
            cmd.Parameters.AddWithValue("@is_published", SafetyData.is_published);


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

        public bool Update(CSafety SafetyData)
        {
            SqlCommand cmd = new SqlCommand("HSP_TSafety_Update", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@safety_id", SafetyData.safety_id);
            cmd.Parameters.AddWithValue("@safety_no", SafetyData.safety_no);
            cmd.Parameters.AddWithValue("@issued_date", SafetyData.issued_date);
            cmd.Parameters.AddWithValue("@vessel_id", SafetyData.vessel_id);
            cmd.Parameters.AddWithValue("@department_id", SafetyData.department_id);
            cmd.Parameters.AddWithValue("@subject", SafetyData.subject);
            cmd.Parameters.AddWithValue("@comment", SafetyData.comment);
            cmd.Parameters.AddWithValue("@is_published", SafetyData.is_published);

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

        public bool Delete(CSafety SafetyData)
        {
            SqlCommand cmd = new SqlCommand("HSP_TSafety_Delete", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@safety_id", SafetyData.safety_id);

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

        public DataTable Browse(CSafety SafetyData)
        {

            SqlCommand cmd = new SqlCommand("HSP_TSafety_Browse", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@safety_id", SafetyData.safety_id);

            conn.Open();

            DataTable dt = new DataTable();
            SqlDataReader reader = sqlFunctions.sqlNullValueAssigner(cmd).ExecuteReader();
            dt.Load(reader);
            conn.Close();
            return dt;
        }

        public DataTable Search(CSafety SafetyData)
        {

            SqlCommand cmd = new SqlCommand("HSP_TSafety_Search", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@safety_no", SafetyData.safety_no);
            cmd.Parameters.AddWithValue("@issued_date", SafetyData.issued_date);
            cmd.Parameters.AddWithValue("@vessel_id", SafetyData.vessel_id);
            cmd.Parameters.AddWithValue("@department_id", SafetyData.department_id);
            cmd.Parameters.AddWithValue("@is_published", SafetyData.is_published);


            conn.Open();

            DataTable dt = new DataTable();
            SqlDataReader reader = sqlFunctions.sqlNullValueAssigner(cmd).ExecuteReader(); 
            dt.Load(reader);
            conn.Close();
            return dt;
        }

    }
}