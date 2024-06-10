using Kol2_s28581.DTOs;
using Kol2_s28581.Models;

namespace Kol2_s28581.Repositories;

public interface IEventRepository
{
    //Task<ICollection<EventDTO>> GetEvents(bool withDateTo);
    Task<Event> GetEvent(int idEvent, CancellationToken cancellationToken);
    Task<int> CountMainOrganisers(Event eve, CancellationToken cancellationToken);
}