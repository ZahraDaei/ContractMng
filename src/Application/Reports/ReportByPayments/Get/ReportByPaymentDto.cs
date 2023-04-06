using ContractMng.Application.ContractMain.LastStatuses.Queries.Get;

namespace ContractMng.Application.Reports.ReportByPayments.Get;
public class ReportByPaymentDto
{
    

    public string Number { get; set; }
    public decimal Amount { get; set; }
    public decimal FinalAmount { get; set; }
    public string Subject { get; set; }
    public string Type { get; set; }
    public IEnumerable<LastStatusDto> Payments { get; set; }
    public int ContractId { get;  set; }
}