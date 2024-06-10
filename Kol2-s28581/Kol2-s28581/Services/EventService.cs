using Kol2_s28581.Repositories;

namespace Kol2_s28581.Services;

public class EventService : IEventService
{
    private readonly IEventRepository _eventRepository;

    public EventService(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }


    public async Task<bool> isEventSafeToDelete(int IdEvent, CancellationToken cancellationToken)
    {
        var eventToDelete = await _eventRepository.GetEvent(IdEvent, cancellationToken);

        if (DateTime.Now >= eventToDelete.DateFro)
            return false;
        if (eventToDelete.DateTo == null)
            return false;
        int mainOrganisersCount = await _eventRepository.CountMainOrganisers(eventToDelete, cancellationToken);
        if (mainOrganisersCount > 3)
            return false;
        return true;
    }
}