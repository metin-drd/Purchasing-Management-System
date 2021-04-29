using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;

namespace Metin.Utility
{
    /// <summary>
    /// Projede genel kullanıma açık faydalı methodlar.
    /// </summary>
    public class bMethods
    {
        #region FilterDataTable, SelectDataTable
        /// <summary>
        /// DataTableı filteler ve istenirse sıralar sonucu farklı bir tablo olarak döner.
        /// </summary>
        /// <param name="datatable">Tablo</param>
        /// <param name="FilterExpression">Filtre Cümlesi</param>
        /// <param name="SortExpression">Sıralama Cümlesi</param>
        /// <returns>Filtrelenen ve sıralanan kayıtları yeni bir DataTable olarak döner.</returns>
        public static DataTable FilterDataTable(DataTable datatable, string FilterExpression, string SortExpression)
        {
            if (datatable == null)
                return null;

            DataTable dtNew = datatable.Clone();
            DataRow[] dr = SelectDataTable(datatable, FilterExpression, SortExpression);
            foreach (DataRow d in dr)
            {
                dtNew.ImportRow(d);
            }

            return dtNew;
        }

        /// <summary>
        /// DataTableı filteler sonucu farklı bir tablo olarak döner.
        /// </summary>
        /// <param name="datatable">Tablo</param>
        /// <param name="FilterExpression">Filtre Cümlesi</param>
        /// <returns>Filtrelenen kayıtları yeni bir DataTable olarak döner.</returns>
        public static DataTable FilterDataTable(DataTable datatable, string FilterExpression)
        {
            return FilterDataTable(datatable, FilterExpression, null);
        }

        /// <summary>
        /// DataTable'ı filterler ve sonucu DataRow[] olarak döner.
        /// </summary>
        /// <param name="datatable">Tablo</param>
        /// <param name="FilterExpression">Filtre Cümlesi</param>
        /// <param name="SortExpression">Sıralama Cümlesi</param>
        /// <returns>DataRow[] döner.</returns>
        public static DataRow[] SelectDataTable(DataTable datatable, string FilterExpression, string SortExpression)
        {
            return datatable.Select(FilterExpression, SortExpression);
        }

        /// <summary>
        /// DataTable'ı filterler ve sonucu DataRow[] olarak döner.
        /// </summary>
        /// <param name="datatable">Tablo</param>
        /// <param name="FilterExpression">Filtre Cümlesi</param>
        /// <returns>DataRow[] döner.</returns>
        public static DataRow[] SelectDataTable(DataTable datatable, string FilterExpression)
        {
            return SelectDataTable(datatable, FilterExpression, "");
        }

        /// <summary>
        /// DataRowView[] -> DataRow[] dönüşümü yapar.
        /// </summary>
        /// <param name="drvArray">DataRowView Array</param>
        /// <returns>DataRow Array döner.</returns>
        public static DataRow[] DataRowViewArrayToDataRowArray(DataRowView[] drvArray)
        {
            lock (drvArray)
            {
                if (drvArray == null)
                    return null;

                DataRow[] drArray = new DataRow[drvArray.Length];
                for (int i = 0; i < drvArray.Length; i++)
                    drArray[i] = drvArray[i].Row;
                return drArray;
            }
        }

        /// <summary>
        /// DataRowView[] -> DataRow[] dönüşümü yapar.
        /// </summary>
        /// <param name="drvArray">DataRowView Array</param>
        /// <returns>DataRow Array döner.</returns>
        public static DataRow[] DataRowViewToDataRowArray(DataView dv)
        {
            lock (dv)
            {
                if (dv == null || dv.Count < 1)
                    return null;

                DataRow[] drArray = new DataRow[dv.Count];
                for (int i = 0; i < dv.Count; i++)

                    drArray[i] = dv[i].Row;
                return drArray;
            }
        }

