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
    public class DSabitDeger 
    {
        SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=DBMYPROJECT; Integrated Security=true;");

        public DataTable Search(CSabitDeger SabitDegerData)
        {

            SqlCommand cmd = new SqlCommand("HSP_TSabitDeger_Search", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@sabit_deger_listesi_id", SabitDegerData.sabit_deger_listesi_id);

            conn.Open();

            DataTable dt = new DataTable();
            SqlDataReader reader = sqlFunctions.sqlNullValueAssigner(cmd).ExecuteReader(); 
            dt.Load(reader);
            conn.Close();
            return dt;
        }
    }
}