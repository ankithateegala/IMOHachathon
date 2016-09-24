using System;
using System.DirectoryServices;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    [RoutePrefix("User")]
    public class UserController : ApiController
    {

        [Route]
        public bool Authenticated()
        {
            return IsAuthenticated(@"http://imohackathon-1.xrzyyed2vm.us-west-2.elasticbeanstalk.com", "jwang","");
        }

        public bool IsAuthenticated(string srvr, string usr, string pwd)
        {
            var authenticated = false;

            try
            {
                var entry = new DirectoryEntry(srvr, usr, pwd);
                var nativeObject = entry.NativeObject;
                authenticated = true;
            }
            catch (DirectoryServicesCOMException cex)
            {
                //not authenticated; reason why is in cex
            }
            catch (Exception ex)
            {
                //not authenticated due to some other exception [this is optional]
            }

            return authenticated;
        }
    }
}
