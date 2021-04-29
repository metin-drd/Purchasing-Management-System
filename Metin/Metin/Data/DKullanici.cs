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
    public class DKullanici
    {
        SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=DBMYPROJECT; Integrated Security=true;");

        public int Insert(CKullanici KullaniciData)
        {
            SqlCommand cmd = new SqlCommand("HSP_TKullanici_Insert", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@personnel_id", KullaniciData.personnel_id);
            cmd.Parameters.AddWithValue("@kullanici_kodu", KullaniciData.kullanici_kodu);
            cmd.Parameters.AddWithValue("@sifre", KullaniciData.sifre);

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


        public bool Update(CKullanici KullaniciData)
        {
            SqlCommand cmd = new SqlCommand("HSP_TKullanici_Update", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@kullanici_id", KullaniciData.kullanici_id);
            cmd.Parameters.AddWithValue("@personnel_id", KullaniciData.personnel_id);
            cmd.Parameters.AddWithValue("@kullanici_kodu", KullaniciData.kullanici_kodu);
            cmd.Parameters.AddWithValue("@sifre", KullaniciData.sifre);


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

        public bool Delete(CKullanici KullaniciData)
        {
            SqlCommand cmd = new SqlCommand("HSP_TKullanici_Delete", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@kullanici_id", KullaniciData.kullanici_id);

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

        public DataTable Browse(CKullanici KullaniciData)
        {

            SqlCommand cmd = new SqlCommand("HSP_TKullanici_Browse", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@kullanici_id", KullaniciData.kullanici_id);

            conn.Open();

            DataTable dt = new DataTable();
            SqlDataReader reader = sqlFunctions.sqlNullValueAssigner(cmd).ExecuteReader(); //Yani SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
            conn.Close();
            return dt;

        }


        public DataTable Search(CKullanici KullaniciData)
        {

            SqlCommand cmd = new SqlCommand("HSP_TKullanici_Search", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@kullanici_kodu", KullaniciData.kullanici_kodu);
            cmd.Parameters.AddWithValue("@personnel_id", KullaniciData.personnel_id);

            conn.Open();


            DataTable dt = new DataTable();
            SqlDataReader reader = sqlFunctions.sqlNullValueAssigner(cmd).ExecuteReader(); //Yani SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
            conn.Close();
            return dt;
        }

        public DataTable Login(string kullanici_kodu, string sifre)
        {
            SqlCommand cmd = new SqlCommand("HSP_TKullanici_Login", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@kullanici_kodu", kullanici_kodu);
            cmd.Parameters.AddWithValue("@sifre", sifre);

            conn.Open();

            DataTable dt = new DataTable();
            SqlDataReader reader = sqlFunctions.sqlNullValueAssigner(cmd).ExecuteReader(); //Yani SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
            conn.Close();
            return dt;

        }
    }
}