using ContractMng.Domain.Entities;
using ContractMng.Application.Common.Mappings;



namespace ContractMng.Application.ContractMain.Letters.Queries.Get;

public class LetterDto : IMapFrom<Letter>
{
    public int Id { get; set; }
    public string Type { get; set; }
    public string Subject { get; set; }
    public string Number { get; set; }
    public string LetterDate { get; set; }
    public string ContractNumber { get; set; }
}   
