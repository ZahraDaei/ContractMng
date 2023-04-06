using ContractMng.Application.Common.Interfaces;
using MediatR;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;


namespace ContractMng.Application.ContractBase.ContractLetters.Queries.Get;

public class GetContractLetterQuery : IRequest<ContractLetterVm>
{
    public int Id { get; set; }

    public string LetterType { get; set; }

}

public class GetContractLetterQueryHandler : IRequestHandler<GetContractLetterQuery, ContractLetterVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMediator _mediator;
     private readonly IMapper _mapper;

    public GetContractLetterQueryHandler(IApplicationDbContext context, IMediator mediator, IMapper mapper)
    {
        _context = context;
        _mediator = mediator;
         _mapper = mapper;
    }

    public async Task<ContractLetterVm> Handle(GetContractLetterQuery request, CancellationToken cancellationToken)
    {
              
       try
        {
        
         var dto = await _context.ContractLetters
                        .ProjectTo<ContractLetterDto>(_mapper.ConfigurationProvider).ToListAsync();
                 
          
            return new ContractLetterVm(){ContractLetterDtos=dto};
        }
        catch (Exception e)
        {

            throw;
        }
    }
}

