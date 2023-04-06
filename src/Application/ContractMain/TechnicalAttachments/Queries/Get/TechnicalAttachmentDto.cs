using ContractMng.Domain.Entities;
using ContractMng.Application.Common.Mappings;



namespace ContractMng.Application.ContractMain.TechnicalAttachments.Queries.Get;

public class TechnicalAttachmentDto : IMapFrom<TechnicalAttachment>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Number { get; set; }
    public string ContractNumber { get; set; }
}   
