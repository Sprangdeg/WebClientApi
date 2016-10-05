using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Cors;
using System.Web.Http;
using stryktipsetLibrary;
using stryktipsetLibrary.EngineNameSpace;
using stryktipsetLibrary.Models;
using System.Runtime.Serialization;

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
		public List<Row> EvaluateCoupong()
		{
			ResourceAccess RA = new ResourceAccess();
			Engine engine = new Engine();
			var coupong = RA.GetStryktipsCoupon();
			var goldenTicket = engine.EvaluateStryktipset(coupong);

			List<Row> rows = goldenTicket.Matches.Select(x => new Row(x)).ToList();

			return rows;
		}

        [DataContract]
	    public class Row
	    {
            [DataMember]
		    public bool HomeMark { get; set; }
            [DataMember]
            public bool DrawMark { get; set; }
            [DataMember]
            public bool AwayMark { get; set; }

		    public Row(CouponRow cr)
		    {
			    HomeMark = cr.One;
                DrawMark = cr.Cross;
                AwayMark = cr.Two;
            }
		}
	}
}