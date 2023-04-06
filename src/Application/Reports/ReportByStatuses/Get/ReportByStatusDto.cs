
using ContractMng.Application.ContractMain.Contracts.Queries.Get;

namespace ContractMng.Application.Reports.ReportByStatuses.Get;

public class ReportByStatusDto
{
    public int? ContractLastStatusId { get; set; }
    public string? Status { get; set; }
    public IEnumerable<ContractDto>? Contracts { get; set; }
}