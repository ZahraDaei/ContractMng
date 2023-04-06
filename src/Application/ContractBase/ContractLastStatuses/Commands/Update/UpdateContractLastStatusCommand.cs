using ContractMng.Application.Common.Interfaces;
using MediatR;
using ContractMng.Domain.Entities;
using ContractMng.Application.Common.Exceptions;


namespace ContractMng.Application.ContractBase.ContractLastStatuses.Commands.Update;

public class UpdateContractLastStatusCommand : IRequest
{
         public int Id { get; set; }
    public string Status { get; set; }

}

public class UpdateContractLastStatusCommandHandler : IRequestHandler<UpdateContractLastStatusCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IMediator _mediator;

    public UpdateContractLastStatusCommandHandler(IApplicationDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    public async Task<Unit> Handle(UpdateContractLastStatusCommand request, CancellationToken cancellationToken)
    {
       try{
         var entity = await _context.ContractLastStatuses.FindAsync(request.Id);

        if (entity == null)
        {
            throw new NotFoundException(nameof(ContractLastStatus), request.Id);
        }
        entity.Status = request.Status;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
       }
       catch(Exception){
       throw;
       }
    }
}

