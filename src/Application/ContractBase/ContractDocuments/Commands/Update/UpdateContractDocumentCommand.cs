using ContractMng.Application.Common.Interfaces;
using MediatR;
using ContractMng.Domain.Entities;
using ContractMng.Application.Common.Exceptions;


namespace ContractMng.Application.ContractBase.ContractDocuments.Commands.Update;

public class UpdateContractDocumentCommand : IRequest
{
         public int Id { get; set; }
    public string Document { get; set; }
}

public class UpdateContractDocumentCommandHandler : IRequestHandler<UpdateContractDocumentCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IMediator _mediator;

    public UpdateContractDocumentCommandHandler(IApplicationDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    public async Task<Unit> Handle(UpdateContractDocumentCommand request, CancellationToken cancellationToken)
    {
       try{
         var entity = await _context.ContractDocuments.FindAsync(request.Id);

        if (entity == null)
        {
            throw new NotFoundException(nameof(ContractDocument), request.Id);
        }
        entity.Document = request.Document;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
       }
       catch(Exception){
       throw;
       }
    }
}

