using Metin.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Metin.Command
{
    public class CFile : BaseCommon
    {
        public int file_id { get; set; }
        public int document_file_id { get; set; }
        public string comment { get; set; }
        public int requisition_id { get; set; }
        public int safety_id { get; set; }

    }
}