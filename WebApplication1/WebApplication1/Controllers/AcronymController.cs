﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Confluence.Model;
using WebApplication1.Interface;
using WebApplication1.Util;

namespace WebApplication1.Controllers
{
    [RoutePrefix("api/Acronyms")]
    public class AcronymController : ApiController
    {
        private readonly IConfigurationManager _webConfig;
        private readonly DatabaseHelper _databaseHelper;

        public AcronymController(): this (new ConfluenceFactory()) { }

        private AcronymController(ConfluenceFactory confluenceFactory)
        {
            if (confluenceFactory == null)
            {
                throw new ArgumentNullException(nameof(confluenceFactory));
            }
            _webConfig = confluenceFactory.WebConfig;
            _databaseHelper = new DatabaseHelper(confluenceFactory);
        }


        [Route("")]
        public IEnumerable<AcronymsInfo> GetAcronyms()
        {
           return _databaseHelper.GetAcronymsInfo();
        }

    }
}
