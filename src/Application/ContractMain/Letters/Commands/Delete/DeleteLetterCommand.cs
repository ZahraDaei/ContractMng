using ContractMng.Application.Common.Interfaces;
using MediatR;
using ContractMng.Domain.Entities;
using ContractMng.Application.Common.Exceptions;


namespace ContractMng.Application.ContractMain.Letters.Commands.Delete;

public class DeleteLetterCommand : IRequest
{
         public int Id { get; set; }
}

public class DeleteLetterCommandHandler : IRequestHandler<DeleteLetterCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IMediator _mediator;

    public DeleteLetterCommandHandler(IApplicationDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    public async Task<Unit> Handle(DeleteLetterCommand request, CancellationToken cancellationToken)
    {
        try{
         var entity = await _context.Letters.FindAsync(request.Id);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Letter), request.Id);
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

