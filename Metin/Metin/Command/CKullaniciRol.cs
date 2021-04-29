using Metin.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Metin.Command
{
    public class CKullaniciRol : BaseCommon
    {
        public int kullanici_rol_id { get; set; }
        public int kullanici_id { get; set; }
        public short rol { get; set; }
    }
}