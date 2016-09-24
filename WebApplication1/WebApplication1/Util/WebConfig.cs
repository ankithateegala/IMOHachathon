using Confluence.Model;
using System.Configuration;
using WebApplication1.Interface;

namespace WebApplication1.Util
{
    public class WebConfig : IConfigurationManager
    {
        public string RdssqlServerConnection => ConfigurationManager.ConnectionStrings["RDSSQLServerConnection"].ConnectionString;
        public string SqlQueryPath => ConfigurationManager.AppSettings["SqlQueryPath"];
        public string GetAcronyms => ConfigurationManager.AppSettings["GetAcronyms"];
    }

}