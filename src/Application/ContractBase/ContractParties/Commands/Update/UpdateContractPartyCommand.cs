using ContractMng.Application.Common.Interfaces;
using MediatR;
using ContractMng.Domain.Entities;
using ContractMng.Application.Common.Exceptions;


namespace ContractMng.Application.ContractBase.ContractParties.Commands.Update;

public class UpdateContractPartyCommand : IRequest
{
         public int Id { get; set; }

    public string PartyName { get; set; }
    public int ContractTypeId { get; set; }
}

public class UpdateContractPartyCommandHandler : IRequestHandler<UpdateContractPartyCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IMediator _mediator;

    public UpdateContractPartyCommandHandler(IApplicationDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    public async Task<Unit> Handle(UpdateContractPartyCommand request, CancellationToken cancellationToken)
    {
       try{
         var entity = await _context.ContractParties.FindAsync(request.Id);
        if (entity == null)
        {
            throw new NotFoundException(nameof(ContractParty), request.Id);
        }

            entity.PartyName = request.PartyName;
            entity.ContractTypeId = request.ContractTypeId;
            


        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
       }
       catch(Exception){
       throw;
       }
    }
}

