using ContractMng.Application.Common.Interfaces;
using MediatR;
using ContractMng.Domain.Entities;


namespace ContractMng.Application.ContractBase.ContractTypes.Commands.Create;

public class CreateContractTypeCommand : IRequest<int>
{
    public string Type { get; set; }


}

public class CreateContractTypeCommandHandler : IRequestHandler<CreateContractTypeCommand, int>
{
    private readonly IApplicationDbContext _context;
    private readonly IMediator _mediator;

    public CreateContractTypeCommandHandler(IApplicationDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    public async Task<int> Handle(CreateContractTypeCommand request, CancellationToken cancellationToken)
    {
     try{
     
        var entity= new ContractType()
        {
            Type = request.Type,
        };
         await _context.ContractTypes.AddAsync(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
     }
     catch(Exception){
     throw;
     }
    }
}

