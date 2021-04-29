using Metin.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Metin.Command
{
    public class CPersonnel : BaseCommon
    {
        #region Table Properties
        public int personnel_id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string tc_no { get; set; }
        public int rank_id { get; set; }
        public int department_id { get; set; }
        public string phone_number { get; set; }
        public string email { get; set; }
        public string home_address { get; set; }
        public DateTime firm_date { get; set; }
        public DateTime quit_date { get; set; }
        #endregion

        #region Extra Properties
        public Int16 is_active { get; set; }
        #endregion
    }
}