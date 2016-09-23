using System.Collections.Generic;
using System.Web.Http;
using Confluence.Model;

namespace WebApplication1.Controllers
{
    [RoutePrefix("api/Acronyms")]
    public class AcronymController : ApiController
    {
        [Route("")]
        public IEnumerable<AcronymsInfo> GetAcronyms()
        {
            
        }

    }
}
