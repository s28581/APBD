using Kol2_s28581.Context;
using Kol2_s28581.Models;
using Kol2_s28581.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kol2_s28581.Controllers;
[Route("api/eventy")]
[ApiController]
public class EventController : ControllerBase
{
    private readonly DataContext _context;
    private readonly IEventService _eventService;

    public EventController(DataContext context, IEventService eventService)
    {
        _context = context;
        _eventService = eventService;
    }


    [HttpDelete("{IdEvent}")]
    public async Task<IActionResult> DeleteEvent(int IdEvent)
    {
        var isEventSafeToDeleteEventToDelete = await _eventService.isEventSafeToDelete(IdEvent, CancellationToken.None);
        if (isEventSafeToDeleteEventToDelete)
        {
            var eventToRemove = new Event
            {
                IdEvent = IdEvent
            };
            _context.Events.Attach(eventToRemove);
            var entry = _context.Entry(eventToRemove);
            entry.State = EntityState.Deleted;

            await _context.SaveChangesAsync();
            return Ok("Event został usuniety");
        }

        return BadRequest("nastąpił proble Event nie został usunięty");
    }

}