using System.Collections.Generic;
using System.Web;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ValuesController : ApiController
    {
        [Route("api/GetBanks")]
        public IEnumerable<BankBaseModel> GetBanks()
        {
            return BanksLogic.GetBankList();
        }

        [Route("api/GetElixirTime")]
        public IHttpActionResult Post([FromBody]TransferModel incommingModel)
        {
            var elixirTime = BanksLogic.CalculateEliksirTime(incommingModel);
            return Ok(new { TransferTime = elixirTime });
        }
    }
}
