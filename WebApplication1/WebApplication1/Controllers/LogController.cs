using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using Confluence.Model;
using WebApplication1.Interface;
using WebApplication1.Util;

namespace WebApplication1.Controllers
{
    [RoutePrefix("Api/Log")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LogController : ApiController
    {
        private readonly DatabaseHelper _databaseHelper;

        public LogController(): this (new ConfluenceFactory()) { }

        private LogController(ConfluenceFactory confluenceFactory)
        {
            if (confluenceFactory == null)
            {
                throw new ArgumentNullException(nameof(confluenceFactory));
            }
            _databaseHelper = new DatabaseHelper(confluenceFactory);
        }

        [Route("")]
        public void PostHistoryLog(string AcronymName)
        {
            var currentLog = _databaseHelper.GetHistoryLogbyName(AcronymName);
            var historyLogs  = currentLog as HistoryLog[] ?? currentLog.ToArray();
            if (!historyLogs.Any())
            {
                _databaseHelper.InsertHistoryLog(historyLogs.First());
            }
            else
            {
                _databaseHelper.UpdateHistoryLog(historyLogs.First());
            }
        }


        [Route("")]
        public IEnumerable<HistoryLog> GetHistoryLog()
        {
            return _databaseHelper.GetHistoryLog();
        }
    }
}
