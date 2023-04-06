using ContractMng.Application.Common.Interfaces;

namespace ContractMng.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
