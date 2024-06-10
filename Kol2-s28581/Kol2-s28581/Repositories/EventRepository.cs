using System.Net.Security;
using Kol2_s28581.Context;
using Kol2_s28581.DTOs;
using Kol2_s28581.Models;
using Microsoft.EntityFrameworkCore;

namespace Kol2_s28581.Repositories;

public class EventRepository : IEventRepository
{

    private readonly DataContext _context;

    public EventRepository(DataContext context)
    {
        _context = context;
    }

    /*public async Task<ICollection<EventDTO>> GetEvents(bool withDateTo)
    {
        List<EventDTO> Events = await _context.Events.Join()
    }*/

    public async Task<int> CountMainOrganisers(Event eve, CancellationToken cancellationToken)
    {
        int result = await _context.EventOrganisers.Where(x => x.IdEvent == eve.IdEvent && x.MainOrganiser == true)
            .CountAsync(cancellationToken);
        return result;
    }
    
    public async Task<Event> GetEvent(int idEvent, CancellationToken cancellationToken)
    {
        var result = await _context.Events.Where(x => x.IdEvent == idEvent).FirstOrDefaultAsync(cancellationToken);
        
        return result;
    }
}