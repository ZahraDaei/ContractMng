namespace ContractMng.Domain.Entities;

public class ContractPaymentMethod : AuditableEntity
{
    public int Id { get; set; }
    public string Method { get; set; }
}
