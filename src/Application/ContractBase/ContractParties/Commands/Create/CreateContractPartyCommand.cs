using ContractMng.Application.Common.Interfaces;
using MediatR;
using ContractMng.Domain.Entities;


namespace ContractMng.Application.ContractBase.ContractParties.Commands.Create;

public class CreateContractPartyCommand : IRequest<int>
{
    public string PartyName { get; set; }
    public int ContractTypeId { get; set; }
}

public class CreateContractPartyCommandHandler : IRequestHandler<CreateContractPartyCommand, int>
{
    private readonly IApplicationDbContext _context;
    private readonly IMediator _mediator;

    public CreateContractPartyCommandHandler(IApplicationDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    public async Task<int> Handle(CreateContractPartyCommand request, CancellationToken cancellationToken)
    {
        try
        {

            var entity = new ContractParty()
            {
                PartyName = request.PartyName,
                ContractTypeId = request.ContractTypeId
            };
            await _context.ContractParties.AddAsync(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
        catch (Exception)
        {
            throw;
        }
    }
}

