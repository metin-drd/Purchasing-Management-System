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
    public class BKullanici : BaseBusiness
    {
        public DKullanici dKullanici  = new DKullanici();

        public bool Insert(CKullanici KullaniciData)
        {
            ReturnValue = dKullanici.Insert(KullaniciData);
            return ReturnValue > 0 ? true : false;
        }

        public bool Update(CKullanici KullaniciData)
        {
            return dKullanici.Update(KullaniciData);
        }

        public bool Delete(CKullanici KullaniciData)
        {
            return dKullanici.Delete(KullaniciData);
        }

        public DataTable Browse(CKullanici KullaniciData)
        {
            return dKullanici.Browse(KullaniciData);
        }

        public DataTable Search(CKullanici KullaniciData)
        {
            return dKullanici.Search(KullaniciData);
        }

        public CKullanici BrowseOne(int Kullanici_id)
        {
            if (Kullanici_id < 1)
                return null;

            CKullanici KullaniciData = new CKullanici();
            KullaniciData.kullanici_id = Kullanici_id;

            DataTable dtKullanici = Browse(KullaniciData);

            if (dtKullanici == null|| dtKullanici.Rows.Count==0)
                return null;

            KullaniciData.FromDataRow(dtKullanici.Rows[0]);
            return KullaniciData;

        }

        public bool DeletOne(int Kullanici_id)
        {
            if (Kullanici_id < 1)
                return false;

            CKullanici KullaniciData = new CKullanici();
            KullaniciData.kullanici_id = Kullanici_id;

            return dKullanici.Delete(KullaniciData);
        }

        public CKullanici Login(string kullanici_kodu, string sifre)
        {
            DataTable dtKullanici = dKullanici.Login(kullanici_kodu, sifre);

            if (dtKullanici == null || dtKullanici.Rows.Count==0)
                return null;

            CKullanici KullaniciData = new CKullanici();

            KullaniciData.FromDataRow(dtKullanici);
         
            return KullaniciData;
        }

    }
}