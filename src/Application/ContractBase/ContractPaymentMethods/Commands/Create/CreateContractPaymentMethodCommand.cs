using ContractMng.Application.Common.Interfaces;
using MediatR;
using ContractMng.Domain.Entities;


namespace ContractMng.Application.ContractBase.ContractPaymentMethods.Commands.Create;

public class CreateContractPaymentMethodCommand : IRequest<int>
{

    public string Method { get; set; }

}

public class CreateContractPaymentMethodCommandHandler : IRequestHandler<CreateContractPaymentMethodCommand, int>
{
    private readonly IApplicationDbContext _context;
    private readonly IMediator _mediator;

    public CreateContractPaymentMethodCommandHandler(IApplicationDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    public async Task<int> Handle(CreateContractPaymentMethodCommand request, CancellationToken cancellationToken)
    {
        try
        {

            var entity = new ContractPaymentMethod()
            {
                Method = request.Method,
            };
            await _context.ContractPaymentMethods.AddAsync(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
        catch (Exception)
        {
            throw;
        }
    }
}

