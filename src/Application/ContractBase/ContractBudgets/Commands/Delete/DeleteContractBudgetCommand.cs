using ContractMng.Application.Common.Interfaces;
using MediatR;
using ContractMng.Domain.Entities;
using ContractMng.Application.Common.Exceptions;


namespace ContractMng.Application.ContractBase.ContractBudgets.Commands.Delete;

public class DeleteContractBudgetCommand : IRequest
{
         public int Id { get; set; }
}

public class DeleteContractBudgetCommandHandler : IRequestHandler<DeleteContractBudgetCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IMediator _mediator;

    public DeleteContractBudgetCommandHandler(IApplicationDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    public async Task<Unit> Handle(DeleteContractBudgetCommand request, CancellationToken cancellationToken)
    {
        try{
         var entity = await _context.ContractBudgets.FindAsync(request.Id);

        if (entity == null)
        {
            throw new NotFoundException(nameof(ContractBudget), request.Id);
        }

         
        _context.ContractBudgets.Remove(entity);
        
         
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
        }
        catch(Exception){
        throw;
        }
    }
}

