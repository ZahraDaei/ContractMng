using ContractMng.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContractMng.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    //DbSet<TodoList> TodoLists { get; }

    //DbSet<TodoItem> TodoItems { get; }
	  DbSet<Contract> Contracts { get; set; }
     DbSet<Letter> Letters { get; set; }
     DbSet<TechnicalAttachment> TechnicalAttachments { get; set; }
     DbSet<LastStatus> LastStatuses { get; set; }
     DbSet<ContractBudget> ContractBudgets { get; set; }
     DbSet<ContractDocument> ContractDocuments { get; set; }
     DbSet<ContractLastStatus> ContractLastStatuses { get; set; }
     DbSet<ContractLetter> ContractLetters { get; set; }
     DbSet<ContractParty> ContractParties { get; set; }
     DbSet<ContractPaymentMethod> ContractPaymentMethods { get; set; }
     DbSet<ContractType> ContractTypes { get; set; }
    DbSet<TEntity> Set<TEntity>() where TEntity : class;



    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
