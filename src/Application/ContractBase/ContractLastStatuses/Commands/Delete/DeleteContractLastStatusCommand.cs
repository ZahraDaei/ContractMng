using ContractMng.Application.Common.Interfaces;
using MediatR;
using ContractMng.Domain.Entities;
using ContractMng.Application.Common.Exceptions;


namespace ContractMng.Application.ContractBase.ContractLastStatuses.Commands.Delete;

public class DeleteContractLastStatusCommand : IRequest
{
         public int Id { get; set; }
}

public class DeleteContractLastStatusCommandHandler : IRequestHandler<DeleteContractLastStatusCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IMediator _mediator;

    public DeleteContractLastStatusCommandHandler(IApplicationDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    public async Task<Unit> Handle(DeleteContractLastStatusCommand request, CancellationToken cancellationToken)
    {
        try{
         var entity = await _context.ContractLastStatuses.FindAsync(request.Id);

        if (entity == null)
        {
            throw new NotFoundException(nameof(ContractLastStatus), request.Id);
        }

         
        _context.ContractLastStatuses.Remove(entity);
        
         
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
        }
        catch(Exception){
        throw;
        }
    }
}

