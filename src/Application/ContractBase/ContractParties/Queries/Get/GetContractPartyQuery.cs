using ContractMng.Application.Common.Interfaces;
using MediatR;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;


namespace ContractMng.Application.ContractBase.ContractParties.Queries.Get;

public class GetContractPartyQuery : IRequest<ContractPartyVm>
{
    public int Id { get; set; }

    public string PartyName { get; set; }
    public int ContractTypeId { get; set; }

}

public class GetContractPartyQueryHandler : IRequestHandler<GetContractPartyQuery, ContractPartyVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMediator _mediator;
     private readonly IMapper _mapper;

    public GetContractPartyQueryHandler(IApplicationDbContext context, IMediator mediator, IMapper mapper)
    {
        _context = context;
        _mediator = mediator;
         _mapper = mapper;
    }

    public async Task<ContractPartyVm> Handle(GetContractPartyQuery request, CancellationToken cancellationToken)
    {
              
       try
        {
        
         var dto = await _context.ContractParties
                        .ProjectTo<ContractPartyDto>(_mapper.ConfigurationProvider).ToListAsync();
                 
          
            return new ContractPartyVm(){ContractPartyDtos=dto};
        }
        catch (Exception e)
        {

            throw;
        }
    }
}

