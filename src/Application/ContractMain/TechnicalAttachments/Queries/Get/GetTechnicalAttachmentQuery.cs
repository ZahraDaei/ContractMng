using ContractMng.Application.Common.Interfaces;
using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;


namespace ContractMng.Application.ContractMain.TechnicalAttachments.Queries.Get;

public class GetTechnicalAttachmentQuery : IRequest<TechnicalAttachmentVm>
{
 

}

public class GetTechnicalAttachmentQueryHandler : IRequestHandler<GetTechnicalAttachmentQuery, TechnicalAttachmentVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMediator _mediator;
     private readonly IMapper _mapper;

    public GetTechnicalAttachmentQueryHandler(IApplicationDbContext context, IMediator mediator, IMapper mapper)
    {
        _context = context;
        _mediator = mediator;
         _mapper = mapper;
    }

    public async Task<TechnicalAttachmentVm> Handle(GetTechnicalAttachmentQuery request, CancellationToken cancellationToken)
    {
              
       try
        {
            var contracts = await _context.Contracts.ToListAsync();
            var attachments = await _context.Letters.ToListAsync();
            var contractAttachments = from co in contracts
                                  join at in attachments on co.Id equals at.ContractId
                                  select new TechnicalAttachmentDto()
                                  {
                                      Id = at.Id,
                                      ContractNumber = co.Number,
                                      Number = at.Number,
                                     
                                  };



            return new TechnicalAttachmentVm(){TechnicalAttachmentDtos= contractAttachments };
        }
        catch (Exception e)
        {

            throw;
        }
    }
}

