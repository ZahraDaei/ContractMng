using ContractMng.Application.Common.Interfaces;
using MediatR;
using ContractMng.Domain.Entities;
using ContractMng.Application.Common.Exceptions;


namespace ContractMng.Application.ContractMain.Contracts.Commands.Delete;

public class DeleteContractCommand : IRequest
{
         public int Id { get; set; }
}

public class DeleteContractCommandHandler : IRequestHandler<DeleteContractCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IMediator _mediator;

    public DeleteContractCommandHandler(IApplicationDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    public async Task<Unit> Handle(DeleteContractCommand request, CancellationToken cancellationToken)
    {
        try{
         var entity = await _context.Contracts.FindAsync(request.Id);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Contract), request.Id);
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

