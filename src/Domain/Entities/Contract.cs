namespace ContractMng.Domain.Entities;

public class Contract : AuditableEntity
{
    public int Id { get; set; }
    public string Number { get; set; }
    public string Subject { get; set; }
    public string Type { get; set; }
    public decimal Amount { get; set; }
    public int ContractPartyId { get; set; }
    public string StartDate { get; set; }
    public string EndDate { get; set; }
    public decimal FinalAmount { get; set; }
    public string BudgetPlace { get; set; }
    public bool Deleted { get; set; }
    public ContractParty ContractParty { get; set; }
    public ICollection<Letter> Letters { get; set; }
    public ICollection<TechnicalAttachment> TechnicalAttachments { get; set; }
    public ICollection<LastStatus> LastStatuses { get; set; }

}
