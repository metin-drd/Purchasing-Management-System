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
    public class DStock
    {
        SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=DBMYPROJECT; Integrated Security=true;");

        public int Insert(CStock StockData)
        {
            SqlCommand cmd = new SqlCommand("HSP_TStock_Insert", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@stock_name", StockData.stock_name);
            cmd.Parameters.AddWithValue("@stock_category_id", StockData.stock_category_id);

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

        public bool Update(CStock StockData)
        {
            SqlCommand cmd = new SqlCommand("HSP_TStock_Update", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@stock_id", StockData.stock_id);
            cmd.Parameters.AddWithValue("@stock_name", StockData.stock_name);
            cmd.Parameters.AddWithValue("@stock_category_id", StockData.stock_category_id);

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

        public bool Delete(CStock StockData)
        {
            SqlCommand cmd = new SqlCommand("HSP_TStock_Delete", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@stock_id", StockData.stock_id);

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

        public DataTable Browse(CStock StockData)
        {

            SqlCommand cmd = new SqlCommand("HSP_TStock_Browse", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@stock_id", StockData.stock_id);

            conn.Open();

            DataTable dt = new DataTable();
            SqlDataReader reader = sqlFunctions.sqlNullValueAssigner(cmd).ExecuteReader(); 
            dt.Load(reader);
            conn.Close();
            return dt;
        }

        public DataTable Search(CStock StockData)
        {

            SqlCommand cmd = new SqlCommand("HSP_TStock_Search", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@stock_name", StockData.stock_name);
            cmd.Parameters.AddWithValue("@stock_category_id", StockData.stock_category_id);

            conn.Open();

            DataTable dt = new DataTable();
            SqlDataReader reader = sqlFunctions.sqlNullValueAssigner(cmd).ExecuteReader(); 
            dt.Load(reader);
            conn.Close();
            return dt;

            
         }

    }
}