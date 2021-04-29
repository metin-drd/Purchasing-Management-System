using Metin.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Metin.Command
{
    public class CDocumentFile : BaseCommon
    {
        public int document_file_id { get; set; }
        public string file_location { get; set; }
    }
}