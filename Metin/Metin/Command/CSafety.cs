using Metin.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Metin.Command
{
    public class CSafety : BaseCommon
    {
        public int safety_id { get; set; }
        public string safety_no { get; set; }
        public DateTime issued_date { get; set; }
        public int vessel_id { get; set; }
        public int department_id { get; set; }
        public string subject { get; set; }
        public string comment { get; set; }
        public short is_published { get; set; }

    }
}