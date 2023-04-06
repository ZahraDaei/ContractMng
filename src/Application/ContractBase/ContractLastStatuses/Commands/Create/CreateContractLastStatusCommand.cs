using ContractMng.Application.Common.Interfaces;
using MediatR;
using ContractMng.Domain.Entities;


namespace ContractMng.Application.ContractBase.ContractLastStatuses.Commands.Create;

public class CreateContractLastStatusCommand : IRequest<int>
{
    public string Status { get; set; }


}

public class CreateContractLastStatusCommandHandler : IRequestHandler<CreateContractLastStatusCommand, int>
{
    private readonly IApplicationDbContext _context;
    private readonly IMediator _mediator;

    public CreateContractLastStatusCommandHandler(IApplicationDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    public async Task<int> Handle(CreateContractLastStatusCommand request, CancellationToken cancellationToken)
    {
     try{
     
        var entity= new ContractLastStatus()
        {
            Status = request.Status,
        };
         await _context.ContractLastStatuses.AddAsync(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
     }
     catch(Exception){
     throw;
     }
    }
}

