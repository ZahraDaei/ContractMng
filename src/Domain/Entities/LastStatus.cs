namespace ContractMng.Domain.Entities;

public class LastStatus : AuditableEntity
{
    public int Id { get; set; }
    public string Date { get; set; }
    public string Progress { get; set; }
    public decimal Amount { get; set; }
    public int AmountNumber { get; set; }
    public int ContractId { get; set; }
    public bool Deleted { get; set; }
    public Contract Contract { get; set; }
    public int ContractLastStatusId { get; set; }
    public ContractLastStatus ContractLastStatus { get; set; }
}
