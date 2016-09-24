using WebApplication1.Util;

namespace WebApplication1.Interface
{
    public  class ConfluenceFactory: IFactory
    {
        public IConfigurationManager WebConfig => new WebConfig();
        public IFileReader Files => new FileReader();
        public IDapper Dapper => new DapperHelper();
    }
}
