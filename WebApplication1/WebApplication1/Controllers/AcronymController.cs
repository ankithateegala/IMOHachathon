using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using Confluence.Model;
using WebApplication1.Interface;
using WebApplication1.Util;

namespace WebApplication1.Controllers
{
    [RoutePrefix("api/Acronyms")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
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
           var acronyms = _databaseHelper.GetAcronymsInfo();
            foreach (var acronym in acronyms)
            {
                acronym.Links = _databaseHelper.GetLinksById(acronym.ABSTRACT_CODE);
            }
            return acronyms;
        }

    }
}
