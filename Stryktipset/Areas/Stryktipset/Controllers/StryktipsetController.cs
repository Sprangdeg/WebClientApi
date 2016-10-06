using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Cors;
using System.Web.Http;
using stryktipsetLibrary;
using stryktipsetLibrary.EngineNameSpace;
using stryktipsetLibrary.Models;

namespace Stryktipset.Areas.Stryktipset.Controllers
{
    public class StryktipsetController : ApiController
    {
        // GET: Stryktipset/Stryktipset
       // [EnableCors(origins: "http://localhost:4200, http://bonstrom.se", headers: "*", methods: "*")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]
        public StryktipsMatches GetMatches()
        {
            ResourceAccess RA = new ResourceAccess();
            var coupong = RA.GetStryktipsCoupon();
            return coupong;
        }

		[EnableCors(origins: "*", headers: "*", methods: "*")]
		[HttpGet]
		public List<CouponRow> EvaluateCoupong()
		{
			ResourceAccess RA = new ResourceAccess();
			Engine engine = new Engine();
			var coupong = RA.GetStryktipsCoupon();
			var goldenTicket = engine.EvaluateStryktipset(coupong);

			List<rows> rows;

			return goldenTicket.Matches.ToList();
		}

	    public class rows
	    {
		    public bool HomeMark { get; set; }
			public bool DrawMark { get; set; }
			public bool AwayMark { get; set; }

		    public rows(CouponRow cr)
		    {
			    HomeMark = cr.One;
		    }
		}
	}
}