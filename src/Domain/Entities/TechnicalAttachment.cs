namespace ContractMng.Domain.Entities;

public class TechnicalAttachment : AuditableEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Number { get; set; }
    public int ContractId { get; set; }
    public string FileName { get; set; }
    public string FilePath { get; set; }
    public bool Deleted { get; set; }
    public Contract Contract { get; set; }
}
