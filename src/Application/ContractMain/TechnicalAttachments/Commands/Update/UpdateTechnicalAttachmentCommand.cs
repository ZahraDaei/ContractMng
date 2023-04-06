using ContractMng.Application.Common.Interfaces;
using MediatR;
using ContractMng.Domain.Entities;
using ContractMng.Application.Common.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace ContractMng.Application.ContractMain.TechnicalAttachments.Commands.Update;

public class UpdateTechnicalAttachmentCommand : IRequest
{
         public int Id { get; set; }
    public string Name { get; set; }
    public string Number { get; set; }
    public string ContractNumber { get; set; }
}

public class UpdateTechnicalAttachmentCommandHandler : IRequestHandler<UpdateTechnicalAttachmentCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IMediator _mediator;

    public UpdateTechnicalAttachmentCommandHandler(IApplicationDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    public async Task<Unit> Handle(UpdateTechnicalAttachmentCommand request, CancellationToken cancellationToken)
    {
       try{
         var entity = await _context.TechnicalAttachments.FindAsync(request.Id);
            var contract = await _context.Contracts.Where(c => c.Number == request.Number).FirstOrDefaultAsync();

        if (entity == null)
        {
            throw new NotFoundException(nameof(TechnicalAttachment), request.Id);
            }

            entity.ContractId = contract.Id;
            entity.Name = request.Name;
            entity.Number = request.Number;
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
       }
       catch(Exception){
       throw;
       }
    }
}

