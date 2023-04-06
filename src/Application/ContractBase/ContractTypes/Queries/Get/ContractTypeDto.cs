using ContractMng.Domain.Entities;
using ContractMng.Application.Common.Mappings;



namespace ContractMng.Application.ContractBase.ContractTypes.Queries.Get;

public class ContractTypeDto : IMapFrom<ContractType>
{
    public int Id { get; set; }

    public string Type { get; set; }

}
