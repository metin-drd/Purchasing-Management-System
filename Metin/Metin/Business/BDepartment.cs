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
    public class BDepartment : BaseBusiness
    {

        public DDepartment dDepartment = new DDepartment();

        public bool Insert(CDepartment DepartmentData)
        {
            ReturnValue = dDepartment.Insert(DepartmentData);
            return ReturnValue > 0 ? true : false;
        }

        public bool Update(CDepartment DepartmentData)
        {
            return dDepartment.Update(DepartmentData);
        }

        public bool Delete(CDepartment DepartmentData)
        {
            return dDepartment.Delete(DepartmentData);
        }

        public DataTable Browse(CDepartment DepartmentData)
        {
            return dDepartment.Browse(DepartmentData);
        }

        public DataTable Search(CDepartment DepartmentData)
        {
            return dDepartment.Search(DepartmentData);
        }

        public CDepartment BrowseOne(int department_id)
        {
            if (department_id <1)
                return null;
            

            CDepartment DepartmentData = new CDepartment();
            DepartmentData.department_id = department_id;

            DataTable dtDepartment = Browse(DepartmentData);
            if (dtDepartment == null || dtDepartment.Rows.Count != 1)
                return null;

            DepartmentData.FromDataRow(dtDepartment.Rows[0]);
            return DepartmentData;
        }

        public bool DeletOne(int department_id)
        {
            if (department_id < 1)
                return false;

            CDepartment departmentData = new CDepartment();
            departmentData.department_id = department_id;

            return dDepartment.Delete(departmentData);
        }
    }
}