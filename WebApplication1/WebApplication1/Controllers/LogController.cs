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

            if (!currentLog.Any())
            {
                _databaseHelper.InsertHistoryLog(new HistoryLog {AcronymName = AcronymName, AppearTimes = 1});
            }
            else
            {
                _databaseHelper.UpdateHistoryLog(currentLog.First());
            }
        }


        [Route("")]
        public IEnumerable<HistoryLog> GetHistoryLog()
        {
            return _databaseHelper.GetHistoryLog();
        }
    }
}
