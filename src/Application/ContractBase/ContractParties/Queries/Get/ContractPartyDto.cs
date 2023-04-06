using ContractMng.Domain.Entities;
using ContractMng.Application.Common.Mappings;



namespace ContractMng.Application.ContractBase.ContractParties.Queries.Get;

public class ContractPartyDto : IMapFrom<ContractParty>
{
    public int Id { get; set; }

    public string PartyName { get; set; }
    public int ContractTypeId { get; set; }
}   
