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
    public class DVessel
    {

        SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=DBMYPROJECT; Integrated Security=true;");

        public int Insert(CVessel VesselData)
        {
            SqlCommand cmd = new SqlCommand("HSP_TVessel_Insert", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ship_name", VesselData.ship_name);
            cmd.Parameters.AddWithValue("@is_active", VesselData.is_active);
            cmd.Parameters.AddWithValue("@ship_acronym_name", VesselData.ship_acronym_name);

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

        public bool Update(CVessel VesselData)
        {
            SqlCommand cmd = new SqlCommand("HSP_TVessel_Update", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@vessel_id", VesselData.vessel_id);
            cmd.Parameters.AddWithValue("@ship_name", VesselData.ship_name);
            cmd.Parameters.AddWithValue("@is_active", VesselData.is_active);
            cmd.Parameters.AddWithValue("@ship_acronym_name", VesselData.ship_acronym_name);

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

        public bool Delete(CVessel VesselData)
        {
            SqlCommand cmd = new SqlCommand("HSP_TVessel_Delete", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@vessel_id", VesselData.vessel_id);

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

            if (result >0)
                return true;
            else
                return false;
        }

        public DataTable Browse(CVessel VesselData)
        {

            SqlCommand cmd = new SqlCommand("HSP_TVessel_Browse", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@vessel_id", VesselData.vessel_id);

            conn.Open();

            DataTable dt = new DataTable();
            SqlDataReader reader = sqlFunctions.sqlNullValueAssigner(cmd).ExecuteReader(); 
            dt.Load(reader);
            conn.Close();
            return dt;
        }

        public DataTable Search(CVessel VesselData)
        {

            SqlCommand cmd = new SqlCommand("HSP_TVessel_Search", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ship_name", VesselData.ship_name);
            cmd.Parameters.AddWithValue("@is_active", VesselData.is_active);
            cmd.Parameters.AddWithValue("@ship_acronym_name", VesselData.ship_acronym_name);

            conn.Open();

            DataTable dt = new DataTable();
            SqlDataReader reader = sqlFunctions.sqlNullValueAssigner(cmd).ExecuteReader(); 
            dt.Load(reader);
            conn.Close();
            return dt;
        }

    }
}