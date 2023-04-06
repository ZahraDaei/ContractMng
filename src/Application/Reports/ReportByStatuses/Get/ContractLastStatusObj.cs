using ContractMng.Domain.Entities;

namespace ContractMng.Application.Reports.ReportByStatuses.Get;
public class ContractLastStatusObj
{
    public string Subject { get; set; }
    public string Number { get; set; }
    public decimal ContractAmount { get; set; }
    public decimal FinalAmount { get; set; }  
    public ContractLastStatus Status { get; set; }

}