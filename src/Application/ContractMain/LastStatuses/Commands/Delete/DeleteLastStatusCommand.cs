using ContractMng.Application.Common.Interfaces;
using MediatR;
using ContractMng.Domain.Entities;
using ContractMng.Application.Common.Exceptions;


namespace ContractMng.Application.ContractMain.LastStatuses.Commands.Delete;

public class DeleteLastStatusCommand : IRequest
{
         public int Id { get; set; }
}

public class DeleteLastStatusCommandHandler : IRequestHandler<DeleteLastStatusCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IMediator _mediator;

    public DeleteLastStatusCommandHandler(IApplicationDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    public async Task<Unit> Handle(DeleteLastStatusCommand request, CancellationToken cancellationToken)
    {
        try{
         var entity = await _context.LastStatuses.FindAsync(request.Id);

        if (entity == null)
        {
            throw new NotFoundException(nameof(LastStatus), request.Id);
        }

                       entity.Deleted=true;
           
        
         
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
        }
        catch(Exception){
        throw;
        }
    }
}

