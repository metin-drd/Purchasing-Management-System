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
    public class BSafety : BaseBusiness
    {
        public DSafety dSafety = new DSafety();

        public bool Insert(CSafety SafetyData)
        {
            ReturnValue = dSafety.Insert(SafetyData);
            return ReturnValue > 0 ? true : false;
        }

        public bool Update(CSafety SafetyData)
        {
            return dSafety.Update(SafetyData);
        }

        public bool Delete(CSafety SafetyData)
        {
            return dSafety.Delete(SafetyData);
        }

        public DataTable Browse(CSafety SafetyData)
        {
            return dSafety.Browse(SafetyData);
        }

        public DataTable Search(CSafety SafetyData)
        {
            return dSafety.Search(SafetyData);
        }

        public CSafety BrowseOne(int safety_id)
        {
            if (safety_id < 1)
                return null;

            CSafety SafetyData = new CSafety();
            SafetyData.safety_id = safety_id;

            DataTable dtSafety = Browse(SafetyData);
            if (dtSafety == null || dtSafety.Rows.Count != 1)
                return null;

            SafetyData.FromDataRow(dtSafety.Rows[0]);
            return SafetyData;
        }

        public bool DeletOne(int safety_id)
        {
            if (safety_id < 1)
                return false;

            CSafety SafetyData = new CSafety();
            SafetyData.safety_id = safety_id;

            return dSafety.Delete(SafetyData);
        }

    }
}