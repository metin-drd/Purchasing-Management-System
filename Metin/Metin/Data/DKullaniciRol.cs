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
    public class DKullaniciRol
    {
        SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=DBMYPROJECT; Integrated Security=true;");

        public int Insert(CKullaniciRol KullaniciRolData)
        {
            SqlCommand cmd = new SqlCommand("HSP_TKullaniciRol_Insert", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@kullanici_id", KullaniciRolData.kullanici_id);
            cmd.Parameters.AddWithValue("@rol", KullaniciRolData.rol);

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

        public bool Update(CKullaniciRol KullaniciRolData)
        {
            SqlCommand cmd = new SqlCommand("HSP_TKullaniciRol_Update", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@kullanici_rol_id", KullaniciRolData.kullanici_rol_id);
            cmd.Parameters.AddWithValue("@kullanici_id", KullaniciRolData.kullanici_id);
            cmd.Parameters.AddWithValue("@rol", KullaniciRolData.rol);

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

        public bool Delete(CKullaniciRol KullaniciRolData)
        {
            SqlCommand cmd = new SqlCommand("HSP_TKullaniciRol_Delete", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@kullanici_rol_id", KullaniciRolData.kullanici_rol_id);

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

        public DataTable Browse(CKullaniciRol KullaniciRolData)
        {

            SqlCommand cmd = new SqlCommand("HSP_TKullaniciRol_Browse", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@kullanici_rol_id", KullaniciRolData.kullanici_rol_id);

            conn.Open();

            DataTable dt = new DataTable();
            SqlDataReader reader = sqlFunctions.sqlNullValueAssigner(cmd).ExecuteReader();
            dt.Load(reader);
            conn.Close();
            return dt;
        }

        public DataTable Search(CKullaniciRol KullaniciRolData)
        {

            SqlCommand cmd = new SqlCommand("HSP_TKullaniciRol_Search", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@kullanici_id", KullaniciRolData.kullanici_id);
            cmd.Parameters.AddWithValue("@rol", KullaniciRolData.rol);

            conn.Open();

            DataTable dt = new DataTable();
            SqlDataReader reader = sqlFunctions.sqlNullValueAssigner(cmd).ExecuteReader();
            dt.Load(reader);
            conn.Close();
            return dt;
        }
    }
}