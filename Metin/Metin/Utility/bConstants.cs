using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Metin.Utility
{
    public class bConstants
    {
        public bConstants()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region Genel Sabitler
        public enum EvetHayir
        {
            Hayir = 1,
            Evet = 2,
        }

        public enum FillTypes
        {
            None = 1,
            Choose = 2,
            All = 3,
            Special = 4,
        }
        #endregion

        #region SabitDegerTipi
        public enum SabitDegerTipi
        {
            RequisitionStatus = 1,
            Rol = 2,
            ReportType = 3,
            FileType = 4
        }
        #endregion

        #region SabitDegerTipi RequisitionStatus = 1
        public enum RequisitionStatus
        {
            Requested = 1, //talep
            ApprovedDepartmentManager = 2, //dept. müdürü tarafından onaylandı
            ApprovedGeneralManager = 3, //genel müdür tarafından onaylandı
            Purchased = 4,  //satın alındı (işlem tamam)
            Rejected = 5 //rededildi
        }
        #endregion

        #region SabitDegerTipi Rol = 2
        public enum Rol
        {
            Admin = 1,
            Purchase = 2,
            FleetManager = 3,
            IT = 4,
            Operation = 5,
            HSEQ = 6,
            HR = 7,
            PurchaseReadOnly = 8
        }

        #region SabitDegerTipi ReportType = 3
        public enum ReportType
        {
            Department = 1,
            StokCategory = 2
        }
        #endregion

        #region SabitDegerTipi FileType = 4
        public enum FileType
        {
            HSEQ = 1,
            Purchasing = 2,
            HR = 3            
        }
        #endregion
        #endregion


    }
}