using ContractMng.Domain.Common;

namespace ContractMng.Application.Common.Interfaces;

public interface IDomainEventService
{
    Task Publish(DomainEvent domainEvent);
}
