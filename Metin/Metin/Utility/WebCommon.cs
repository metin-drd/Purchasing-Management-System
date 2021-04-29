using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Metin.Utility
{
    public class WebCommon
    {
        public static int VesselID
        {
            get
            {
                return bConvert.ToInt32(ConfigurationManager.AppSettings["vessel_id"]);
            }

        }
    }
}