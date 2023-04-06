using ContractMng.Application.Common.Interfaces;
using MediatR;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;


namespace ContractMng.Application.ContractBase.ContractLastStatuses.Queries.Get;

public class GetContractLastStatusQuery : IRequest<ContractLastStatusVm>
{
    public int Id { get; set; }

    public string Status { get; set; }

}

public class GetContractLastStatusQueryHandler : IRequestHandler<GetContractLastStatusQuery, ContractLastStatusVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMediator _mediator;
     private readonly IMapper _mapper;

    public GetContractLastStatusQueryHandler(IApplicationDbContext context, IMediator mediator, IMapper mapper)
    {
        _context = context;
        _mediator = mediator;
         _mapper = mapper;
    }

    public async Task<ContractLastStatusVm> Handle(GetContractLastStatusQuery request, CancellationToken cancellationToken)
    {
              
       try
        {
        
         var dto = await _context.ContractLastStatuses
                        .ProjectTo<ContractLastStatusDto>(_mapper.ConfigurationProvider).ToListAsync();
                 
          
            return new ContractLastStatusVm(){ContractLastStatusDtos=dto};
        }
        catch (Exception e)
        {

            throw;
        }
    }
}

