using ContractMng.Application.Common.Interfaces;
using MediatR;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;


namespace ContractMng.Application.ContractBase.ContractPaymentMethods.Queries.Get;

public class GetContractPaymentMethodQuery : IRequest<ContractPaymentMethodVm>
{
    public int Id { get; set; }

    public string Method { get; set; }

}

public class GetContractPaymentMethodQueryHandler : IRequestHandler<GetContractPaymentMethodQuery, ContractPaymentMethodVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMediator _mediator;
     private readonly IMapper _mapper;

    public GetContractPaymentMethodQueryHandler(IApplicationDbContext context, IMediator mediator, IMapper mapper)
    {
        _context = context;
        _mediator = mediator;
         _mapper = mapper;
    }

    public async Task<ContractPaymentMethodVm> Handle(GetContractPaymentMethodQuery request, CancellationToken cancellationToken)
    {
              
       try
        {
        
         var dto = await _context.ContractPaymentMethods
                        .ProjectTo<ContractPaymentMethodDto>(_mapper.ConfigurationProvider).ToListAsync();
                 
          
            return new ContractPaymentMethodVm(){ContractPaymentMethodDtos=dto};
        }
        catch (Exception e)
        {

            throw;
        }
    }
}

