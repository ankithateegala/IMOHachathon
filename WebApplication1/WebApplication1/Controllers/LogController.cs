using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Confluence.Model;
using WebApplication1.Interface;
using WebApplication1.Util;

namespace WebApplication1.Controllers
{
    [RoutePrefix("Api/Log")]
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
        public void PostHistoryLog(HistoryLog log)
        {
            var CurrentLog = _databaseHelper.GetHistoryLogbyName(log.AcronymName);
            if (!CurrentLog.Any())
            {
                _databaseHelper.InsertHistoryLog(log);
            }
            else
            {
                _databaseHelper.UpdateHistoryLog(log);
            }
        }


        [Route("")]
        public IEnumerable<HistoryLog> GetHistoryLog()
        {
            return _databaseHelper.GetHistoryLog();
        }
    }
}
