using ContractMng.Application.ContractMain.Contracts.Queries.Get;

namespace ContractMng.Application.Reports.ReportByParties.Get;

public class ReportByPartyDto
{
    public string ContractParty { get; set; }
    public int PartyId { get; set; }
    public string ContractType { get; set; }
    public IEnumerable<ContractDto> Contracts { get; set; }
}