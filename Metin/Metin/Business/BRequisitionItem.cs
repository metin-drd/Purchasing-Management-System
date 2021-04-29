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
    public class BRequisitionItem : BaseBusiness
    {

        public DRequisitionItem dRequisitionItem = new DRequisitionItem();

        public bool Insert(CRequisitionItem RequisitionItemData)
        {
            ReturnValue = dRequisitionItem.Insert(RequisitionItemData);
            return ReturnValue > 0 ? true : false;
        }

        public bool Update(CRequisitionItem RequisitionItemData)
        {
            return dRequisitionItem.Update(RequisitionItemData);
        }

        public bool Delete(CRequisitionItem RequisitionItemData)
        {
            return dRequisitionItem.Delete(RequisitionItemData);
        }

        public DataTable Browse(CRequisitionItem RequisitionItemData)
        {
            return dRequisitionItem.Browse(RequisitionItemData);
        }

        public DataTable Search(CRequisitionItem RequisitionItemData)
        {
            return dRequisitionItem.Search(RequisitionItemData);
        }

        public CRequisitionItem BrowseOne(int requisition_item_id)
        {
            if (requisition_item_id < 1)
                return null;

            CRequisitionItem RequisitionItemData = new CRequisitionItem();
            RequisitionItemData.requisition_item_id = requisition_item_id;

            DataTable dtRequisitionItem = Browse(RequisitionItemData);
            if (dtRequisitionItem == null || dtRequisitionItem.Rows.Count != 1)
                return null;

            RequisitionItemData.FromDataRow(dtRequisitionItem.Rows[0]);
            return RequisitionItemData;
        }

        public bool DeletOne(int requisition_item_id)
        {
            if (requisition_item_id < 1)
                return false;

            CRequisitionItem RequisitionItemData = new CRequisitionItem();
            RequisitionItemData.requisition_item_id = requisition_item_id;

            return dRequisitionItem.Delete(RequisitionItemData);
        }

    }
}