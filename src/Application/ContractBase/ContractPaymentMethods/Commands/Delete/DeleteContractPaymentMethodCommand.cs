using ContractMng.Application.Common.Interfaces;
using MediatR;
using ContractMng.Domain.Entities;
using ContractMng.Application.Common.Exceptions;


namespace ContractMng.Application.ContractBase.ContractPaymentMethods.Commands.Delete;

public class DeleteContractPaymentMethodCommand : IRequest
{
         public int Id { get; set; }
}

public class DeleteContractPaymentMethodCommandHandler : IRequestHandler<DeleteContractPaymentMethodCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IMediator _mediator;

    public DeleteContractPaymentMethodCommandHandler(IApplicationDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    public async Task<Unit> Handle(DeleteContractPaymentMethodCommand request, CancellationToken cancellationToken)
    {
        try{
         var entity = await _context.ContractPaymentMethods.FindAsync(request.Id);

        if (entity == null)
        {
            throw new NotFoundException(nameof(ContractPaymentMethod), request.Id);
        }

         
        _context.ContractPaymentMethods.Remove(entity);
        
         
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
        }
        catch(Exception){
        throw;
        }
    }
}

