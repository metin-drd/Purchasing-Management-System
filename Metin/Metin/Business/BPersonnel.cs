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
    public class BPersonnel : BaseBusiness
    {
        public DPersonnel dPersonel = new DPersonnel();
        public bool Insert(CPersonnel PersonnelData)
        {
            ReturnValue = dPersonel.Insert(PersonnelData);
            return ReturnValue > 0 ? true : false;
        }

        public bool Update(CPersonnel PersonnelData)
        {
            return dPersonel.Update(PersonnelData);
        }

        public bool Delete(CPersonnel PersonnelData)
        {
            return dPersonel.Delete(PersonnelData);
        }

        public DataTable Browse(CPersonnel PersonnelData)
        {
            return dPersonel.Browse(PersonnelData);
        }

        public DataTable Search(CPersonnel PersonnelData)
        {
            return dPersonel.Search(PersonnelData);
        }

        public CPersonnel BrowseOne(int personnel_id)
        {

            if (personnel_id < 1)
                return null;

            CPersonnel PersonnelData = new CPersonnel();
            PersonnelData.personnel_id = personnel_id;


            DataTable dtPersonnel = new DataTable();
            dtPersonnel = dPersonel.Browse(PersonnelData);

            if (dtPersonnel == null || dtPersonnel.Rows.Count == 0)
                return null;

            PersonnelData.FromDataRow(dtPersonnel.Rows[0]);
            return PersonnelData;
        }

        public bool DeletOne(int personnel_id)
        {
            if (personnel_id < 1)
                return false;

            CPersonnel PersonnelData = new CPersonnel();
            PersonnelData.personnel_id = personnel_id;

            return dPersonel.Delete(PersonnelData);
        }


    }
}