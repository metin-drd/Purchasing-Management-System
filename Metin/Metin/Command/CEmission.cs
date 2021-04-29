using Metin.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Metin.Command
{
    public class CEmission : BaseCommon
    {
        #region Tablo Properties

        public int emission_id { get; set; }
        public int vessel_id { get; set; }
        public int report_no { get; set; }
        public int departure_port_id { get; set; }
        public DateTime departure_left_berth_date { get; set; }
        public decimal departure_hsfo { get; set; }
        public decimal departure_lsfo { get; set; }
        public decimal departure_ulsfo { get; set; }
        public decimal departure_lsmgo { get; set; }
        public int arrival_port_id { get; set; }
        public DateTime arrival_all_fast_date { get; set; }
        public decimal arrival_hsfo { get; set; }
        public decimal arival_lsfo { get; set; }
        public decimal arrival_ulsfo { get; set; }
        public decimal arrival_lsmgo { get; set; }
        public decimal departure_stemmed_hsfo { get; set; }
        public decimal departure_stemmed_lsfo { get; set; }
        public decimal departure_stemmed_ulsfo { get; set; }
        public decimal departure_stemmed_lsmgo { get; set; }
        public decimal distance_berth_to_berth { get; set; }
        public short laden_ballast { get; set; }
        public string type_of_cargo { get; set; }
        public decimal total_cargo_on_board { get; set; }
        public DateTime last_departure_left_berth_date { get; set; }
        public decimal last_departure_hsfo { get; set; }
        public decimal last_departure_lsfo { get; set; }
        public decimal last_departure_ulsfo { get; set; }
        public decimal last_departure_lsmgo { get; set; }
        public decimal last_departure_stemmed_hsfo { get; set; }
        public decimal last_departure_stemmed_lsfo { get; set; }
        public decimal last_departure_stemmed_ulsfo { get; set; }
        public decimal last_departure_stemmed_lsmgo { get; set; }
        public decimal sulphur_hsfo { get; set; }
        public decimal sulphur_lsfo { get; set; }
        public decimal sulphur_ulsfo { get; set; }
        public decimal sulphur_lsmgo { get; set; }

        #endregion

        #region Extra Properties
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        #endregion

    }
}