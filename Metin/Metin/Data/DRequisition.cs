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
    public class DRequisition
    {

        SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=DBMYPROJECT; Integrated Security=true;");

        public int Insert(CRequisition RequisitionData)
        {
            SqlCommand cmd = new SqlCommand("HSP_TRequisition_Insert", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@request_date", RequisitionData.request_date);
            cmd.Parameters.AddWithValue("@status", RequisitionData.status);
            cmd.Parameters.AddWithValue("@request_personnel_id", RequisitionData.request_personnel_id);
            cmd.Parameters.AddWithValue("@comment", RequisitionData.comment);
            cmd.Parameters.AddWithValue("@approved_purchasing_manager_id", RequisitionData.approved_purchasing_manager_id);
            cmd.Parameters.AddWithValue("@approved_purchasing_manager_date", RequisitionData.approved_purchasing_manager_date);
            cmd.Parameters.AddWithValue("@approved_genaral_manager_id", RequisitionData.approved_genaral_manager_id);
            cmd.Parameters.AddWithValue("@approved_genaral_manager_date", RequisitionData.approved_genaral_manager_date);
            cmd.Parameters.AddWithValue("@responsible_department_id", RequisitionData.responsible_department_id);
            cmd.Parameters.AddWithValue("@purchased_date", RequisitionData.purchased_date);


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

        public bool Update(CRequisition RequisitionData)
        {
            SqlCommand cmd = new SqlCommand("HSP_TRequisition_Update", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@requisition_id", RequisitionData.requisition_id);
            cmd.Parameters.AddWithValue("@request_date", RequisitionData.request_date);
            cmd.Parameters.AddWithValue("@status", RequisitionData.status);
            cmd.Parameters.AddWithValue("@request_personnel_id", RequisitionData.request_personnel_id);
            cmd.Parameters.AddWithValue("@comment", RequisitionData.comment);
            cmd.Parameters.AddWithValue("@approved_purchasing_manager_id", RequisitionData.approved_purchasing_manager_id);
            cmd.Parameters.AddWithValue("@approved_purchasing_manager_date", RequisitionData.approved_purchasing_manager_date);
            cmd.Parameters.AddWithValue("@approved_genaral_manager_id", RequisitionData.approved_genaral_manager_id);
            cmd.Parameters.AddWithValue("@approved_genaral_manager_date", RequisitionData.approved_genaral_manager_date);
            cmd.Parameters.AddWithValue("@purchased_date", RequisitionData.purchased_date);
            cmd.Parameters.AddWithValue("@responsible_department_id", RequisitionData.responsible_department_id);
            

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

        public bool Delete(CRequisition RequisitionData)
        {
            SqlCommand cmd = new SqlCommand("HSP_TRequisition_Delete", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@requisition_id", RequisitionData.requisition_id);

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

        public DataTable Browse(CRequisition RequisitionData)
        {
            SqlCommand cmd = new SqlCommand("HSP_TRequisition_Browse", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@requisition_id", RequisitionData.requisition_id);

            conn.Open();

            DataTable dt = new DataTable();
            SqlDataReader reader = sqlFunctions.sqlNullValueAssigner(cmd).ExecuteReader();
            dt.Load(reader);
            conn.Close();
            return dt;
        }

        public DataTable Search(CRequisition RequisitionData)
        {
            SqlCommand cmd = new SqlCommand("HSP_TRequisition_Search", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@status", RequisitionData.status);
            cmd.Parameters.AddWithValue("@start_date", RequisitionData.start_date);
            cmd.Parameters.AddWithValue("@end_date", RequisitionData.end_date);
            cmd.Parameters.AddWithValue("@responsible_department_id", RequisitionData.responsible_department_id);
            
            conn.Open();

            DataTable dt = new DataTable();
            SqlDataReader reader = sqlFunctions.sqlNullValueAssigner(cmd).ExecuteReader();
            dt.Load(reader);
            conn.Close();
            return dt;
        }

        public DataTable Report(CRequisition RequisitionData)
        {
            
            SqlCommand cmd = new SqlCommand("HSP_TRequisition_Report", conn);
            cmd.CommandType = CommandType.StoredProcedure;
          
            cmd.Parameters.AddWithValue("@start_date", RequisitionData.start_date);
            cmd.Parameters.AddWithValue("@end_date", RequisitionData.end_date);
            cmd.Parameters.AddWithValue("@report_type", RequisitionData.report_type);

       
            conn.Open();

            DataTable dt = new DataTable();
            SqlDataReader reader = sqlFunctions.sqlNullValueAssigner(cmd).ExecuteReader();
            dt.Load(reader);
            conn.Close();
            return dt;
        } 


    }
}