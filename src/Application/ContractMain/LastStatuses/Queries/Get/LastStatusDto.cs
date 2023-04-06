using ContractMng.Domain.Entities;
using ContractMng.Application.Common.Mappings;



namespace ContractMng.Application.ContractMain.LastStatuses.Queries.Get;

public class LastStatusDto : IMapFrom<LastStatus>
{
    public int Id { get; set; }

    public string Date { get; set; }
    public string Progress { get; set; }
    public decimal Amount { get; set; }
    public int AmountNumber { get; set; }
    public string ContractNumber { get; set; }
}   
