namespace ContractMng.Domain.Entities;

public class Letter : AuditableEntity
{
    public int Id { get; set; }
    public string Type { get; set; }
    public string Subject { get; set; }
    public string Number { get; set; }
    public string LetterDate { get; set; }
    public int ContractId { get; set; }
    public bool Deleted { get; set; }
    public Contract Contract { get; set; }


}
