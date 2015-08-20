using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestCSharp.Reporting
{
    public class ReportHelper
    {
        public enum ContentTypes
        {
            unspecified_data,
            csv,
            docx,
            jpg,
            pdf,
            text,
            xml,
            zip
        }
        public static string GetContentType(ContentTypes contentType)
        {
            string sResult = "";
            switch (contentType)
            {
                case ContentTypes.csv:
                    sResult = "text/csv";
                    break;
                case ContentTypes.docx:
                    sResult = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                    break;
                case ContentTypes.jpg:
                    sResult = "image/jpg";
                    break;
                case ContentTypes.pdf:
                    sResult = "application/pdf";
                    break;
                case ContentTypes.text:
                    sResult = "text/plain";
                    break;
                case ContentTypes.xml:
                    sResult = "text/xml";
                    break;
                case ContentTypes.zip:
                    sResult = "application/zip";
                    break;
                default:
                    sResult = "application/octet-stream";
                    break;
            }
            return sResult;
        }

        public static FileStreamResult CreateFileStreamResult(byte[] documentBytes, string outputName, ContentTypes contentType)
        {
            MemoryStream oStream = new MemoryStream();
            oStream.Write(documentBytes, 0, (int)documentBytes.Length);
            oStream.Position = 0;
            return CreateFileStreamResult(oStream, outputName, contentType);
        }
        public static FileStreamResult CreateFileStreamResult(Stream document, string outputName, ContentTypes contentType)
        {
            string sMimeType = GetContentType(contentType);
            FileStreamResult oResult = new FileStreamResult(document, sMimeType);
            oResult.FileDownloadName = outputName;
            return oResult;
        }

        public static void ResponseFile(byte[] documentBytes, string filename, ContentTypes contentType)
        {
            string sMimeType = GetContentType(contentType);

            HttpContext oContext = HttpContext.Current;
            oContext.Response.Clear();
            oContext.Response.ContentType = sMimeType;
            oContext.Response.Cache.SetCacheability(HttpCacheability.Private);
            oContext.Response.Expires = -1;
            oContext.Response.Buffer = false;
            oContext.Response.AddHeader("Content-Disposition", string.Format("{0};FileName=\"{1}\"", "attachment", filename));
            oContext.Response.OutputStream.Write(documentBytes, 0, documentBytes.Length);
            oContext.Response.End();
        }
    }
}