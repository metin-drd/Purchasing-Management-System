using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Metin.Utility
{
    public class sqlFunctions
    {
        public sqlFunctions()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static SqlCommand sqlNullValueAssigner(SqlCommand command)
        {
            return sqlNullValueAssigner(command, true);
        }

        public static SqlCommand sqlNullValueAssigner(SqlCommand command, bool ToUpperCase)
        {
            foreach (SqlParameter SqlParam in command.Parameters)
            {
                if (SqlParam.Value == null)
                {
                    SqlParam.Value = DBNull.Value;
                }
                else if (SqlParam.SqlDbType == SqlDbType.Int)
                {
                    if (bConvert.ToInt32(SqlParam.Value) == 0)
                    {
                        SqlParam.Value = DBNull.Value;
                    }
                }
                else if (SqlParam.SqlDbType == SqlDbType.SmallInt)
                {
                    if (bConvert.ToInt16(SqlParam.Value) == 0)
                    {
                        SqlParam.Value = DBNull.Value;
                    }
                }
                else if (SqlParam.SqlDbType == SqlDbType.DateTime)
                {
                    if (bConvert.ToDateTime(SqlParam.Value) == DateTime.MinValue)
                    {
                        SqlParam.Value = DBNull.Value;
                    }
                }
                else if (SqlParam.SqlDbType == SqlDbType.TinyInt)
                {
                    if (bConvert.ToByte(SqlParam.Value) == 0)
                    {
                        SqlParam.Value = DBNull.Value;
                    }
                }
                else if (SqlParam.SqlDbType == SqlDbType.VarChar)
                {
                    if (bConvert.ToString(SqlParam.Value) == "")
                    {
                        SqlParam.Value = DBNull.Value;
                    }
                    else
                    {
                        SqlParam.Value = bConvert.ToString(SqlParam.Value).ToUpper(new CultureInfo("TR"));
                    }
                }
                else if (SqlParam.SqlDbType == SqlDbType.Text)
                {
                    if (bConvert.ToString(SqlParam.Value) == "")
                    {
                        SqlParam.Value = DBNull.Value;
                    }
                    else
                    {
                        if (ToUpperCase)
                            SqlParam.Value = bConvert.ToString(SqlParam.Value).ToUpper(new CultureInfo("TR"));
                        else
                            SqlParam.Value = bConvert.ToString(SqlParam.Value);

                    }
                }
                else if (SqlParam.SqlDbType == SqlDbType.Char)
                {
                    if (bConvert.ToString(SqlParam.Value) == "")
                    {
                        SqlParam.Value = DBNull.Value;
                    }
                    else
                    {
                        if (ToUpperCase)
                            SqlParam.Value = bConvert.ToString(SqlParam.Value).ToUpper(new CultureInfo("TR"));
                        else
                            SqlParam.Value = bConvert.ToString(SqlParam.Value);
                    }
                }
                else if (SqlParam.SqlDbType == SqlDbType.NText)
                {
                    if (bConvert.ToString(SqlParam.Value) == "")
                    {
                        SqlParam.Value = DBNull.Value;
                    }
                    else
                    {
                        if (ToUpperCase)
                            SqlParam.Value = bConvert.ToString(SqlParam.Value).ToUpper(new CultureInfo("TR"));
                        else
                            SqlParam.Value = bConvert.ToString(SqlParam.Value);
                    }
                }
                else if (SqlParam.SqlDbType == SqlDbType.NVarChar)
                {
                    if (bConvert.ToString(SqlParam.Value) == "")
                    {
                        SqlParam.Value = DBNull.Value;
                    }
                    else
                    {
                        if (ToUpperCase)
                            SqlParam.Value = bConvert.ToString(SqlParam.Value).ToUpper(new CultureInfo("TR"));
                        else
                            SqlParam.Value = bConvert.ToString(SqlParam.Value);
                    }
                }
            }
            return command;
        }
    }
}