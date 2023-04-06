using ContractMng.Application.Common.Interfaces;
using MediatR;
using ContractMng.Domain.Entities;
using ContractMng.Application.Common.Exceptions;


namespace ContractMng.Application.ContractBase.ContractTypes.Commands.Update;

public class UpdateContractTypeCommand : IRequest
{
         public int Id { get; set; }
    public string Type { get; set; }

}

public class UpdateContractTypeCommandHandler : IRequestHandler<UpdateContractTypeCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IMediator _mediator;

    public UpdateContractTypeCommandHandler(IApplicationDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    public async Task<Unit> Handle(UpdateContractTypeCommand request, CancellationToken cancellationToken)
    {
       try{
         var entity = await _context.ContractTypes.FindAsync(request.Id);

        if (entity == null)
        {
            throw new NotFoundException(nameof(ContractType), request.Id);
        }
        entity.Type = request.Type;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
       }
       catch(Exception){
       throw;
       }
    }
}

