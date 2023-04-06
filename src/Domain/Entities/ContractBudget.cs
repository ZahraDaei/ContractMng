namespace ContractMng.Domain.Entities;

public class ContractBudget : AuditableEntity
{
    public int Id { get; set; }
    public string PlaceOfBudget { get; set; }
    public string SchemaNumber { get; set; }
}
