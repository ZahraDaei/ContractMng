using ContractMng.Domain.Entities;
using ContractMng.Application.Common.Mappings;



namespace ContractMng.Application.ContractBase.ContractLastStatuses.Queries.Get;

public class ContractLastStatusDto : IMapFrom<ContractLastStatus>
{
    public int Id { get; set; }

    public string Status { get; set; }

}
