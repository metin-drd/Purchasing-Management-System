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
    public class BVessel : BaseBusiness
    {
        public DVessel dVessel = new DVessel();

        public bool Insert(CVessel VesselData)
        {
            ReturnValue = dVessel.Insert(VesselData);
            return ReturnValue > 0 ? true : false;
        }

        public bool Update(CVessel VesselData)
        {
            return dVessel.Update(VesselData);
        }

        public bool Delete(CVessel VesselData)
        {
            return dVessel.Delete(VesselData);
        }

        public DataTable Browse(CVessel VesselData)
        {
            return dVessel.Browse(VesselData);
        }

        public DataTable Search(CVessel VesselData)
        {
            return dVessel.Search(VesselData);
        }

        public CVessel BrowseOne(int vessel_id)
        {
            if (vessel_id < 1)
                return null;

            CVessel VesselData = new CVessel();
            VesselData.vessel_id = vessel_id;

            DataTable dtVessel = Browse(VesselData);
            if (dtVessel == null || dtVessel.Rows.Count != 1)
                return null;

            VesselData.FromDataRow(dtVessel.Rows[0]);
            return VesselData;
        }

        public bool DeletOne(int vessel_id)
        {
            if (vessel_id < 1)
                return false;

            CVessel VesselData = new CVessel();
            VesselData.vessel_id = vessel_id;

            return dVessel.Delete(VesselData);
        }
    }
}