        /// <summary>
        /// DataRowView[] -> DataRow[] dönüşümü yapar.
        /// </summary>
        /// <param name="drvArray">DataRowView Array</param>
        /// <returns>DataRow Array döner.</returns>
        public static DataRow[] DataTableToDataRowArray(DataTable dt)
        {
            lock (dt)
            {
                if (dt == null || dt.Rows.Count < 1)
                    return null;

                DataRow[] drArray = new DataRow[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                    drArray[i] = dt.Rows[i];
                return drArray;
            }
        }
        #endregion

        #region GetDataRowVersion
        /// <summary>
        /// DataRow un istenilen version undaki değerleri içeren halini döner.
        /// </summary>
        /// <param name="dr">DataRow Bilgisi</param>
        /// <param name="rowversion">İstenilen RowVersion</param>
        /// <returns>İstenilen datarow versionunu döner</returns>
        public static DataRow GetDataRowVersion(DataRow dr, DataRowVersion rowversion)
        {
            if (dr == null)
                return null;

            object[] itemArray = new object[dr.Table.Columns.Count];
            for (int i = 0; i < itemArray.Length; i++)
                itemArray[i] = dr[i, rowversion];

            DataRow drNew = dr.Table.NewRow();
            drNew.ItemArray = itemArray;
            return drNew;
        }

        /// <summary>
        /// DataTable'ın istenilen version undaki değerleri içeren halini döner.
        /// </summary>
        /// <param name="dr">DataTable Bilgisi</param>
        /// <param name="rowversion">İstenilen RowVersion</param>
        /// <returns>İstenilen datatable versionunu döner</returns>
        public static DataTable GetDataTableVersion(DataTable dt, DataRowVersion rowVersion)
        {
            if (dt == null)
                return null;

            DataTable dtNew = dt.Clone();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                DataRow drNew = null;

                switch (dr.RowState)
                {
                    case DataRowState.Added:
                        if (rowVersion != DataRowVersion.Original)
                            drNew = GetDataRowVersion(dr, rowVersion);

                        break;

                    /*case DataRowState.Deleted:
                    case DataRowState.Detached:
                    case DataRowState.Modified:
                    case DataRowState.Unchanged:*/
                    default:
                        drNew = GetDataRowVersion(dr, rowVersion);
                        break;

                }

                if (drNew != null)
                    dtNew.Rows.Add(drNew.ItemArray);
            }

            return dtNew;
        }
        #endregion

        #region CloneObject
        /// <summary>
        /// Verilen objeyi clonelar.
        /// </summary>
        /// <param name="source">Kaynak obje</param>
        /// <returns>Clonelanan objeyi döner.</returns>
        public static object CloneObject(object source)
        {
            if (source == null)
                return null;

            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            bFormatter.Serialize(stream, source);
            stream.Seek(0, System.IO.SeekOrigin.Begin);
            object newobj = bFormatter.Deserialize(stream);
            return newobj;
        }
        #endregion

        #region String Methods

