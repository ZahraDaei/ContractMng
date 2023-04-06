using ContractMng.Application.Common.Interfaces;
using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ContractMng.Application.ContractMain.Contracts.Queries.Get;

namespace ContractMng.Application.Reports.ReportByParties.Get;

public class ReportByPartyQuery : IRequest<ReportByPartyVm>
{


}

public class ReportByPartyQueryHandler : IRequestHandler<ReportByPartyQuery, ReportByPartyVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public ReportByPartyQueryHandler(IApplicationDbContext context, IMediator mediator, IMapper mapper)
    {
        _context = context;
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task<ReportByPartyVm> Handle(ReportByPartyQuery request, CancellationToken cancellationToken)
    {

        try
        {
            var parties = await _context.ContractParties.ToListAsync();
            var contracts = await _context.Contracts.ToListAsync();
            var contractTypes = await _context.ContractTypes.ToListAsync();

            var contractPartyType = from co in contracts
                                    join ta in contractTypes on co.ContractParty.ContractTypeId equals ta.Id
                                    group co by new
                                    {
                                        PartyName = co.ContractParty.PartyName,
                                        PartyId = co.ContractPartyId,
                                        ContractType = ta.Type,
                                    } into contractParty
                                    select new ReportByPartyDto()
                                    {
                                        ContractParty = contractParty.Key.PartyName,
                                        PartyId = contractParty.Key.PartyId,
                                        ContractType = contractParty.Key.ContractType,
                                        Contracts = (from contract in contractParty
                                                     select new ContractDto()
                                                     {
                                                         Number = contract.Number,
                                                         Amount = contract.Amount,
                                                         BudgetPlace = contract.BudgetPlace,
                                                         EndDate = contract.EndDate,
                                                         FinalAmount = contract.FinalAmount,
                                                         Id = contract.Id,
                                                         StartDate = contract.StartDate,
                                                         Subject = contract.Subject,
                                                     })
                                    };

            return new ReportByPartyVm() { ReportByPartyDtos = contractPartyType };
        }
        catch (Exception e)
        {
            throw;
        }
    }
}

