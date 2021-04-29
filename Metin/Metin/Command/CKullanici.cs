using Metin.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Metin.Command
{
    public class CKullanici : BaseCommon
    {
        #region Table Properties
        public int kullanici_id { get; set; }
        public int personnel_id { get; set; }
        public string kullanici_kodu { get; set; }
        public string sifre { get; set; } 
        #endregion

        #region Extra Properties
        public string personnel_full_name { get; set; }
        public int department_id { get; set; }
        public int rank_id { get; set; }
        public string all_roles { get; set; }

        #endregion
    }
}