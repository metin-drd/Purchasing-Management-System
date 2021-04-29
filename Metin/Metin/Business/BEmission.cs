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
    public class BEmission : BaseBusiness
    {
        public DEmission dEmission = new DEmission();

        public bool Insert(CEmission EmissionData)
        {
            ReturnValue = dEmission.Insert(EmissionData);
            return ReturnValue > 0 ? true : false;
        }

        public bool Update(CEmission EmissionData)
        {
            return dEmission.Update(EmissionData);
        }

        public bool Delete(CEmission EmissionData)
        {
            return dEmission.Delete(EmissionData);
        }

        public DataTable Browse(CEmission EmissionData)
        {
            return dEmission.Browse(EmissionData);
        }

        public DataTable Search(CEmission EmissionData)
        {
            return dEmission.Search(EmissionData);
        }

        public CEmission BrowseOne(int emission_id)
        {
            if (emission_id < 1)
                return null;

            CEmission EmissionData = new CEmission();
            DataTable Emission = new DataTable();

            EmissionData.emission_id = emission_id;
            Emission = dEmission.Browse(EmissionData);

            if (Emission == null || Emission.Rows.Count == 0)
                return null;


            EmissionData.FromDataRow(Emission.Rows[0]);

            return EmissionData;

        }

        public bool DeletOne(int emission_id)
        {
            if (emission_id < 1)
                return false;

            CEmission EmissionData = new CEmission();
            EmissionData.emission_id = emission_id;

            return dEmission.Delete(EmissionData);
        }

    }
}