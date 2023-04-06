using ContractMng.Domain.Entities;
using ContractMng.Application.Common.Mappings;



namespace ContractMng.Application.ContractBase.ContractBudgets.Queries.Get;

public class ContractBudgetDto : IMapFrom<ContractBudget>
{
    public int Id { get; set; }

    public string PlaceOfBudget { get; set; }
    public string SchemaNumber { get; set; }
}   
