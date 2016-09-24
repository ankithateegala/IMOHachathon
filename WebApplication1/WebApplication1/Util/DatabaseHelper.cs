using System;
using WebApplication1.Interface;

namespace WebApplication1.Util
{
    public class DatabaseHelper
    {
        private readonly IDapper _dapper;
        private readonly IFileReader _fileReader;
        private readonly IConfigurationManager _configuration;

        public DatabaseHelper(IFactory factory)
        {
            if (factory == null)
            {
                throw new ArgumentNullException(nameof(factory));
            }
            _dapper = factory.Dapper;
            _fileReader = factory.Files;
            _configuration = factory.WebConfig;
        }
    }
}
