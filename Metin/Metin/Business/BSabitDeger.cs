using Metin.Command;
using Metin.Data;
using Metin.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Metin.Business
{
    public class BSabitDeger : BaseBusiness
    {

        public DataTable Search(CSabitDeger SabitDegerData)
        {
            DSabitDeger dSabitDeger = new DSabitDeger();
            return dSabitDeger.Search(SabitDegerData);
        }
    }
}