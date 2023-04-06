using ContractMng.Application.Common.Interfaces;
using MediatR;
using ContractMng.Domain.Entities;
using ContractMng.Application.Common.Exceptions;


namespace ContractMng.Application.ContractBase.ContractDocuments.Commands.Delete;

public class DeleteContractDocumentCommand : IRequest
{
         public int Id { get; set; }
}

public class DeleteContractDocumentCommandHandler : IRequestHandler<DeleteContractDocumentCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IMediator _mediator;

    public DeleteContractDocumentCommandHandler(IApplicationDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    public async Task<Unit> Handle(DeleteContractDocumentCommand request, CancellationToken cancellationToken)
    {
        try{
         var entity = await _context.ContractDocuments.FindAsync(request.Id);

        if (entity == null)
        {
            throw new NotFoundException(nameof(ContractDocument), request.Id);
        }

         
        _context.ContractDocuments.Remove(entity);
        
         
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
        }
        catch(Exception){
        throw;
        }
    }
}

