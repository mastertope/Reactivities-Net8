using Application.Activities.Commands;
using Application.Activities.Queries;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        [HttpGet] //api/activities
        public async Task<IActionResult> GetActivities()
        {
            return HandleResult(await Mediator.Send(new GetActivityList.Query()));
        }

        [HttpGet("{id}")] //api/activities/id
        public async Task<IActionResult> GetActivity(string id)
        {
            return HandleResult(await Mediator.Send(new GetActivityDetails.Query { Id = id }));
        }

        [HttpPost] 
        public async Task<IActionResult> CreateActivity(Activity activity)
        {
            return HandleResult(await Mediator.Send(new CreateActivity.Command { Activity = activity }));
        }

        [HttpPut]
        public async Task<IActionResult> EditActivity(Activity activity)
        {
            return HandleResult(await Mediator.Send(new EditActivity.Command { Activity = activity }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(string id)
        {
            return HandleResult(await Mediator.Send(new DeleteActivity.Command { Id = id }));
        }
    }
}
