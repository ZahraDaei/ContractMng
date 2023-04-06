using ContractMng.Application.Common.Interfaces;
using MediatR;
using ContractMng.Domain.Entities;
using ContractMng.Application.Common.Exceptions;


namespace ContractMng.Application.ContractMain.TechnicalAttachments.Commands.Delete;

public class DeleteTechnicalAttachmentCommand : IRequest
{
         public int Id { get; set; }
}

public class DeleteTechnicalAttachmentCommandHandler : IRequestHandler<DeleteTechnicalAttachmentCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IMediator _mediator;

    public DeleteTechnicalAttachmentCommandHandler(IApplicationDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    public async Task<Unit> Handle(DeleteTechnicalAttachmentCommand request, CancellationToken cancellationToken)
    {
        try{
         var entity = await _context.TechnicalAttachments.FindAsync(request.Id);

        if (entity == null)
        {
            throw new NotFoundException(nameof(TechnicalAttachment), request.Id);
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

