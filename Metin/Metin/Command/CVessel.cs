using Metin.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Metin.Command
{
    public class CVessel : BaseCommon
    {
        public int vessel_id { get; set; }
        public string ship_name { get; set; }
        public short is_active { get; set; }
        public string ship_acronym_name { get; set; }
    }
}