using ContractMng.Application.Common.Interfaces;
using MediatR;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;


namespace ContractMng.Application.ContractBase.ContractBudgets.Queries.Get;

public class GetContractBudgetQuery : IRequest<ContractBudgetVm>
{
   

}

public class GetContractBudgetQueryHandler : IRequestHandler<GetContractBudgetQuery, ContractBudgetVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMediator _mediator;
     private readonly IMapper _mapper;

    public GetContractBudgetQueryHandler(IApplicationDbContext context, IMediator mediator, IMapper mapper)
    {
        _context = context;
        _mediator = mediator;
         _mapper = mapper;
    }

    public async Task<ContractBudgetVm> Handle(GetContractBudgetQuery request, CancellationToken cancellationToken)
    {
              
       try
        {
        
         var dto = await _context.ContractBudgets
                        .ProjectTo<ContractBudgetDto>(_mapper.ConfigurationProvider).ToListAsync();
                 
          
            return new ContractBudgetVm(){ContractBudgetDtos=dto};
        }
        catch (Exception e)
        {

            throw;
        }
    }
}

