using BAL.Repository;
using DAL.Models;
using DAL.UtiliyRepository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BMS_Web.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        EntryRepository entryrepo;
        public static IList<AmEntryLog> AmEntryLogs = null;
        public static List<AmStamp> AmStamps = null;

        public ValuesController()
        {
            entryrepo = new EntryRepository(new BmsContext());
            AmStamps = new List<AmStamp>();
            AmEntryLogs = new List<AmEntryLog>();
            AmStamps.AddRange(entryrepo.TimeStamp(""));
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { UtilityRepositories.GetAppSettings(""), UtilityRepositories.GetAppSettings("") };
        }

        //// GET api/<ValuesController>/5

        //[HttpGet("{_StampBase64},{_StampByte}")]
        //public AmStamp GetTimeStamp(string _StampBase64, byte[] _StampByte)

        //[HttpGet("{_StampBase64}")]
        //public JsonResult GetTimeStamp(string _StampBase64)
        //{
        //    entryrepo.TimeStamp(_StampBase64);

        //    return new JsonResult(UtilityRepositories.ApiStatusCode.Success);
        //}

        // GET api/<ValuesController>/5

        [HttpPost]
        [Route("GetTimeStamp")]
        public AmStamp GetTimeStamp(AmStamp stamp)
        {


            stamp = UtilityRepositories.MatchStamp(AmStamps, stamp);
            if (stamp != null)
                AmEntryLogs.Add(entryrepo.EntryTimeStamp(stamp));
            stamp.Comments = UtilityRepositories.ApiStatusCode.Success.ToString();
            return stamp;

            //return UtilityRepositories.MatchStamp(entryrepo.TimeStamp(stamp.StampString), stamp);

            //return new JsonResult(UtilityRepositories.ApiStatusCode.Success);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
