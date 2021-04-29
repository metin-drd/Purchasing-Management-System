using System;
using System.IO;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


public class bConvert
{
    public static string ToString(object value)
    {
        try
        {
            string temp = Convert.ToString(value);
            if (temp.Length > 0)
                return temp;
            else
                return "";
        }
        catch
        {
            return "";
        }
    }

    public static string ToLikeString(object value)
    {
        try
        {
            string temp = Convert.ToString(value);
            if (temp.Length > 0)
                return "%" + temp + "%";
            else
                return "";
        }
        catch
        {
            return "";
        }
    }

    public static Int64 ToInt64(object value)
    {
        try
        {
            Int64 temp = Convert.ToInt64(value);
            return temp;
        }
        catch
        {
            return 0;
        }
    }

    public static Int32 ToInt32(object value)
    {
        try
        {
            Int32 temp = Convert.ToInt32(value);
            return temp;
        }
        catch
        {
            return 0;
        }
    }

    public static Int16 ToInt16(object value)
    {
        try
        {
            Int16 temp = Convert.ToInt16(value);
            return temp;
        }
        catch
        {
            return 0;
        }
    }

    public static Double ToDouble(object value)
    {
        try
        {
            Double temp = Convert.ToDouble(value);
            if (temp > 0)
                return temp;
            else
                return 0;
        }
        catch
        {
            return 0;
        }
    }

    public static bool ToBoolean(object value)
    {
        try
        {
            bool temp = Convert.ToBoolean(value);
            if (temp == true)
                return true;
            else
                return false;
        }
        catch
        {
            return false;
        }
    }

    public static byte ToByte(object value)
    {
        try
        {
            byte temp = Convert.ToByte(value);
            if (temp > 0)
                return temp;
            else
                return 0;
        }
        catch
        {
            return 0;
        }
    }

    public static DateTime ToDateTime(object value)
    {
        try
        {
            DateTime temp = Convert.ToDateTime(value);
            if (temp > DateTime.MinValue)
                return temp;
            else
                return DateTime.MinValue;
        }
        catch
        {
            return DateTime.MinValue;
        }
    }

    public static DateTime ToDateTimeUpper(object value)
    {
        try
        {
            DateTime temp = Convert.ToDateTime(value);
            if (temp > DateTime.MinValue)
                return temp.Add(new TimeSpan(23, 59, 59));
            else
                return DateTime.MinValue;
        }
        catch
        {
            return DateTime.MinValue;
        }
    }

    public static DateTime ToDateTimeLower(object value)
    {
        try
        {
            DateTime temp = Convert.ToDateTime(value);
            if (temp > DateTime.MinValue)
                return temp.Date;
            else
                return DateTime.MinValue;
        }
        catch
        {
            return DateTime.MinValue;
        }
    }

    public static decimal ToDecimal(object value)
    {
        try
        {
            decimal temp = Convert.ToDecimal(value);
            if (temp > 0)
                return temp;
            else
                return 0;
        }
        catch
        {
            return 0;
        }
    }
}