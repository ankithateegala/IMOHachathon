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
        public string GetHistoryLogbyName => ConfigurationManager.AppSettings["GetHistoryLogbyName"];
        public string GetHistoryList => ConfigurationManager.AppSettings["GetHistoryList"];
        public string InsertHistoryLog => ConfigurationManager.AppSettings["InsertHistoryLog"];
        public string UpdateHistoryLog => ConfigurationManager.AppSettings["UpdateHistoryLog"];
        public string GetLinksById => ConfigurationManager.AppSettings["GetLinksById"];
        public string GetRelatedById => ConfigurationManager.AppSettings["GetRelatedById"];
    }

}