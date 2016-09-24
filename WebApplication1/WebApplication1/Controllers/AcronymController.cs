using System;
using System.Threading.Tasks;
using System.Web.Http;
using WebApplication1.Interface;

namespace WebApplication1.Controllers
{
    [RoutePrefix("api/Acronyms")]
    public class AcronymController : ApiController
    {
        private readonly IConfigurationManager _webConfig;
        public AcronymController(): this (new ConfluenceFactory()) { }

        private AcronymController(ConfluenceFactory confluenceFactory)
        {
            if (confluenceFactory == null)
            {
                throw new ArgumentNullException(nameof(confluenceFactory));
            }
            _webConfig = confluenceFactory.WebConfig;
        }


        [Route("")]
        public async Task GetAcronyms()
        {

        }

    }
}
