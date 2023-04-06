using ContractMng.Application.Common.Interfaces;
using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ContractMng.Application.ContractMain.LastStatuses.Queries.Get;

namespace ContractMng.Application.Reports.ReportByPayments.Get;

public class ReportByPaymentQuery : IRequest<ReportByPaymentVm>
{


}

public class ReportByPaymentQueryHandler : IRequestHandler<ReportByPaymentQuery, ReportByPaymentVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public ReportByPaymentQueryHandler(IApplicationDbContext context, IMediator mediator, IMapper mapper)
    {
        _context = context;
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task<ReportByPaymentVm> Handle(ReportByPaymentQuery request, CancellationToken cancellationToken)
    {

        try
        {

            var lastStatuses = await _context.LastStatuses.ToListAsync();
            var contracts = await _context.Contracts.ToListAsync();

            var contractPayments = from la in lastStatuses
                                   group la by new
                                   {
                                       Id = la.Contract.Id,
                                       Number = la.Contract.Number,
                                       ContractId = la.Contract.Id,
                                       Amount = la.Contract.Amount,
                                       FinalAmount = la.Contract.FinalAmount,
                                       Subject = la.Contract.Subject,
                                       Type = la.Contract.Type,
                                   } into contractPayment

                                   select new ReportByPaymentDto()
                                   {
                                       Number = contractPayment.Key.Number,
                                       ContractId = contractPayment.Key.Id,
                                       Amount = contractPayment.Key.Amount,
                                       FinalAmount = contractPayment.Key.FinalAmount,
                                       Subject = contractPayment.Key.Subject,
                                       Type = contractPayment.Key.Type,
                                       Payments = (from cp in contractPayment
                                                   select new LastStatusDto()
                                                   {
                                                       Amount = cp.Amount,
                                                       AmountNumber = cp.AmountNumber,
                                                       Date = cp.Date,
                                                       Id = cp.Id
                                                   }
                                                 )
                                   };




            return new ReportByPaymentVm() { ReportByPaymentDtos = contractPayments };
        }
        catch (Exception e)
        {

            throw;
        }
    }
}

