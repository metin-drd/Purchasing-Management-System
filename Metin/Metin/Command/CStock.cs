using Metin.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Metin.Command
{
    public class CStock : BaseCommon
    {
        public int stock_id { get; set; }
        public string stock_name { get; set; }
        public int stock_category_id { get; set; }

    }
}