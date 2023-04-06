namespace ContractMng.Domain.Entities;

public class ContractLastStatus : AuditableEntity
{
    public int Id { get; set; }
    public string Status { get; set; }

}
