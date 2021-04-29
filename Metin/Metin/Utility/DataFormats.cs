using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Metin.Utility
{
    /// <summary>
    /// Kullanılabilecek hazır data formatları.
    /// </summary>
    public class DataFormats
    {
        /// <summary>
        /// Standart Text Formatı
        /// </summary>
        public const string Standart = "{0}";

        /// <summary>
        /// YTL cinsinden Para formatı
        /// - değer alınca kırmızı renkte çıktı üretir
        /// </summary>
        public const string ParaYTL = "{0:#,##0.00 YTL;<font color=red>-#,##0.00 YTL</font>;0.00 YTL}";

        /// <summary>
        /// YTL cinsinden Para formatı (virgülden sonra 5 haneli)
        /// - değer alınca kırmızı renkte çıktı üretir
        /// </summary>
        public const string ParaYTL5 = "{0:#,#####0.00000 YTL;<font color=red>-#,#####0.00000 YTL</font>;0.00000 YTL}";

        /// <summary>
        /// YTL cinsinden Para formatı
        /// - değer alınca kırmızı renkte çıktı üretir
        /// </summary>
        public const string ParaYTL0 = "{0:#,##0 YTL;<font color=red>-#,##0 YTL</font>;0 YTL}";

        /// <summary>
        /// Sayı formatı decimal place olmadan
        /// </summary>
        public const string SayiDecimal0 = "{0:#,##0;<font color=red>-#,##0</font>;0}";

        /// <summary>
        /// Sayı formatı 2 adet decimal place ile
        /// - değer alınca kırmızı renkte çıktı üretir
        /// </summary>
        public const string SayiDecimal2 = "{0:#,##0.00;<font color=red>-#,##0.00</font>;0.00}";

        /// <summary>
        /// Sayı formatı 2 adet opsiyonel decimal place ile
        /// - değer alınca kırmızı renkte çıktı üretir
        /// </summary>
        public const string SayiDecimal2O = "{0:#,##0.##;<font color=red>-#,##0.##</font>;0.##}";

        /// <summary>
        /// Sayı formatı 5 adet decimal place ile
        /// - değer alınca kırmızı renkte çıktı üretir
        /// </summary>
        public const string SayiDecimal5 = "{0:#,#####0.00000;<font color=red>-#,#####0.00000</font>;0.00000}";

        /// <summary>
        /// Oran formatı 2 adet decimal place ile
        /// - değer alınca kırmızı renkte çıktı üretir
        /// </summary>
        public const string Oran2 = "% {0:#,##0.00;<font color=red>-#,##0.00</font>;0.00}";

        /// <summary>
        /// Grid Tarih Formatı
        /// </summary>
        public const string Tarih = "{0:dd.MM.yyyy}";

        /// <summary>
        /// Saat Formatı
        /// </summary>
        public const string Saat = "{0:HH:mm}";

        /// <summary>
        /// Tarih ve Saat Formatı
        /// </summary>
        public const string TarihSaat = "{0:dd.MM.yyy HH:mm}";

        /// <summary>
        /// Tarih, Saat ve Gün Formatı
        /// </summary>
        public const string TarihSaatGun = "{0:dd.MM.yyy dddd HH:mm}";

        /// <summary>
        /// Zaman aralığı formatı
        /// </summary>
        public const string ZamanAraligi = "{0:HH:mm:ss}";
    }
}