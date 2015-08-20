using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace TestCSharp.Reporting
{
    public class CsvHelper
    {
        public static FileStreamResult ResponseCsv<T>(List<T> list, string filename, string separator, bool insertHeader)
            where T : class
        {
            System.Reflection.PropertyInfo[] oProperties = typeof(T).GetProperties();
            StringBuilder oSB = new StringBuilder();

            if (insertHeader)
            {
                for (int i = 0; i < oProperties.Length; i++)
                {
                    if (i > 0) oSB.Append(separator);
                    oSB.Append(GetWriteableValue(oProperties[i].Name, separator));
                }
                oSB.AppendLine();
            }

            foreach (T oRecord in list)
            {
                for (int i = 0; i < oProperties.Length; i++)
                {
                    if (i > 0) oSB.Append(separator);
                    oSB.Append(GetWriteableValue(oProperties[i].GetValue(oRecord), separator));
                }
                oSB.AppendLine();
            }
            string sResult = oSB.ToString();
            MemoryStream oStream = new MemoryStream(Encoding.UTF8.GetBytes(sResult));
            return ReportHelper.CreateFileStreamResult(oStream, filename, ReportHelper.ContentTypes.csv);
        }

        public static string GetWriteableValue(object source, string separator)
        {
            if (source == null)
            {
                return "";
            }
            string sValue = source.ToString();
            if (sValue.IndexOf(separator) == -1)
            {
                return sValue;
            }
            return "\"" + sValue + "\"";
        }
    }
}