using System.Web.Http.Cors;
using System.Web.Http;
using stryktipsetLibrary;
using stryktipsetLibrary.Models;

namespace Stryktipset.Areas.Stryktipset.Controllers
{
    public class StryktipsetController : ApiController
    {
        // GET: Stryktipset/Stryktipset
        [EnableCors(origins: "http://localhost:4200, http://bonstrom.se", headers: "*", methods: "*")]
        [System.Web.Http.HttpGet]
        public StryktipsMatches Index()
        {
            ResourceAccess RA = new ResourceAccess();
            var coupong = RA.GetStryktipsCoupon();
            return coupong;
        }
    }
}