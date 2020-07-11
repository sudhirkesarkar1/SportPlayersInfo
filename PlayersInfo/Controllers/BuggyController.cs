using Microsoft.AspNetCore.Mvc;
using PlayersInfo.EntityModelsData.Data;
using PlayersInfo.Errors;

namespace PlayersInfo.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly ApiDbContext _dbContext;
        public BuggyController(ApiDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            var thing = _dbContext.Players.Find(42);

            var thingToReturn = thing.ToString();

            return Ok();
        }

        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }

        [HttpGet("badrequest/{id}")]
        public ActionResult GetNotFoundRequest(int id)
        {
            return Ok();
        }
    }
}