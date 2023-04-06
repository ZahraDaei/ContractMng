using AutoMapper;
using ContractMng.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace ContractMng.Application.ContractMain.LastStatuses.Queries.Get;

public class GetLastStatusQuery : IRequest<LastStatusVm>
{


}

public class GetLastStatusQueryHandler : IRequestHandler<GetLastStatusQuery, LastStatusVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public GetLastStatusQueryHandler(IApplicationDbContext context, IMediator mediator, IMapper mapper)
    {
        _context = context;
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task<LastStatusVm> Handle(GetLastStatusQuery request, CancellationToken cancellationToken)
    {

        try
        {
            var contracts = await _context.Contracts.ToListAsync();
            var lastStatuses = await _context.LastStatuses.ToListAsync();
            var contractLastStatuses = from co in contracts
                                       join la in lastStatuses on co.Id equals la.ContractId
                                       select new LastStatusDto()
                                       {
                                           Amount = la.Amount,
                                           Id = la.Id,
                                           AmountNumber = la.AmountNumber,
                                           ContractNumber = co.Number,
                                           Date = la.Date,
                                           Progress = la.Progress,
                                       };



            return new LastStatusVm() { LastStatusDtos = contractLastStatuses };
        }
        catch (Exception e)
        {

            throw;
        }
    }
}

