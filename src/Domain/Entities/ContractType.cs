namespace ContractMng.Domain.Entities;

public class ContractType : AuditableEntity
{
    public int Id { get; set; }
    public string Type { get; set; }
}
