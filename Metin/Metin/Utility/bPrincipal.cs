using Metin.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Metin.Utility
{
    [Serializable]
    public class bPrincipal
    {
        CKullanici _Kullanici;
       
        public bPrincipal(CKullanici Kullanici)
        {
            _Kullanici = Kullanici;
        }

        public bool Admin
        {
            get
            {
                return IsInRole(bConstants.Rol.Admin);
            }
        }

        public bool Purchase
        {
            get
            {
                return IsInRole(bConstants.Rol.Purchase);
            }
        }

        public bool FleetManager
        {
            get
            {
                return IsInRole(bConstants.Rol.FleetManager);
            }
        }

        public bool IT
        {
            get
            {
                return IsInRole(bConstants.Rol.IT);
            }
        }

        public bool Operation
        {
            get
            {
                return IsInRole(bConstants.Rol.Operation);
            }
        }

        public bool HSEQ
        {
            get
            {
                return IsInRole(bConstants.Rol.HSEQ);
            }
        }

        public bool HR
        {
            get
            {
                return IsInRole(bConstants.Rol.HR);
            }
        }

        public bool PurchaseReadOnly
        {
            get
            {
                return IsInRole(bConstants.Rol.PurchaseReadOnly);
            }
        }

        private bool IsInRole(bConstants.Rol rol)
        {
            if (string.IsNullOrEmpty(_Kullanici.all_roles))
                return false;

            bool result = false;
            string[] all_roles = _Kullanici.all_roles.Split(',');
            foreach (string item in all_roles)
            {
                if (bConvert.ToInt16(item) == (short)rol)
                {
                    result = true;
                    break;
                }
            }

            return result;
        }
    }
}