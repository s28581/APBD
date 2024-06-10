namespace Kol2_s28581.Services;

public interface IEventService
{
    Task<bool> isEventSafeToDelete(int IdEvent, CancellationToken cancellationToken);
}