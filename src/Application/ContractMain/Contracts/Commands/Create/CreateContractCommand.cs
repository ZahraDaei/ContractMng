using ContractMng.Application.Common.Interfaces;
using MediatR;
using ContractMng.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContractMng.Application.ContractMain.Contracts.Commands.Create;

public class CreateContractCommand : IRequest<int>
{

    public string Number { get; set; }
    public string Subject { get; set; }
    public string Type { get; set; }
    public decimal Amount { get; set; }
    public string Party { get; set; }
    public string StartDate { get; set; }
    public string EndDate { get; set; }

    public decimal FinalAmount { get; set; }
    public string BudgetPlace { get; set; }
}

public class CreateContractCommandHandler : IRequestHandler<CreateContractCommand, int>
{
    private readonly IApplicationDbContext _context;
    private readonly IMediator _mediator;

    public CreateContractCommandHandler(IApplicationDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    public async Task<int> Handle(CreateContractCommand request, CancellationToken cancellationToken)
    {
        var party = await _context.ContractParties.Where(c => c.PartyName == request.Party).FirstOrDefaultAsync(cancellationToken: cancellationToken);
        if (party == null)
        {
            throw new Exception("طرف قرارداد معتبر نمی باشد");
        }
        try
        {

            var entity = new Contract()
            {
                ContractPartyId = party.Id,
                Type = request.Type,
                Amount = request.Amount,
                BudgetPlace = request.BudgetPlace,
                EndDate = request.EndDate,
                FinalAmount = request.FinalAmount,
                Number = request.Number,
                StartDate = request.StartDate,
                Subject = request.Subject
            };
            await _context.Contracts.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
        catch (Exception)
        {
            throw;
        }
    }
}

