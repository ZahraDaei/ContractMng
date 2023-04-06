using ContractMng.Application.Common.Interfaces;
using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ContractMng.Application.ContractMain.Contracts.Queries.Get;

namespace ContractMng.Application.Reports.ReportByStatuses.Get;

public class ReportByStatusQuery : IRequest<ReportByStatusVm>
{


}

public class ReportByStatusQueryHandler : IRequestHandler<ReportByStatusQuery, ReportByStatusVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public ReportByStatusQueryHandler(IApplicationDbContext context, IMediator mediator, IMapper mapper)
    {
        _context = context;
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task<ReportByStatusVm> Handle(ReportByStatusQuery request, CancellationToken cancellationToken)
    {

        try
        {

            var lastStatuses = await _context.LastStatuses.ToListAsync();
            var contracts = await _context.Contracts.ToListAsync();
            var contractLastStatuses = await _context.ContractLastStatuses.ToListAsync();



            var reportByStatusDtos = from co in contracts                                
                               where co.Deleted == false
                               group co by new
                               {
                                   Id= (from la in co.LastStatuses
                                        orderby la.Created descending
                                        select la).Take(1).FirstOrDefault()?.ContractLastStatus.Id,
                                   Status = (from la in co.LastStatuses
                                             orderby la.Created descending
                                             select la).Take(1).FirstOrDefault()?.ContractLastStatus.Status
                               } into lastStatus
                               select new ReportByStatusDto()
                               {
                                   ContractLastStatusId=lastStatus.Key.Id,
                                   Status = lastStatus.Key.Status,
                                   Contracts = (from c in lastStatus
                                                select new ContractDto()
                                                {
                                                    Amount = c.Amount,
                                                    Number = c.Number,
                                                    Subject = c.Subject,
                                                    FinalAmount = c.FinalAmount,
                                                    Type=c.Type,
                                                    BudgetPlace=c.BudgetPlace,
                                                    EndDate=c.EndDate,
                                                    StartDate=c.StartDate,
                                                    Id=c.Id,
                                                    Party=c.ContractParty?.PartyName
                                                })

                               };


           



            return new ReportByStatusVm() { ReportByStatusDtos = reportByStatusDtos };
        }
        catch (Exception e)
        {

            throw;
        }
    }
}

