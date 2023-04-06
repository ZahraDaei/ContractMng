using ContractMng.Application.Common.Interfaces;
using MediatR;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;


namespace ContractMng.Application.ContractBase.ContractTypes.Queries.Get;

public class GetContractTypeQuery : IRequest<ContractTypeVm>
{
    public int Id { get; set; }

    public string Type { get; set; }

}

public class GetContractTypeQueryHandler : IRequestHandler<GetContractTypeQuery, ContractTypeVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMediator _mediator;
     private readonly IMapper _mapper;

    public GetContractTypeQueryHandler(IApplicationDbContext context, IMediator mediator, IMapper mapper)
    {
        _context = context;
        _mediator = mediator;
         _mapper = mapper;
    }

    public async Task<ContractTypeVm> Handle(GetContractTypeQuery request, CancellationToken cancellationToken)
    {
              
       try
        {
        
         var dto = await _context.ContractTypes
                        .ProjectTo<ContractTypeDto>(_mapper.ConfigurationProvider).ToListAsync();
                 
          
            return new ContractTypeVm(){ContractTypeDtos=dto};
        }
        catch (Exception e)
        {

            throw;
        }
    }
}

