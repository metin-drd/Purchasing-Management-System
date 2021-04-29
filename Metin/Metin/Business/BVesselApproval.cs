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
    public class BVesselApproval : BaseBusiness
    {
        public DVesselApproval dVesselApprovalt = new DVesselApproval();

        public bool Insert(CVesselApproval VesselApprovalData)
        {
            ReturnValue = dVesselApprovalt.Insert(VesselApprovalData);
            return ReturnValue > 0 ? true : false;
        }

        public bool Update(CVesselApproval VesselApprovalData)
        {
            return dVesselApprovalt.Update(VesselApprovalData);
        }

        public bool Delete(CVesselApproval VesselApprovalData)
        {
            return dVesselApprovalt.Delete(VesselApprovalData);
        }

        public DataTable Browse(CVesselApproval VesselApprovalData)
        {
            return dVesselApprovalt.Browse(VesselApprovalData);
        }

        public DataTable Search(CVesselApproval VesselApprovalData)
        {
            return dVesselApprovalt.Search(VesselApprovalData);
        }

        public CVesselApproval BrowseOne(int vessel_approval_id)
        {
            if (vessel_approval_id < 1)
                return null;


            CVesselApproval VesselApprovalData = new CVesselApproval();
            VesselApprovalData.vessel_approval_id = vessel_approval_id;

            DataTable dtVesselApproval = Browse(VesselApprovalData);
            if (dtVesselApproval == null || dtVesselApproval.Rows.Count != 1)
                return null;

            VesselApprovalData.FromDataRow(dtVesselApproval.Rows[0]);
            return VesselApprovalData;
        }

        public bool DeletOne(int vessel_approval_id)
        {
            if (vessel_approval_id < 1)
                return false;

            CVesselApproval VesselApprovalData = new CVesselApproval();
            VesselApprovalData.vessel_approval_id = vessel_approval_id;

            return dVesselApprovalt.Delete(VesselApprovalData);
        }

        public DataTable UnapprovedShips(int SafetyID)
        {
            return dVesselApprovalt.UnapprovedShips(SafetyID);
        }


    }
}