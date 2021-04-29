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
    public class DPersonnel
    {
        SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=DBMYPROJECT; Integrated Security=true;");

        public int Insert(CPersonnel PersonnelData)
        {
            SqlCommand cmd = new SqlCommand("HSP_TPersonnel_Insert", conn);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@name", PersonnelData.name);
            cmd.Parameters.AddWithValue("@surname", PersonnelData.surname);
            cmd.Parameters.AddWithValue("@tc_no", PersonnelData.tc_no);
            cmd.Parameters.AddWithValue("@rank_id", PersonnelData.rank_id);
            cmd.Parameters.AddWithValue("@department_id", PersonnelData.department_id);
            cmd.Parameters.AddWithValue("@phone_number", PersonnelData.phone_number);
            cmd.Parameters.AddWithValue("@email", PersonnelData.email);
            cmd.Parameters.AddWithValue("@home_address", PersonnelData.home_address);
            cmd.Parameters.AddWithValue("@firm_date", PersonnelData.firm_date);
            cmd.Parameters.AddWithValue("@quit_date", PersonnelData.quit_date);

            conn.Open();
            int result = 0;
            try
            {
                result = (Int32) (sqlFunctions.sqlNullValueAssigner(cmd).ExecuteScalar());
            }
            catch
            {
                result = 0;
            }
            conn.Close();
            return result;
        }

        public bool Update(CPersonnel PersonnelData)
        {
            SqlCommand cmd = new SqlCommand("HSP_TPersonnel_Update", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@personnel_id", PersonnelData.personnel_id);
            cmd.Parameters.AddWithValue("@name", PersonnelData.name);
            cmd.Parameters.AddWithValue("@surname", PersonnelData.surname);
            cmd.Parameters.AddWithValue("@tc_no", PersonnelData.tc_no);
            cmd.Parameters.AddWithValue("@rank_id", PersonnelData.rank_id);
            cmd.Parameters.AddWithValue("@department_id", PersonnelData.department_id);
            cmd.Parameters.AddWithValue("@phone_number", PersonnelData.phone_number);
            cmd.Parameters.AddWithValue("@email", PersonnelData.email);
            cmd.Parameters.AddWithValue("@home_address", PersonnelData.home_address);
            cmd.Parameters.AddWithValue("@firm_date", PersonnelData.firm_date);
            cmd.Parameters.AddWithValue("@quit_date", PersonnelData.quit_date);

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

        public bool Delete(CPersonnel PersonnelData)
        {
            SqlCommand cmd = new SqlCommand("HSP_TPersonnel_Delete", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@personnel_id", PersonnelData.personnel_id);

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

        public DataTable Browse(CPersonnel PersonnelData)
        {

            SqlCommand cmd = new SqlCommand("HSP_TPersonnel_Browse", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@personnel_id", PersonnelData.personnel_id);

            conn.Open();

            DataTable dt = new DataTable();
            SqlDataReader reader = sqlFunctions.sqlNullValueAssigner(cmd).ExecuteReader(); //Yani SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
            conn.Close();
            return dt;
        }

        public DataTable Search(CPersonnel PersonnelData)
        {

            SqlCommand cmd = new SqlCommand("HSP_TPersonnel_Search", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@name", PersonnelData.name);
            cmd.Parameters.AddWithValue("@surname", PersonnelData.surname);
            cmd.Parameters.AddWithValue("@department_id", PersonnelData.department_id);
            cmd.Parameters.AddWithValue("@is_active", PersonnelData.is_active);

            conn.Open();

            DataTable dt = new DataTable();
            SqlDataReader reader = sqlFunctions.sqlNullValueAssigner(cmd).ExecuteReader(); //Yani SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
            conn.Close();
            return dt;
        }



    }
}