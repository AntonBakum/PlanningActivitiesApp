using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain;
using Application.Activities;

namespace API.Controllers
{
    public class ActivitiesController: BaseApiController
    {
       

        [HttpGet]

        public async Task<ActionResult<List<Activity>>> GetActivitiesAsync()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivityByIdAsync(Guid id)
        {
            return await Mediator.Send (new Details.Query {Id = id});
        }

        [HttpPost]
        public async Task<IActionResult> CreateActivityAsync (Activity activity)
        {
            return Ok(await Mediator.Send(new Create.Command {Activity = activity}));
        }
        [HttpPut("{id}")]
        
        public async Task<IActionResult> EditActivityAsync (Guid id, Activity activity)
        { 
            activity.Id = id;
            return Ok (await Mediator.Send(new Edit.Command {Activity = activity}));
        }
        [HttpDelete("{id}")]
        
        public async Task<IActionResult> DeleteActivityAsync(Guid id)
        {
            return Ok (await Mediator.Send(new Delete.Command {Id = id}));
        }
    }
}
