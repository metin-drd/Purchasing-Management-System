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
    public class BKullaniciRol : BaseBusiness
    {
        public DKullaniciRol dKullaniciRol = new DKullaniciRol();

        public bool Insert(CKullaniciRol KullaniciRolData)
        {
            ReturnValue = dKullaniciRol.Insert(KullaniciRolData);
            return ReturnValue > 0 ? true : false;
        }

        public bool Update(CKullaniciRol KullaniciRolData)
        {
            return dKullaniciRol.Update(KullaniciRolData);
        }

        public bool Delete(CKullaniciRol KullaniciRolData)
        {
            return dKullaniciRol.Delete(KullaniciRolData);
        }

        public DataTable Browse(CKullaniciRol KullaniciRolData)
        {
            return dKullaniciRol.Browse(KullaniciRolData);
        }

        public DataTable Search(CKullaniciRol KullaniciRolData)
        {
            return dKullaniciRol.Search(KullaniciRolData);
        }

        public CKullaniciRol BrowseOne(int kullanici_rol_id)
        {
            if (kullanici_rol_id < 1)
                return null;

            CKullaniciRol KullaniciRolData = new CKullaniciRol();
            KullaniciRolData.kullanici_rol_id = kullanici_rol_id;

            DataTable dtKullaniciRol = Browse(KullaniciRolData);
            if (dtKullaniciRol == null || dtKullaniciRol.Rows.Count != 1)
                return null;

            KullaniciRolData.FromDataRow(dtKullaniciRol.Rows[0]);
            return KullaniciRolData;
        }

        public bool DeletOne(int kullanici_rol_id)
        {
            if (kullanici_rol_id < 1)
                return false;

            CKullaniciRol KullaniciRolData = new CKullaniciRol();
            KullaniciRolData.kullanici_rol_id = kullanici_rol_id;

            return dKullaniciRol.Delete(KullaniciRolData);
        }
    }
}