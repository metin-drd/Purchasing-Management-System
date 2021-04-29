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
    public class BRequisition : BaseBusiness
    {
        public DRequisition dRequisition = new DRequisition();

        public bool Insert(CRequisition RequisitionData)
        {
            ReturnValue = dRequisition.Insert(RequisitionData);
            return ReturnValue > 0 ? true : false;
        }

        public bool Update(CRequisition RequisitionData)
        {
            return dRequisition.Update(RequisitionData);
        }

        public bool Delete(CRequisition RequisitionData)
        {
            return dRequisition.Delete(RequisitionData);
        }

        public DataTable Browse(CRequisition RequisitionData)
        {
            return dRequisition.Browse(RequisitionData);
        }

        public DataTable Search(CRequisition RequisitionData)
        {
            return dRequisition.Search(RequisitionData);
        }

        public CRequisition BrowseOne(int requisition_id)
        {
            if (requisition_id < 1)
                return null;

            CRequisition RequisitionData = new CRequisition();
            DataTable dtRequisition = new DataTable();

            RequisitionData.requisition_id = requisition_id;
            dtRequisition = dRequisition.Browse(RequisitionData);

            if (dtRequisition == null || dtRequisition.Rows.Count == 0)
                return null;
                        
            RequisitionData.FromDataRow(dtRequisition.Rows[0]);

            return RequisitionData;

        }

        public bool DeletOne(int requisition_id)
        {

            if (requisition_id < 1)
                return false;

            CRequisition RequisitionData = new CRequisition();
            RequisitionData.requisition_id = requisition_id;

            return dRequisition.Delete(RequisitionData);
        }

        public DataTable Report(CRequisition RequisitionData)
        {
            return dRequisition.Report(RequisitionData);
        }
    }
}