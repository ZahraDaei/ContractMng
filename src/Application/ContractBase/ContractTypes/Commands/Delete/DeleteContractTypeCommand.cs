using ContractMng.Application.Common.Interfaces;
using MediatR;
using ContractMng.Domain.Entities;
using ContractMng.Application.Common.Exceptions;


namespace ContractMng.Application.ContractBase.ContractTypes.Commands.Delete;

public class DeleteContractTypeCommand : IRequest
{
         public int Id { get; set; }
}

public class DeleteContractTypeCommandHandler : IRequestHandler<DeleteContractTypeCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IMediator _mediator;

    public DeleteContractTypeCommandHandler(IApplicationDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    public async Task<Unit> Handle(DeleteContractTypeCommand request, CancellationToken cancellationToken)
    {
        try{
         var entity = await _context.ContractTypes.FindAsync(request.Id);

        if (entity == null)
        {
            throw new NotFoundException(nameof(ContractType), request.Id);
        }

         
        _context.ContractTypes.Remove(entity);
        
         
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
        }
        catch(Exception){
        throw;
        }
    }
}

