namespace ContractMng.Domain.Entities;

public class ContractLetter : AuditableEntity
{
    public int Id { get; set; }
    public string LetterType { get; set; }

}
