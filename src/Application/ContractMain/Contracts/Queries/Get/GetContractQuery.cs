using ContractMng.Application.Common.Interfaces;
using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ContractMng.Application.ContractMain.Contracts.Queries.Get;

public class GetContractQuery : IRequest<ContractVm>
{


}

public class GetContractQueryHandler : IRequestHandler<GetContractQuery, ContractVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public GetContractQueryHandler(IApplicationDbContext context, IMediator mediator, IMapper mapper)
    {
        _context = context;
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task<ContractVm> Handle(GetContractQuery request, CancellationToken cancellationToken)
    {
        ClaimTypes.Email
        try
        {
            var parties=await _context.ContractParties.ToListAsync();
            var contracts=await _context.Contracts.ToListAsync();

            var contractParties = from co in contracts
                                  join pa in parties on co.ContractPartyId equals pa.Id
                                  where co.Deleted == false
                                  select new ContractDto()
                                  {
                                      Id = co.Id,
                                      Amount = co.Amount,
                                      BudgetPlace = co.BudgetPlace,
                                      EndDate = co.EndDate,
                                      FinalAmount = co.FinalAmount,
                                      Number = co.Number,
                                      Party = pa.PartyName,
                                      StartDate = co.StartDate,
                                      Subject = co.Subject,
                                      Type = co.Type
                                  };
            



            return new ContractVm() { ContractDtos = contractParties };
        }
        catch (Exception e)
        {

            throw;
        }
    }
}

