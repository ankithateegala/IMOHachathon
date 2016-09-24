using System.Configuration;
using WebApplication1.Interface;

namespace WebApplication1.Util
{
    public class WebConfig : IConfigurationManager
    {
        public string ConfluenceUrl => ConfigurationManager.AppSettings["ConfluenceUrl"];
        public string PageId => ConfigurationManager.AppSettings["PageId"];
        public string ConfluenceTestUsername => ConfigurationManager.AppSettings["confluence_test_username"];
        public string ConfluenceTestPassword => ConfigurationManager.AppSettings["confluence_test_password"];
    }
}