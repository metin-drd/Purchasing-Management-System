using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Metin.Utility
{
    /// <summary>
    /// Temel Common Property Classi.
    /// Clonelanabilir olması için ICloneable interface ini implement etmiştir.
    /// </summary>
    [Serializable]
    public class BaseCommon : ICloneable
    {
        #region Variables
        private Hashtable _ExtraData = null;
        #endregion

        #region CT
        /// <summary>
        /// Yeni bir BaseCommon yaratmak içindir.
        /// </summary>
        public BaseCommon()
        {
            //yeditepe.common.yProtection.CheckAsm(System.Reflection.Assembly.GetCallingAssembly());			
        }
        #endregion

        #region Properties
        /// <summary>
        /// Property class içinde extra veri tutmak içindir.
        /// </summary>
        protected Hashtable ExtraData
        {
            get
            {
                if (_ExtraData == null)
                    _ExtraData = new Hashtable();

                return _ExtraData;
            }
        }

        /// <summary>
        /// Property class'ı içinde tutulan extra datayı yönetir.
        /// </summary>
        public object this[string name]
        {
            get
            {
                return ExtraData[name];
            }
            set
            {
                if (!ExtraData.ContainsKey(name))
                    ExtraData.Add(name, value);
                else
                    ExtraData[name] = value;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Common classın property lerini datarow dan doldurmak için kullanılabilir.
        /// </summary>
        /// <param name="drCommon">Propertylerin alınacağı datarow parametresi</param>
        public bool FromDataRow(DataRow drCommon)
        {
            if (drCommon == null)
                return false;

            bool Sonuc = true;

            foreach (DataColumn dc in drCommon.Table.Columns)
            {
                if (!SetPropertyValue(dc.ColumnName, drCommon[dc.ColumnName]))
                {
                    this[dc.ColumnName] = drCommon[dc.ColumnName];
                    //Sonuc = false;
                }
            }

            return Sonuc;
        }

        /// <summary>
        /// Common classın property lerini datarow dan doldurmak için kullanılabilir.
        /// </summary>
        /// <param name="drCommon">Propertylerin alınacağı datarow parametresi</param>
        public bool FromDataRow(DataRow[] drCommon)
        {
            if (drCommon == null || drCommon.Length != 1)
                return false;

            return FromDataRow(drCommon[0]);
        }

        /// <summary>
        /// Common classın property lerini datarow dan doldurmak için kullanılabilir.
        /// </summary>
        /// <param name="drCommon">Propertylerin alınacağı datarow parametresi</param>
        public bool FromDataRow(DataRowView[] drvCommon)
        {
            if (drvCommon == null || drvCommon.Length != 1)
                return false;

            return FromDataRow(drvCommon[0].Row);
        }

        /// <summary>
        /// Common classın property lerini datarow dan doldurmak için kullanılabilir.
        /// </summary>
        /// <param name="drCommon">Propertylerin alınacağı datarow parametresi</param>
        public bool FromDataRow(DataTable dtCommon)
        {
            if (dtCommon == null || dtCommon.Rows.Count < 1)
                return false;

            return FromDataRow(dtCommon.Rows[0]);
        }

        /// <summary>
        /// Common classın propertylerini DataTable'ın DefaultView'ındaki satırlardan alarak
        /// Bir Common class dizisi döner.
        /// </summary>
        /// <param name="dtCommon">Propertylerin alınacağı DataTable parametresi</param>
        /// <returns>BaseCommon tipinde dizi döner.</returns>
        public static System.Array FromDataRowArray(DataRow[] Rows, Type type)
        {
            System.Collections.ArrayList alCommonList = new System.Collections.ArrayList();

            for (int i = 0; i < Rows.Length; i++)
            {
                BaseCommon CommonData = (BaseCommon)Activator.CreateInstance(type, false);
                CommonData.FromDataRow(Rows[i]);
                alCommonList.Add(CommonData);
            }

            return alCommonList.ToArray(type);
        }

        /// <summary>
        /// Common classın propertylerini DataTable'ın DefaultView'ındaki satırlardan alarak
        /// Bir Common class dizisi döner.
        /// </summary>
        /// <param name="dtCommon">Propertylerin alınacağı DataTable parametresi</param>
        /// <returns>BaseCommon tipinde dizi döner.</returns>
        public static System.Array FromDataTable(DataTable dtCommon, Type type)
        {
            DataView dvCommon = dtCommon.DefaultView;
            System.Collections.ArrayList alCommonList = new System.Collections.ArrayList();

            for (int i = 0; i < dvCommon.Count; i++)
            {
                BaseCommon CommonData = (BaseCommon)Activator.CreateInstance(type, false);
                CommonData.FromDataRow(dvCommon[i].Row);
                alCommonList.Add(CommonData);
            }

            return alCommonList.ToArray(type);
        }

        /// <summary>
        /// Verilen common class ile common class ı karşılaştırır değişiklik olup olmadıgını kontrol eder.
        /// </summary>
        /// <param name="OtherCommonClass">Diğer bilgileri içeren Common Class</param>
        /// <returns>Değişiklik olup olmadığını döndürür.</returns>
        public bool Equals(BaseCommon OtherCommonClass)
        {
            foreach (System.Reflection.PropertyInfo pi in this.GetType().GetProperties())
            {
                if (pi.Name == "Item")
                    continue;

                object ovalue = bMethods.GetPropertyValue(this, pi.Name);
                object dvalue = bMethods.GetPropertyValue(OtherCommonClass, pi.Name);
                bool sonuc = false;
                if (ovalue == null)
                    sonuc = (ovalue == dvalue);
                else
                    sonuc = ovalue.Equals(dvalue);

                if (!sonuc)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Objectin propertysini set etmek için kullanılmıştır.
        /// </summary>
        /// <param name="PropertyName">Property Adı</param>
        /// <param name="value">Property Değeri</param>
        /// <returns>İşlem başarılı ise true döner.</returns>
        private bool SetPropertyValue(string PropertyName, object value)
        {
            return bMethods.SetPropertyValue(this, PropertyName, value);
        }

        /// <summary>
        /// Objectin propertysini almak için kullanılmıştır.
        /// </summary>
        /// <param name="PropertyName">Property Adı</param>
        /// <returns>Değeri döner.</returns>
        private object GetPropertyValue(string PropertyName)
        {
            return bMethods.GetPropertyValue(this, PropertyName);
        }
        #endregion

        #region ICloneable Members
        /// <summary>
        /// Classımızın Clonelanabilir olmasını sağlamak içindir.
        /// </summary>
        /// <returns>Clonelanan yeni objeyi döner</returns>
        public object Clone()
        {
            return bMethods.CloneObject(this);
        }

        #endregion
    }
}