using ContractMng.Application.Common.Interfaces;
using MediatR;
using ContractMng.Domain.Entities;


namespace ContractMng.Application.ContractBase.ContractDocuments.Commands.Create;

public class CreateContractDocumentCommand : IRequest<int>
{

    public string Document { get; set; }
}

public class CreateContractDocumentCommandHandler : IRequestHandler<CreateContractDocumentCommand, int>
{
    private readonly IApplicationDbContext _context;
    private readonly IMediator _mediator;

    public CreateContractDocumentCommandHandler(IApplicationDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    public async Task<int> Handle(CreateContractDocumentCommand request, CancellationToken cancellationToken)
    {
     try{
     
        var entity= new ContractDocument()
        {
            Document = request.Document,
        };
         await _context.ContractDocuments.AddAsync(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
     }
     catch(Exception){
     throw;
     }
    }
}

