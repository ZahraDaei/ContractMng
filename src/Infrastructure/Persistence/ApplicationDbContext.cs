using System.Reflection;
using ContractMng.Application.Common.Interfaces;
using ContractMng.Domain.Common;
using ContractMng.Domain.Entities;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ContractMng.Infrastructure.Persistence;

//public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>, IApplicationDbContext
public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    private readonly ICurrentUserService _currentUserService;
    private readonly IDateTime _dateTime;
    private readonly IDomainEventService _domainEventService;
    
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options,
        IOptions<OperationalStoreOptions> operationalStoreOptions,
        ICurrentUserService currentUserService,
        IDomainEventService domainEventService,
        IDateTime dateTime) : base(options)
        //IDateTime dateTime) : base(options, operationalStoreOptions)
    {
        _currentUserService = currentUserService;
        _domainEventService = domainEventService;
        _dateTime = dateTime;
    }

    //public DbSet<TodoList> TodoLists => Set<TodoList>();

    //public DbSet<TodoItem> TodoItems => Set<TodoItem>();
    public DbSet<Contract> Contracts { get; set; }
    public DbSet<Letter> Letters { get; set; }
    public DbSet<TechnicalAttachment> TechnicalAttachments { get; set; }
    public DbSet<LastStatus> LastStatuses { get; set; }
    public DbSet<ContractBudget> ContractBudgets { get; set; }
    public DbSet<ContractDocument> ContractDocuments { get; set; }
    public DbSet<ContractLastStatus> ContractLastStatuses { get; set; }
    public DbSet<ContractLetter> ContractLetters { get; set; }
    public DbSet<ContractParty> ContractParties { get; set; }
    public DbSet<ContractPaymentMethod> ContractPaymentMethods { get; set; }
    public DbSet<ContractType> ContractTypes { get; set; }

    public override DbSet<TEntity> Set<TEntity>()
    {
        return base.Set<TEntity>();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedBy = _currentUserService.UserId;
                    entry.Entity.Created = _dateTime.Now;
                    break;

                case EntityState.Modified:
                    entry.Entity.LastModifiedBy = _currentUserService.UserId;
                    entry.Entity.LastModified = _dateTime.Now;
                    break;
            }
        }

        var events = ChangeTracker.Entries<IHasDomainEvent>()
                .Select(x => x.Entity.DomainEvents)
                .SelectMany(x => x)
                .Where(domainEvent => !domainEvent.IsPublished)
                .ToArray();

        var result = await base.SaveChangesAsync(cancellationToken);

        await DispatchEvents(events);

        return result;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }

    private async Task DispatchEvents(DomainEvent[] events)
    {
        foreach (var @event in events)
        {
            @event.IsPublished = true;
            await _domainEventService.Publish(@event);
        }
    }
}
