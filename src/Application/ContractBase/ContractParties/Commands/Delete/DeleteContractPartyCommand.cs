using ContractMng.Application.Common.Interfaces;
using MediatR;
using ContractMng.Domain.Entities;
using ContractMng.Application.Common.Exceptions;


namespace ContractMng.Application.ContractBase.ContractParties.Commands.Delete;

public class DeleteContractPartyCommand : IRequest
{
         public int Id { get; set; }
}

public class DeleteContractPartyCommandHandler : IRequestHandler<DeleteContractPartyCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IMediator _mediator;

    public DeleteContractPartyCommandHandler(IApplicationDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    public async Task<Unit> Handle(DeleteContractPartyCommand request, CancellationToken cancellationToken)
    {
        try{
         var entity = await _context.ContractParties.FindAsync(request.Id);

        if (entity == null)
        {
            throw new NotFoundException(nameof(ContractParty), request.Id);
        }

         
        _context.ContractParties.Remove(entity);
        
         
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
        }
        catch(Exception){
        throw;
        }
    }
}

