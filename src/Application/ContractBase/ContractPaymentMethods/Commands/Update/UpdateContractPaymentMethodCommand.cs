using ContractMng.Application.Common.Interfaces;
using MediatR;
using ContractMng.Domain.Entities;
using ContractMng.Application.Common.Exceptions;


namespace ContractMng.Application.ContractBase.ContractPaymentMethods.Commands.Update;

public class UpdateContractPaymentMethodCommand : IRequest
{
         public int Id { get; set; }
    public string Method { get; set; }

}

public class UpdateContractPaymentMethodCommandHandler : IRequestHandler<UpdateContractPaymentMethodCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IMediator _mediator;

    public UpdateContractPaymentMethodCommandHandler(IApplicationDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    public async Task<Unit> Handle(UpdateContractPaymentMethodCommand request, CancellationToken cancellationToken)
    {
       try{
         var entity = await _context.ContractPaymentMethods.FindAsync(request.Id);

        if (entity == null)
        {
            throw new NotFoundException(nameof(ContractPaymentMethod), request.Id);
        }
        entity.Method = request.Method;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
       }
       catch(Exception){
       throw;
       }
    }
}

