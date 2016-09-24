using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Confluence.Model;
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

        public IEnumerable<AcronymsInfo> GetAcronymsInfo()
        {
            var response = _dapper.Query<AcronymsInfo>(_configuration.RdssqlServerConnection, _fileReader.GetFile(_configuration.GetAcronyms));
            return response;
        }

        public IEnumerable<HistoryLog> GetHistoryLogbyName(string name)
        {
            var response = _dapper.Query<HistoryLog>(_configuration.RdssqlServerConnection, _fileReader.GetFile(_configuration.GetHistoryLogbyName), new { ACRONYMName = name});
            return response;
        }

        public IEnumerable<HistoryLog> GetHistoryLog()
        {
            var response = _dapper.Query<HistoryLog>(_configuration.RdssqlServerConnection, _fileReader.GetFile(_configuration.GetHistoryList));
            return response;
        }

        public void InsertHistoryLog(HistoryLog log)
        {
             _dapper.Execute(_configuration.RdssqlServerConnection, _fileReader.GetFile(_configuration.InsertHistoryLog), new { ACRONYMName = log.AcronymName, AppearTimes =log.AppearTimes});
        }

        public void UpdateHistoryLog(HistoryLog log)
        {
            _dapper.Execute(_configuration.RdssqlServerConnection, _fileReader.GetFile(_configuration.UpdateHistoryLog), new { ACRONYMName = log.AcronymName, AppearTimes = log.AppearTimes + 1 });
        }

        public IEnumerable<string> GetLinksById(int id)
        {
            var response = _dapper.Query<string>(_configuration.RdssqlServerConnection, _fileReader.GetFile(_configuration.GetLinksById), new { ABSTRACT_CODE = id });
            return response;
        }

        public IEnumerable<string> GetRelatedById(int id)
        {
            var response = _dapper.Query<string>(_configuration.RdssqlServerConnection, _fileReader.GetFile(_configuration.GetRelatedById), new { ABSTRACT_CODE = id });
            return response;
        }
    }
}
