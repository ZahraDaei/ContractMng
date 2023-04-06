using ContractMng.Domain.Entities;
using ContractMng.Application.Common.Mappings;



namespace ContractMng.Application.ContractBase.ContractDocuments.Queries.Get;

public class ContractDocumentDto : IMapFrom<ContractDocument>
{
    public int Id { get; set; }

    public string Document { get; set; }

}
