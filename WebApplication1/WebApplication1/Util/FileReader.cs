using System;
using System.IO;
using System.Web.Hosting;
using WebApplication1.Interface;

namespace WebApplication1.Util
{
    public class FileReader : IFileReader
    {
        private readonly IConfigurationManager _webconfig = new WebConfig();

        public string GetFile(string fileName)
        {
            var content = "";
            // ReSharper disable once AssignNullToNotNullAttribute
            using (var sr = new StreamReader(HostingEnvironment.MapPath(_webconfig.SqlQueryPath + fileName)))
            {
                var line = sr.ReadToEnd();
                content = line.Replace(Environment.NewLine, " ");
            }
            return content;
        }
    }
}
