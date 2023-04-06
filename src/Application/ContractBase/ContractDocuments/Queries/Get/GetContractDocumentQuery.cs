using ContractMng.Application.Common.Interfaces;
using MediatR;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;


namespace ContractMng.Application.ContractBase.ContractDocuments.Queries.Get;

public class GetContractDocumentQuery : IRequest<ContractDocumentVm>
{
  

}

public class GetContractDocumentQueryHandler : IRequestHandler<GetContractDocumentQuery, ContractDocumentVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMediator _mediator;
     private readonly IMapper _mapper;

    public GetContractDocumentQueryHandler(IApplicationDbContext context, IMediator mediator, IMapper mapper)
    {
        _context = context;
        _mediator = mediator;
         _mapper = mapper;
    }

    public async Task<ContractDocumentVm> Handle(GetContractDocumentQuery request, CancellationToken cancellationToken)
    {
              
       try
        {
        
         var dto = await _context.ContractDocuments
                        .ProjectTo<ContractDocumentDto>(_mapper.ConfigurationProvider).ToListAsync();
                 
          
            return new ContractDocumentVm(){ContractDocumentDtos=dto};
        }
        catch (Exception e)
        {

            throw;
        }
    }
}

