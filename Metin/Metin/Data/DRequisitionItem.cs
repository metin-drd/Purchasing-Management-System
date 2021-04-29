using Metin.Utility;
using Metin.Command;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Metin.Data
{
    public class DRequisitionItem
    {
        SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=DBMYPROJECT; Integrated Security=true;");

        public int Insert(CRequisitionItem RequisitionItemData)
        {
            SqlCommand cmd = new SqlCommand("HSP_TRequisitionItem_Insert", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@requisition_id", RequisitionItemData.requisition_id);
            cmd.Parameters.AddWithValue("@stock_id", RequisitionItemData.stock_id);
            cmd.Parameters.AddWithValue("@unit_price", RequisitionItemData.unit_price);
            cmd.Parameters.AddWithValue("@quantity", RequisitionItemData.quantity);

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

        public bool Update(CRequisitionItem RequisitionItemData)
        {
            SqlCommand cmd = new SqlCommand("HSP_TRequisitionItem_Update", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@requisition_item_id", RequisitionItemData.requisition_item_id);
            cmd.Parameters.AddWithValue("@requisition_id", RequisitionItemData.requisition_id);
            cmd.Parameters.AddWithValue("@stock_id", RequisitionItemData.stock_id);
            cmd.Parameters.AddWithValue("@unit_price", RequisitionItemData.unit_price);
            cmd.Parameters.AddWithValue("@quantity", RequisitionItemData.quantity);

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

        public bool Delete(CRequisitionItem RequisitionItemData)
        {
            SqlCommand cmd = new SqlCommand("HSP_TRequisitionItem_Delete", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@requisition_item_id", RequisitionItemData.requisition_item_id);

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

        public DataTable Browse(CRequisitionItem RequisitionItemData)
        {

            SqlCommand cmd = new SqlCommand("HSP_TRequisitionItem_Browse", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@requisition_item_id", RequisitionItemData.requisition_item_id);

            conn.Open();

            DataTable dt = new DataTable();
            SqlDataReader reader = sqlFunctions.sqlNullValueAssigner(cmd).ExecuteReader();
            dt.Load(reader);
            conn.Close();
            return dt;
        }

        public DataTable Search(CRequisitionItem RequisitionItemData)
        {

            SqlCommand cmd = new SqlCommand("HSP_TRequisitionItem_Search", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@stock_id", RequisitionItemData.stock_id);
            cmd.Parameters.AddWithValue("@requisition_id", RequisitionItemData.requisition_id);

            conn.Open();

            DataTable dt = new DataTable();
            SqlDataReader reader = sqlFunctions.sqlNullValueAssigner(cmd).ExecuteReader(); 
            dt.Load(reader);
            conn.Close();
            return dt;
        }
    }
}