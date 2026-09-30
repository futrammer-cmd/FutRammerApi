using FutRammerApi.Shared.Events;

namespace FutRammerApi.Application.Common.Events;

public interface IEventPublisher : ITransientService
{
    Task PublishAsync(IEvent @event);
}