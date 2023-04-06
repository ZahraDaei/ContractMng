using ContractMng.Domain.Entities;
using ContractMng.Application.Common.Mappings;



namespace ContractMng.Application.ContractMain.Contracts.Queries.Get;

public class ContractDto : IMapFrom<Contract>
{
    public int Id { get; set; }

    public string Number { get; set; }
    public string Subject { get; set; }
    public string Type { get; set; }
    public decimal Amount { get; set; }
    public string Party { get; set; }
    public string StartDate { get; set; }
    public string EndDate { get; set; }

    public decimal FinalAmount { get; set; }
    public string BudgetPlace { get; set; }
    public bool Deleted { get; set; }
}   
