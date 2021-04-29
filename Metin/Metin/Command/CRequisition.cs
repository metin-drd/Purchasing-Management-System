using Metin.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Metin.Command
{
    public class CRequisition : BaseCommon
    {
        #region Table Properties
        public int requisition_id { get; set; }
        public DateTime request_date { get; set; }
        public short status { get; set; }
        public int request_personnel_id { get; set; }
        public string comment { get; set; }
        public int approved_purchasing_manager_id { get; set; }
        public DateTime approved_purchasing_manager_date { get; set; }
        public int approved_genaral_manager_id { get; set; }
        public DateTime approved_genaral_manager_date { get; set; }
        public DateTime purchased_date { get; set; }
        #endregion

        #region Extra Properties
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public string request_personnel_name { get; set; }
        public string status_name { get; set; }
        public int responsible_department_id { get; set; }
        public decimal total_price { get; set; }
        public int report_type { get; set; }

        #endregion


    }
}