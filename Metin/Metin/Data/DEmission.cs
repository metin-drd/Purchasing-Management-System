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
    public class DEmission
    {

        SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=DBMYPROJECT; Integrated Security=true;");

        public int Insert(CEmission EmissionData)
        {
            SqlCommand cmd = new SqlCommand("HSP_TEmission_Insert", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@vessel_id", EmissionData.vessel_id);
            cmd.Parameters.AddWithValue("@report_no", EmissionData.report_no);
            cmd.Parameters.AddWithValue("@departure_port_id", EmissionData.departure_port_id);
            cmd.Parameters.AddWithValue("@departure_left_berth_date", EmissionData.departure_left_berth_date);
            cmd.Parameters.AddWithValue("@departure_hsfo", EmissionData.departure_hsfo);
            cmd.Parameters.AddWithValue("@departure_lsfo", EmissionData.departure_lsfo);
            cmd.Parameters.AddWithValue("@departure_ulsfo", EmissionData.departure_ulsfo);
            cmd.Parameters.AddWithValue("@departure_lsmgo", EmissionData.departure_lsmgo);
            cmd.Parameters.AddWithValue("@arrival_port_id", EmissionData.arrival_port_id);
            cmd.Parameters.AddWithValue("@arrival_all_fast_date", EmissionData.arrival_all_fast_date);
            cmd.Parameters.AddWithValue("@arrival_hsfo", EmissionData.arrival_hsfo);
            cmd.Parameters.AddWithValue("@arival_lsfo", EmissionData.arival_lsfo);
            cmd.Parameters.AddWithValue("@arrival_ulsfo", EmissionData.arrival_ulsfo);
            cmd.Parameters.AddWithValue("@arrival_lsmgo", EmissionData.arrival_lsmgo);
            cmd.Parameters.AddWithValue("@departure_stemmed_hsfo", EmissionData.departure_stemmed_hsfo);
            cmd.Parameters.AddWithValue("@departure_stemmed_lsfo", EmissionData.departure_stemmed_lsfo);
            cmd.Parameters.AddWithValue("@departure_stemmed_ulsfo", EmissionData.departure_stemmed_ulsfo);
            cmd.Parameters.AddWithValue("@departure_stemmed_lsmgo", EmissionData.departure_stemmed_lsmgo);
            cmd.Parameters.AddWithValue("@distance_berth_to_berth", EmissionData.distance_berth_to_berth);
            cmd.Parameters.AddWithValue("@laden_ballast", EmissionData.laden_ballast);
            cmd.Parameters.AddWithValue("@type_of_cargo", EmissionData.type_of_cargo);
            cmd.Parameters.AddWithValue("@total_cargo_on_board", EmissionData.total_cargo_on_board);
            cmd.Parameters.AddWithValue("@last_departure_left_berth_date", EmissionData.last_departure_left_berth_date);
            cmd.Parameters.AddWithValue("@last_departure_lsfo", EmissionData.last_departure_lsfo);
            cmd.Parameters.AddWithValue("@last_departure_ulsfo", EmissionData.last_departure_ulsfo);
            cmd.Parameters.AddWithValue("@last_departure_lsmgo", EmissionData.last_departure_lsmgo);
            cmd.Parameters.AddWithValue("@last_departure_stemmed_hsfo", EmissionData.last_departure_stemmed_hsfo);
            cmd.Parameters.AddWithValue("@last_departure_stemmed_lsfo", EmissionData.last_departure_stemmed_lsfo);
            cmd.Parameters.AddWithValue("@last_departure_stemmed_ulsfo", EmissionData.last_departure_stemmed_ulsfo);
            cmd.Parameters.AddWithValue("@last_departure_stemmed_lsmgo", EmissionData.last_departure_stemmed_lsmgo);
            cmd.Parameters.AddWithValue("@sulphur_hsfo", EmissionData.sulphur_hsfo);
            cmd.Parameters.AddWithValue("@sulphur_lsfo", EmissionData.sulphur_lsfo);
            cmd.Parameters.AddWithValue("@sulphur_ulsfo", EmissionData.sulphur_ulsfo);
            cmd.Parameters.AddWithValue("@sulphur_lsmgo", EmissionData.sulphur_lsmgo);

            
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

        public bool Update(CEmission EmissionData)
        {
            SqlCommand cmd = new SqlCommand("HSP_TEmission_Update", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@emission_id", EmissionData.emission_id);
            cmd.Parameters.AddWithValue("@vessel_id", EmissionData.vessel_id);
            cmd.Parameters.AddWithValue("@report_no", EmissionData.report_no);
            cmd.Parameters.AddWithValue("@departure_port_id", EmissionData.departure_port_id);
            cmd.Parameters.AddWithValue("@departure_left_berth_date", EmissionData.departure_left_berth_date);
            cmd.Parameters.AddWithValue("@departure_hsfo", EmissionData.departure_hsfo);
            cmd.Parameters.AddWithValue("@departure_lsfo", EmissionData.departure_lsfo);
            cmd.Parameters.AddWithValue("@departure_ulsfo", EmissionData.departure_ulsfo);
            cmd.Parameters.AddWithValue("@departure_lsmgo", EmissionData.departure_lsmgo);
            cmd.Parameters.AddWithValue("@arrival_port_id", EmissionData.arrival_port_id);
            cmd.Parameters.AddWithValue("@arrival_all_fast_date", EmissionData.arrival_all_fast_date);
            cmd.Parameters.AddWithValue("@arrival_hsfo", EmissionData.arrival_hsfo);
            cmd.Parameters.AddWithValue("@arival_lsfo", EmissionData.arival_lsfo);
            cmd.Parameters.AddWithValue("@arrival_ulsfo", EmissionData.arrival_ulsfo);
            cmd.Parameters.AddWithValue("@arrival_lsmgo", EmissionData.arrival_lsmgo);
            cmd.Parameters.AddWithValue("@departure_stemmed_hsfo", EmissionData.departure_stemmed_hsfo);
            cmd.Parameters.AddWithValue("@departure_stemmed_lsfo", EmissionData.departure_stemmed_lsfo);
            cmd.Parameters.AddWithValue("@departure_stemmed_ulsfo", EmissionData.departure_stemmed_ulsfo);
            cmd.Parameters.AddWithValue("@departure_stemmed_lsmgo", EmissionData.departure_stemmed_lsmgo);
            cmd.Parameters.AddWithValue("@distance_berth_to_berth", EmissionData.distance_berth_to_berth);
            cmd.Parameters.AddWithValue("@laden_ballast", EmissionData.laden_ballast);
            cmd.Parameters.AddWithValue("@type_of_cargo", EmissionData.type_of_cargo);
            cmd.Parameters.AddWithValue("@total_cargo_on_board", EmissionData.total_cargo_on_board);
            cmd.Parameters.AddWithValue("@last_departure_left_berth_date", EmissionData.last_departure_left_berth_date);
            cmd.Parameters.AddWithValue("@last_departure_lsfo", EmissionData.last_departure_lsfo);
            cmd.Parameters.AddWithValue("@last_departure_ulsfo", EmissionData.last_departure_ulsfo);
            cmd.Parameters.AddWithValue("@last_departure_lsmgo", EmissionData.last_departure_lsmgo);
            cmd.Parameters.AddWithValue("@last_departure_stemmed_hsfo", EmissionData.last_departure_stemmed_hsfo);
            cmd.Parameters.AddWithValue("@last_departure_stemmed_lsfo", EmissionData.last_departure_stemmed_lsfo);
            cmd.Parameters.AddWithValue("@last_departure_stemmed_ulsfo", EmissionData.last_departure_stemmed_ulsfo);
            cmd.Parameters.AddWithValue("@last_departure_stemmed_lsmgo", EmissionData.last_departure_stemmed_lsmgo);
            cmd.Parameters.AddWithValue("@sulphur_hsfo", EmissionData.sulphur_hsfo);
            cmd.Parameters.AddWithValue("@sulphur_lsfo", EmissionData.sulphur_lsfo);
            cmd.Parameters.AddWithValue("@sulphur_ulsfo", EmissionData.sulphur_ulsfo);
            cmd.Parameters.AddWithValue("@sulphur_lsmgo", EmissionData.sulphur_lsmgo);

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

        public bool Delete(CEmission EmissionData)
        {
            SqlCommand cmd = new SqlCommand("HSP_TEmission_Delete", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@emission_id", EmissionData.emission_id);

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

        public DataTable Browse(CEmission EmissionData)
        {

            SqlCommand cmd = new SqlCommand("HSP_TEmission_Browse", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@emission_id", EmissionData.emission_id);

            conn.Open();

            DataTable dt = new DataTable();
            SqlDataReader reader = sqlFunctions.sqlNullValueAssigner(cmd).ExecuteReader(); 
            dt.Load(reader);
            conn.Close();
            return dt;
        }

        public DataTable Search(CEmission EmissionData)
        {

            SqlCommand cmd = new SqlCommand("HSP_TEmission_Search", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@vessel_id", EmissionData.vessel_id);
            cmd.Parameters.AddWithValue("@start_date", EmissionData.start_date);
            cmd.Parameters.AddWithValue("@end_date", EmissionData.end_date);

            conn.Open();

            DataTable dt = new DataTable();
            SqlDataReader reader = sqlFunctions.sqlNullValueAssigner(cmd).ExecuteReader(); 
            dt.Load(reader);
            conn.Close();
            return dt;
        }


    }
}