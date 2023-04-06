using ContractMng.Application.Common.Interfaces;
using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;


namespace ContractMng.Application.ContractMain.Letters.Queries.Get;

public class GetLetterQuery : IRequest<LetterVm>
{
 

}

public class GetLetterQueryHandler : IRequestHandler<GetLetterQuery, LetterVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMediator _mediator;
     private readonly IMapper _mapper;

    public GetLetterQueryHandler(IApplicationDbContext context, IMediator mediator, IMapper mapper)
    {
        _context = context;
        _mediator = mediator;
         _mapper = mapper;
    }

    public async Task<LetterVm> Handle(GetLetterQuery request, CancellationToken cancellationToken)
    {
              
       try
        {
            var contracts = await _context.Contracts.ToListAsync();
            var letters = await _context.Letters.ToListAsync();
            var contractLetters = from co in contracts
                                       join le in letters on co.Id equals le.ContractId
                                       select new LetterDto()
                                       {
                                           Id = le.Id,
                                           ContractNumber = co.Number,
                                          Number=le.Number,
                                          LetterDate=le.LetterDate,
                                          Subject=le.Subject,
                                          Type=le.Type
                                       };



            return new LetterVm(){LetterDtos= contractLetters };
        }
        catch (Exception e)
        {

            throw;
        }
    }
}