        #region ToLower, ToUpper
        /// <summary>
        /// Invariant culture'a göre harfleri küçültür
        /// </summary>
        /// <param name="cumle">Cümle girdisi</param>
        /// <returns>Küçük harfe çevrilmiş cümleyi döner</returns>
        public static string ToLower(string cumle)
        {
            if (cumle == null)
                return "";
            return cumle.ToLower(System.Globalization.CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Invariant culture'a göre harfleri büyük harfe çevirir.
        /// </summary>
        /// <param name="cumle">Cümle girdisi</param>
        /// <returns>Büyük harfe çevrilmiş cümleyi döner</returns>
        public static string ToUpper(string cumle)
        {
            if (cumle == null)
                return "";
            return cumle.ToUpper(System.Globalization.CultureInfo.InvariantCulture);
        }
        #endregion

        #region Split
        /// <summary>
        /// Verilen stringi Proje ayracına göre böler, split eder.
        /// </summary>
        /// <param name="str">String değer</param>
        /// <returns>Bölünmüş string array döner</returns>
        public static string[] Split(string str)
        {
            return str.Split(System.Configuration.ConfigurationSettings.AppSettings["delimiter"].ToCharArray());
        }

        /// <summary>
        /// Verilen stringi Proje ayracına göre böler, split eder.
        /// </summary>
        /// <param name="str">String değer</param>
        /// <param name="sep">Seperator (birden fazla karakter olabilir)</param>
        /// <returns>Bölünmüş string array döner</returns>
        public static string[] Split(string str, string sep)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(sep);
            return regex.Split(str);
        }

        /// <summary>
        /// Verilen stringi Proje ayracına göre böler, split eder.
        /// </summary>
        /// <param name="str">String değer</param>
        /// <param name="sep">Seperator (birden fazla karakter olabilir)</param>
        /// <returns>Bölünmüş string array döner</returns>
        public static string[] Split(string str, char[] sep)
        {
            string ssep = "";
            foreach (char c in sep)
                ssep += @"\" + c.ToString();

            return Split(str, ssep);
        }

        /// <summary>
        /// Verilen değerin dizi içinde olup olmadığını döner.
        /// </summary>
        /// <param name="val">Değer</param>
        /// <param name="array">Dizi</param>
        /// <returns>Sonucu döner</returns>
        public static bool InStringArray(string val, string[] array)
        {
            foreach (string str in array)
                if (val.Trim() == str.Trim())
                    return true;

            return false;
        }

        /// <summary>
        /// Object Arrayi String Array'e dönüştürür.
        /// </summary>
        /// <param name="array">Object Array</param>
        /// <returns>String Array</returns>
        public static string[] ConvertToStringArray(object[] array)
        {
            if (array == null)
                return null;

            string[] sarray = new string[array.Length];
            for (int i = 0; i < array.Length; i++)
                sarray[i] = bConvert.ToString(array[i]);

            return sarray;
        }
        #endregion

        #region ArrayToString
        /// <summary>
        /// Array nesnesini , ile birleştirerek string e çevirir.
        /// </summary>
        /// <param name="array">Array Nesnesi</param>
        /// <returns>String döner</returns>
        public static string ArrayToString(Array array)
        {
            if (array == null || array.Length < 1)
                return "";

            string res = "";
            foreach (object a in array)
            {
                if (res == "")
                    res = bConvert.ToString(a);
                else
                    res += "," + bConvert.ToString(a);
            }

            return res;
        }

        public static Array RemoveArrayItem(Array array, object item)
        {
            if (array == null)
                return array;

            ArrayList al = new ArrayList();

            for (int i = 0; i < array.Length; i++)
            {
                object av = array.GetValue(i);
                if (!av.Equals(item))
                    al.Add(av);
            }

            return al.ToArray(item.GetType());
        }
        #endregion

        #region IsEmpty()
        /// <summary>
        /// String ifadenin boş olup olmadığını kontrol eder.
        /// </summary>
        /// <param name="s">String ifade</param>
        /// <returns>String ifadenin boş olup olmadığını döndürür.</returns>
        public static bool IsEmpty(string s)
        {
            return (s == null || s == "");
        }
        #endregion

        #region IsNumber()
        /// <summary>
        /// Verilen karakterin numerik olup olmadığını verir.
        /// </summary>
        /// <param name="c">Karakter</param>
        /// <returns>Verilen karakterin numerik olup olmadığını döner</returns>
        public static bool IsNumeric(char c)
        {
            return (c >= '0' && c <= '9');
        }

        /// <summary>
        /// Verilen stringin numerik olup olmadığını verir.
        /// </summary>
        /// <param name="c">Karakter</param>
        /// <returns>Verilen stringin numerik olup olmadığını döner</returns>
        public static bool IsNumeric(string s)
        {
            if (s.Trim() == "")
                return false;

            foreach (char c in s)
            {
                if (!IsNumeric(c))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Verilen string içindeki numeric olmayan karakterleri atar.
        /// </summary>
        /// <param name="text">String değer</param>
        /// <returns>Çıkarılmış decimal döner</returns>
        public static decimal ParseNumber(string text)
        {
            text = text.Replace(System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator, "\x1");
            text = text.Replace(System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator, "\x1");
            for (int i = 0; i < text.Length; i++)
            {
                if (!IsNumeric(text[i]) && text[i] != '\x1' && text[i] != '-')
                {
                    text = text.Insert(i, "\x2");
                    text = text.Remove(i + 1, 1);
                }
            }

            text = text.Replace("\x1", System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator).Replace("\x2", "");

            return bConvert.ToDecimal(text);
        }
        #endregion

        #region Left, Right
        /// <summary>
        /// Verilen stringin soldan verilen sayi kadar karakterini verir.
        /// </summary>
        /// <param name="cumle">Cümle girdisi</param>
        /// <param name="sayi">Dönecek karakter sayısı</param>
        /// <returns>Verilen stringin soldan verilen sayi kadar karakterini döner.</returns>
        public static string Left(string cumle, int sayi)
        {
            if (cumle.Length <= sayi)
                return cumle;
            else
                return cumle.Substring(0, sayi);
        }

        /// <summary>
        /// Verilen stringin sağdan verilen sayi kadar karakterini verir.
        /// </summary>
        /// <param name="cumle">Cümle girdisi</param>
        /// <param name="sayi">Dönecek karakter sayısı</param>
        /// <returns>Verilen stringin sağdan verilen sayi kadar karakterini döner.</returns>
        public static string Right(string cumle, int sayi)
        {
            if (cumle.Length <= sayi)
                return cumle;
            else
                return cumle.Substring(cumle.Length - sayi - 1, sayi);
        }
        #endregion

        #region IlkNKarakter
        /// <summary>
        /// Verilen stringin soldan verilen sayi kadar karakterini verir. Eğer cümle sığmazsa ... ekler.
        /// </summary>
        /// <param name="cumle">Cümle girdisi</param>
        /// <param name="sayi">Dönecek karakter sayısı</param>
        /// <returns>Verilen stringin soldan verilen sayi kadar karakterini döner.</returns>
        public static string IlkNKarakter(string cumle, int sayi)
        {
            string yenicumle = Left(cumle, sayi);
            if (yenicumle.Length > sayi - 3)
                yenicumle = Left(cumle, sayi - 3) + "...";

            return yenicumle;
        }
        #endregion

        #region TurkceKarakterCevir
        /// <summary>
        /// Verilen string içinden turkce karakterleri çıkarır.
        /// </summary>
        /// <param name="s">String</param>
        /// <returns>Turkce karakterlerin çıkarılmış halini döner</returns>
        public static string TurkceKarakterCevir(string s)
        {
            s = s.Replace("Ş", "S").Replace("ş", "s");
            s = s.Replace("İ", "I").Replace("ı", "i");
            s = s.Replace("Ö", "O").Replace("ö", "o");
            s = s.Replace("Ç", "C").Replace("ç", "c");
            s = s.Replace("Ğ", "G").Replace("ğ", "g");
            s = s.Replace("Ü", "U").Replace("ü", "u");
            return s;
        }
        #endregion

        #region NameValueCollection
        /// <summary>
        /// Verilen stringi NameValueCollection'a çevirir.
        /// </summary>
        /// <param name="source">String değer</param>
        /// <returns>Sonucu döner</returns>
        public static NameValueCollection StringToNameValueCollection(string source)
        {
            NameValueCollection myValues = new NameValueCollection();

            string[] aryStrings = source.Split(new char[] { '&' });
            foreach (string s in aryStrings)
            {
                string[] nameAndValue = s.Split(new char[] { '=' });
                myValues.Add(nameAndValue[0], nameAndValue[1]);
            }

            return myValues;
        }
        #endregion

        #region Replace / Remove String Between
        public static bool RemoveBetweenPos(ref string str, int startpos, int endpos)
        {
            if (startpos < 0 || startpos >= endpos)
                return false;

            str = str.Remove(startpos, endpos - startpos);
            return true;
        }

        public static bool RemoveBetween(ref string str, string start, string end)
        {
            string lstr = ToLower(str);
            string lstart = ToLower(start);
            string lend = ToLower(end);

            int istart = lstr.IndexOf(lstart);
            if (istart < 0)
                return false;

            int iend = lstr.IndexOf(lend, istart + 1);
            if (iend > -1)
                iend += end.Length;

            return RemoveBetweenPos(ref str, istart, iend);
        }

        public static bool ReplaceBetween(ref string str, string start, string end, string with)
        {
            int pos = ToLower(str).IndexOf(ToLower(start));
            if (pos < 0)
                return false;

            if (RemoveBetween(ref str, start, end))
            {
                str = str.Insert(pos, with);
                return true;
            }

            return false;
        }

        public static string StringBetweenPos(string str, int startpos, int endpos)
        {
            if (endpos <= startpos)
                return "";

            if (endpos < 0 || endpos >= str.Length)
                return "";

            if (startpos < 0 || startpos >= str.Length)
                return "";

            if (endpos == 0)
                return str.Substring(startpos);
            else
                return str.Substring(startpos, endpos - startpos + 1);
        }

        public static string StringBetween(string str, string start, string end)
        {
            return StringBetween(ref str, start, end, false);
        }

        public static string StringBetween(ref string str, string start, string end, bool remove)
        {
            string lstr = ToLower(str);
            string lstart = ToLower(start);
            string lend = ToLower(end);

            int istart = 0;
            if (!IsEmpty(lstart)) // Başlangıç belirtilmişse
            {
                istart = lstr.IndexOf(lstart);
                if (istart < 0) // Başlangıç kelimesi bulunamadı
                    return "";

                istart += lstart.Length;
            }

            int iend = 0;
            if (!IsEmpty(lend))
            {
                iend = lstr.IndexOf(lend, istart);
                if (iend < 0) // Bitiş kelimesi bulunamadı
                    return "";

                iend -= 1;
            }

            string ret = StringBetweenPos(str, istart, iend);

            if (remove && ret != "")
            {
                int remove_start = istart - start.Length;
                int remove_end = str.Length;
                if (iend > 0)
                    remove_end = iend + end.Length + 1;

                str = str.Remove(remove_start, remove_end - remove_start);
            }

            return ret;
        }
        #endregion

        #region Aciklama
        /// <summary>
        /// Açıklama cümlesi oluşturmak için kullanılır.
        /// </summary>
        /// <param name="aciklamalar">Açıklamalar</param>
        /// <returns>Açıklama cümlesi döner</returns>
        public static string AciklamaSeperator(string seperator, params string[] aciklamalar)
        {
            string aciklama = "";

            for (int i = 0; i < aciklamalar.Length; i = i + 2)
            {
                string aciklama_baslik = aciklamalar[i];
                if (bMethods.IsEmpty(aciklama_baslik))
                    continue;

                string aciklama_degeri = aciklamalar[i + 1];
                if (bMethods.IsEmpty(aciklama_degeri))
                    continue;

                if (aciklama != "")
                    aciklama += seperator;

                aciklama += aciklama_baslik + " : " + aciklama_degeri;
            }
            return aciklama;
        }

        /// <summary>
        /// Açıklama cümlesi oluşturmak için kullanılır.
        /// </summary>
        /// <param name="aciklamalar">Açıklamalar</param>
        /// <returns>Açıklama cümlesi döner</returns>
        public static string Aciklama(params string[] aciklamalar)
        {
            return AciklamaSeperator(", ", aciklamalar);
        }
        #endregion

        #endregion

        #region Boolean Methods
        /// <summary>
        /// Boolean Değerin false olmadığının kontrolünü yapar.
        /// </summary>
        /// <param name="value">Boolean Değer</param>
        /// <returns>Boolean Değerin false olmadığını döner.</returns>
        public static bool IsNotFalse(object value)
        {
            return (value == null || Convert.ToBoolean(value) != false);
        }
        #endregion

        #region DateTime Methods
        /// <summary>
        /// Tarih ve Saat birleşimini yapar.
        /// </summary>
        /// <param name="date">Tarih Bölümü</param>
        /// <param name="time">Saat Bölümü</param>
        /// <returns>Tarih+Saat değerini döner.</returns>
        public static DateTime JoinDateTime(DateTime date, DateTime time)
        {
            return new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second, time.Millisecond);
        }
        #endregion

        #region InvokeMethod
        /// <summary>
        /// Objectin bir methodunu çalıştırmak içindir.
        /// </summary>
        /// <param name="o">Obje instanceı</param>
        /// <param name="strMethod">Method Adı</param>
        /// <param name="methodParams">Parametreler</param>
        /// <returns>Method sonucunu döner</returns>
        public static object InvokeMethod(object o, string strMethod, Object[] methodParams)
        {
            try
            {
                ArrayList alParamTypes = new ArrayList();

                for (int i = 0; i < methodParams.Length; i++)
                    if (methodParams[i] != null)
                        alParamTypes.Add(methodParams[i].GetType());

                Type[] paramTypes = (Type[])alParamTypes.ToArray(typeof(Type));

                System.Reflection.MethodInfo method = null;
                if (paramTypes.Length < 1)
                    method = o.GetType().GetMethod(strMethod);
                else
                    method = o.GetType().GetMethod(strMethod, paramTypes);

                if (method == null) return null;

                return method.Invoke(o, methodParams);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("yMethods::InvokeMethod - Could not invoke : " + o.ToString() + " method.", ex);
            }
        }

        public static Type MethodReturnType(object o, string methodName, object[] methodParams)
        {
            try
            {
                ArrayList alParamTypes = new ArrayList();

                for (int i = 0; i < methodParams.Length; i++)
                    if (methodParams[i] != null)
                        alParamTypes.Add(methodParams[i].GetType());

                Type[] paramTypes = (Type[])alParamTypes.ToArray(typeof(Type));

                System.Reflection.MethodInfo method = null;
                if (paramTypes.Length < 1)
                    method = o.GetType().GetMethod(methodName);
                else
                    method = o.GetType().GetMethod(methodName, paramTypes);

                if (method == null) return null;

                return method.ReturnType;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("yMethods::MethodReturnType - Could not get : " + o.ToString() + " method return type.", ex);
            }
        }
        #endregion

        #region Get, Set Object Property
        /// <summary>
        /// Objectin propertysini almak için kullanılmıştır.
        /// </summary>
        /// <param name="o">obje instanceı</param>
        /// <param name="PropertyName">Property Adı</param>
        /// <returns>Değeri döner.</returns>
        public static object GetPropertyValue(object o, string PropertyName)
        {
            System.Reflection.PropertyInfo pI = o.GetType().GetProperty(PropertyName);
            if (pI == null)
            {
                return null;
            }

            return pI.GetValue(o, null);
        }

        /// <summary>
        /// Objectin propertysini set etmek için kullanılmıştır.
        /// </summary>
        /// <param name="o">obje instanceı</param>
        /// <param name="PropertyName">Property Adı</param>
        /// <param name="value">Property Değeri</param>
        /// <returns>İşlem başarılı ise true döner.</returns>
        public static bool SetPropertyValue(object o, string PropertyName, object value)
        {
            System.Reflection.PropertyInfo pI = o.GetType().GetProperty(PropertyName);
            if (pI == null)
                return false;

            if (value == null || value == DBNull.Value)
                value = GetNullValueForType(pI.PropertyType);

            if (value != null)
                value = Convert.ChangeType(value, pI.PropertyType);

            pI.SetValue(o, value, null);

            return true;
        }
        #endregion

        #region GetNullValueForType
        public static object GetNullValueForType(Type type)
        {
            switch (ToLower(type.Name))
            {
                case "single":
                case "byte":
                case "int32":
                case "int16":
                    return 0;

                case "boolean":
                    return false;

                case "guid":
                    return Guid.Empty;

                case "object":
                case "byte[]":
                    return null;

                case "string":
                case "char":
                    return "";

                case "datetime":
                    return DateTime.MinValue;

                case "decimal":
                case "double":
                    return 0.0;

                default:
                    throw new ApplicationException("yMethods.GetNullValueForType - Düşünülmemiş değişken tipi (System.Type) : " + type.Name);
            }
        }
        #endregion

        #region DateTime ile İlgili
        #region DateDiff
        /// <summary>
        /// İki tarih arasındaki farkı verir
        /// </summary>
        /// <param name="d1">Sonraki Tarih</param>
        /// <param name="d2">Önceki Tarih</param>
        /// <param name="years">Yıl olarak</param>
        /// <param name="months"></param>
        /// <param name="days"></param>
        public static void DateDiff(DateTime d1, DateTime d2, out int years, out int months, out int days)
        {
            // compute & return the difference of two dates, 
            // returning years, months & days 
            // d1 should be the larger (newest) of the two dates 
            // 
            // 
            //                            y  m  d 
            //  3/10/2005 <-- 3/10/2005   0  0  0 
            //  3/10/2005 <-- 3/09/2005   0  0  1 
            //  3/10/2005 <-- 3/01/2005   0  0  9 
            //  3/10/2005 <-- 2/28/2005   0  0 10 
            //  3/10/2005 <-- 2/11/2005   0  0 27 
            //  3/10/2005 <-- 2/10/2005   0  1  0 
            //  3/10/2005 <-- 2/09/2005   0  1  1 
            //  3/10/2005 <-- 7/20/1969  35  7 21 

            // we want d1 to be the larger (newest) date 
            // flip if we need to 
            if (d1 < d2)
            {
                DateTime d3 = d2;
                d2 = d1;
                d1 = d3;
            }

            // compute difference in total months 
            months = 12 * (d1.Year - d2.Year) + (d1.Month - d2.Month);

            // based upon the 'days', 
            // adjust months & compute actual days difference 
            if (d1.Day < d2.Day)
            {
                months--;
                days = GetDaysInMonth(d2.Year, d2.Month) - d2.Day + d1.Day;
            }
            else
            {
                days = d1.Day - d2.Day;
            }

            // compute years & actual months 
            years = months / 12;
            months -= years * 12;
        }

        /// <summary>
        /// Yılın belli bir ayındaki gün sayısını verir
        /// </summary>
        /// <param name="year">Yıl</param>
        /// <param name="month">Ay</param>
        /// <returns>Yılın belli bir ayındaki gün sayısını döner</returns>
        private static int GetDaysInMonth(int year, int month)
        {
            if (month < 1 || month > 12)
            {
                throw new ArgumentException("month value must be from 1-12");
            }

            //               1  2  3  4  5  6  7  8  9 10 11 12 
            int[] days = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

            if (((year / 400 * 400) == year) ||
                (((year / 4 * 4) == year) && (year % 100 != 0)))
            {
                days[2] = 29;
            }

            return days[month];
        }

        #endregion

        #region ArrangeDateTime
        /// <summary>
        /// Arranges the bad-formed date time object to a well-formed date time string.
        /// </summary>
        /// <param name="orig">The original datetime object</param>
        /// <returns>The well-formed string representation of the date time object</returns>
        public static string ArrangeDateTime(DateTime orig)
        {
            return ArrangeDateTimeX(String.Format(DataFormats.Tarih, orig.Date)) + " " + orig.ToShortTimeString();
        }

        /// <summary>
        /// Arranges a given dd.mm.yyyy string to a mm/dd/yyyy string. 
        /// </summary>
        /// <param name="original">The string to be converted</param>
        /// <returns>The resulting string</returns>
        public static string ArrangeDateTimeX(string original)
        {
            string result = "";

            int firstDot = original.IndexOf(".");
            int secondDot = original.IndexOf(".", firstDot + 1);
            result = original.Substring(firstDot + 1, secondDot - firstDot - 1) + "/" + original.Substring(0, firstDot) + "/" + original.Substring(secondDot + 1, original.Length - secondDot - 1);

            return result;
        }
        #endregion

        #region DateTimeUpperBound
        public static DateTime DateTimeLowerBound(DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, 0, 0);
        }

        public static DateTime DateTimeUpperBound(DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, 59, 997);
        }

