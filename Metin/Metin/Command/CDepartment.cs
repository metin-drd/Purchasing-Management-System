using Metin.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Metin.Command
{
    public class CDepartment : BaseCommon
    {

        public int department_id { get; set; }
        public string name { get; set; }
        public int manager_personnel_id { get; set; }

    }
}