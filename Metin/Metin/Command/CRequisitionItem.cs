using Metin.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Metin.Command
{
    public class CRequisitionItem : BaseCommon
    {
        #region Normal Properties
        public int requisition_item_id { get; set; }
        public int requisition_id { get; set; }
        public int stock_id { get; set; }
        public decimal unit_price { get; set; }
        public int quantity { get; set; } 
        #endregion

        #region Extra Properties
        public int stock_cat_id { get; set; }
        #endregion

    }
}