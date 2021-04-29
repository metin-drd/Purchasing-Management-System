using Metin.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Metin.Command
{
    public class CVesselApproval : BaseCommon
    {
        public int vessel_approval_id { get; set; }
        public int vessel_id { get; set; }
        public DateTime closed_date { get; set; }
        public string comment { get; set; }
        public int safety_id { get; set; }

    }
}