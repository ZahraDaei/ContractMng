using ContractMng.Domain.Entities;
using ContractMng.Application.Common.Mappings;



namespace ContractMng.Application.ContractBase.ContractLetters.Queries.Get;

public class ContractLetterDto : IMapFrom<ContractLetter>
{
    public int Id { get; set; }

    public string LetterType { get; set; }

}
