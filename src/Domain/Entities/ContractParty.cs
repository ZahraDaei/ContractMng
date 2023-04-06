namespace ContractMng.Domain.Entities;

public class ContractParty : AuditableEntity
{
    public int Id { get; set; }
    public string PartyName { get; set; }
    public int ContractTypeId { get; set; }
    public ICollection<Contract> Contracts { get; set; }
}