        public static DateTime DateTimeDayMin(DateTime dt)
        {
            if (dt == DateTime.MinValue)
                return dt;

            return new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0);
        }

        public static DateTime DateTimeDayMax(DateTime dt)
        {
            if (dt == DateTime.MinValue)
                return dt;

            return new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59, 997);
        }
        #endregion
        #endregion

        #region TimeSpan ile ilgili
        #region FormatTS
        public static string FormatTS(TimeSpan ts)
        {
            if (ts == TimeSpan.MaxValue)
                return "Sonsuzluk";

            DateTime mv = DateTime.MinValue;
            if (ts.Ticks > 0)
                mv = mv.Add(ts);

            string ret = String.Format("{0}sn", mv.Second);

            if (mv.Minute > 0)
                ret = String.Format("{0}dk", mv.Minute) + " " + ret;

            if (mv.Hour > 0)
                ret = String.Format("{0}sa", mv.Hour) + " " + ret;

            if (mv.Day > 1)
                ret = String.Format("{0}gün", mv.Day - 1) + " " + ret;

            return ret;
        }
        #endregion
        #endregion

        #region Sayılar ile İlgili
        #region Round
        /// <summary>
        /// Proje için Round fonksiyonu, digits değeri kadar ondalık haneye yuvarlama yapar.
        /// </summary>
        /// <param name="value">Sayı Değeri</param>
        /// <param name="digits">Yuvarlanacak Ondalık hane sayısı</param>
        /// <returns>Yuvarlanan sayıyı döner</returns>
        public static double Round(double value, int digits)
        {
            int sign = Math.Sign(value);
            double scale = Math.Pow(10.0, digits);
            double round = Math.Floor(Math.Abs(value) * scale + 0.5);
            return (sign * round / scale);
        }

        /// <summary>
        /// Proje için Round fonksiyonu, digits değeri kadar ondalık haneye yuvarlama yapar.
        /// </summary>
        /// <param name="value">Sayı Değeri</param>
        /// <returns>Yuvarlanan sayıyı döner</returns>
        public static double Round(double value)
        {
            return Round(value, 0);
        }

        /// <summary>
        /// Proje için Round fonksiyonu, digits değeri kadar ondalık haneye yuvarlama yapar.
        /// </summary>
        /// <param name="value">Sayı Değeri</param>
        /// <param name="digits">Yuvarlanacak Ondalık hane sayısı</param>
        /// <returns>Yuvarlanan sayıyı döner</returns>
        public static decimal Round(decimal value, int digits)
        {
            return (decimal)Round((double)value, digits);
        }

        /// <summary>
        /// Proje için Round fonksiyonu, digits değeri kadar ondalık haneye yuvarlama yapar.
        /// </summary>
        /// <param name="value">Sayı Değeri</param>
        /// <returns>Yuvarlanan sayıyı döner</returns>
        public static decimal Round(decimal value)
        {
            return Round(value, 0);
        }
        #endregion

        #endregion

        #region Masking, SearchString
        /// <summary>
        /// SQL Like cümlesi için arama cümlesi oluşturmak için kullanılır.
        /// </summary>
        /// <param name="aranan">Aranacak cümle</param>
        /// <returns>Like için uygun arama cümlesini döner</returns>
        public static string SearchString(string aranan)
        {
            aranan = aranan.Trim();
            if (aranan.Length < 1)
                return "";

            if (aranan.StartsWith("*"))
                aranan = aranan.Remove(0, 1).Insert(0, "&star;");

            if (aranan.EndsWith("*"))
                aranan = aranan.Remove(aranan.Length - 1, 1).Insert(aranan.Length - 1, "&star;");

            aranan = SearchStringCheck(aranan);

            if (aranan.IndexOf("&star;") > -1)  // Eğer kullanıcı mask belirtmişse maskı % ye çevir
                aranan = aranan.Replace("&star;", "%");
            else
                aranan = "%" + aranan + "%"; // Kullanıcı mask belirtmemiş o halde içinde ara

            return aranan;
        }

        /// <summary>
        /// SQL cümlesinde kullanılacak kelimenin kontrolünü yapar.
        /// </summary>
        /// <param name="s">Search Cümlesi</param>
        /// <returns>Kontrolden çıkan cümleyi döner.</returns>
        public static string SearchStringCheck(string s)
        {
            s = s.Replace("[]", "&square0;");
            s = s.Replace("[", "&square1;");
            s = s.Replace("]", "&square2;");

            s = s.Replace("%", "[%]");
            s = s.Replace("*", "[*]");
            s = s.Replace("'", "''");

            s = s.Replace("&square0;", "[[]]");
            s = s.Replace("&square1;", "[[]");
            s = s.Replace("&square2;", "[]]");
            return s;
        }
        #endregion

        #region AddWhereCondition
        /// <summary>
        /// SQL cümlesi oluşturmakta kullanılır.
        /// Where cümlesine condition ekler.
        /// </summary>
        /// <param name="filter">Filtre Stringi</param>
        /// <param name="OPERATOR">Operator</param>
        /// <param name="condition">Condition</param>
        public static void AddWhereCondition(ref string filter, string OPERATOR, string condition)
        {
            if (condition.Trim() != "")
            {
                if (filter.Trim() != "")
                    filter += " ";

                if (filter.Trim() != "" && OPERATOR.Trim() != "")
                    filter += OPERATOR + " ";

                filter += condition;
            }
        }
        #endregion

        #region Collection Methods
        /// <summary>
        /// Collection keylerinden array döner.
        /// </summary>
        /// <param name="collection">Collection nesnesi</param>
        /// <returns>Array Döner.</returns>
        public static object[] GetCollectionKeys(IEnumerable collection)
        {
            ArrayList alKeys = new ArrayList();
            lock (collection)
            {
                IEnumerator key = collection.GetEnumerator();
                while (key.MoveNext())
                {
                    alKeys.Add(key.Current);
                }
            }

            return (object[])alKeys.ToArray(typeof(object));
        }
        #endregion
    }
}