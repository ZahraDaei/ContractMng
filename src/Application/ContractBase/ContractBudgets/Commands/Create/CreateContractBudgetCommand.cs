using ContractMng.Application.Common.Interfaces;
using MediatR;
using ContractMng.Domain.Entities;


namespace ContractMng.Application.ContractBase.ContractBudgets.Commands.Create;

public class CreateContractBudgetCommand : IRequest<int>
{
    public string PlaceOfBudget { get; set; }
    public string SchemaNumber { get; set; }

}

public class CreateContractBudgetCommandHandler : IRequestHandler<CreateContractBudgetCommand, int>
{
    private readonly IApplicationDbContext _context;
    private readonly IMediator _mediator;
    private readonly IContractBudgetRepo _contractBudgetRepo;

    public CreateContractBudgetCommandHandler(IApplicationDbContext context, IMediator mediator,IContractBudgetRepo contractBudgetRepo)
    {
        _context = context;
        _mediator = mediator;
        _contractBudgetRepo = contractBudgetRepo;
    }

    public async Task<int> Handle(CreateContractBudgetCommand request, CancellationToken cancellationToken)
    {
        try
        {

            var entity = new ContractBudget()
            {
                PlaceOfBudget = request.PlaceOfBudget,
                SchemaNumber=request.SchemaNumber
            };
            await _contractBudgetRepo.Create(entity);
         await _context.ContractBudgets.AddAsync(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
     }
     catch(Exception){
     throw;
     }
    }
}

