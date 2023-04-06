namespace ContractMng.Domain.Entities;

public class ContractDocument : AuditableEntity
{
    public int Id { get; set; }
    public string Document { get; set; }
}
