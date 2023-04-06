using ContractMng.Application.Common.Interfaces;
using MediatR;
using ContractMng.Domain.Entities;
using ContractMng.Application.Common.Exceptions;


namespace ContractMng.Application.ContractBase.ContractBudgets.Commands.Update;

public class UpdateContractBudgetCommand : IRequest
{
         public int Id { get; set; }
    public string PlaceOfBudget { get; set; }
    public string SchemaNumber { get; set; }
}

public class UpdateContractBudgetCommandHandler : IRequestHandler<UpdateContractBudgetCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IMediator _mediator;

    public UpdateContractBudgetCommandHandler(IApplicationDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    public async Task<Unit> Handle(UpdateContractBudgetCommand request, CancellationToken cancellationToken)
    {
       try{
         var entity = await _context.ContractBudgets.FindAsync(request.Id);

        if (entity == null)
        {
            throw new NotFoundException(nameof(ContractBudget), request.Id);
        }

            entity.SchemaNumber = request.SchemaNumber;
            entity.PlaceOfBudget = request.PlaceOfBudget;
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
       }
       catch(Exception){
       throw;
       }
    }
}

