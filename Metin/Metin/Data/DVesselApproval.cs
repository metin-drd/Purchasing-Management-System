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
    public class DVesselApproval
    {
        SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=DBMYPROJECT; Integrated Security=true;");

        public int Insert(CVesselApproval CVesselApprovalData)
        {
            SqlCommand cmd = new SqlCommand("HSP_TVesselApproval_Insert", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@vessel_id", CVesselApprovalData.vessel_id);
            cmd.Parameters.AddWithValue("@closed_date", CVesselApprovalData.closed_date);
            cmd.Parameters.AddWithValue("@comment", CVesselApprovalData.comment);
            cmd.Parameters.AddWithValue("@safety_id", CVesselApprovalData.safety_id);

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

        public bool Update(CVesselApproval CVesselApprovalData)
        {
            SqlCommand cmd = new SqlCommand("HSP_TVesselApproval_Update", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@vessel_approval_id", CVesselApprovalData.vessel_approval_id);
            cmd.Parameters.AddWithValue("@vessel_id", CVesselApprovalData.vessel_id);
            cmd.Parameters.AddWithValue("@closed_date", CVesselApprovalData.closed_date);
            cmd.Parameters.AddWithValue("@comment", CVesselApprovalData.comment);
            cmd.Parameters.AddWithValue("@safety_id", CVesselApprovalData.safety_id);

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

        public bool Delete(CVesselApproval CVesselApprovalData)
        {
            SqlCommand cmd = new SqlCommand("HSP_TVesselApproval_Delete", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@vessel_approval_id", CVesselApprovalData.vessel_approval_id);

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

        public DataTable Browse(CVesselApproval CVesselApprovalData)
        {
            SqlCommand cmd = new SqlCommand("HSP_TVesselApproval_Browse", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@vessel_approval_id", CVesselApprovalData.vessel_approval_id);

            conn.Open();

            DataTable dt = new DataTable();
            SqlDataReader reader = sqlFunctions.sqlNullValueAssigner(cmd).ExecuteReader();
            dt.Load(reader);
            conn.Close();
            return dt;
        }

        public DataTable Search(CVesselApproval CVesselApprovalData)
        {
            SqlCommand cmd = new SqlCommand("HSP_TVesselApproval_Search", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@vessel_id", CVesselApprovalData.vessel_id);
            cmd.Parameters.AddWithValue("@closed_date", CVesselApprovalData.closed_date);
            cmd.Parameters.AddWithValue("@safety_id", CVesselApprovalData.safety_id);

            conn.Open();

            DataTable dt = new DataTable();
            SqlDataReader reader = sqlFunctions.sqlNullValueAssigner(cmd).ExecuteReader();
            dt.Load(reader);
            conn.Close();
            return dt;
        }

        public DataTable UnapprovedShips(int SafetyID)
        {
            SqlCommand cmd = new SqlCommand("HSP_TVesselApproval_Unapproved_Ships", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@safety_id", SafetyID);
            conn.Open();

            DataTable dt = new DataTable();
            SqlDataReader reader = sqlFunctions.sqlNullValueAssigner(cmd).ExecuteReader();
            dt.Load(reader);
            conn.Close();
            return dt;
        }

    }
}