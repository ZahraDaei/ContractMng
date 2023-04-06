using ContractMng.Application.Common.Interfaces;
using MediatR;
using ContractMng.Domain.Entities;
using ContractMng.Application.Common.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace ContractMng.Application.ContractMain.Contracts.Commands.Update;

public class UpdateContractCommand : IRequest
{
    public int Id { get; set; }
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

public class UpdateContractCommandHandler : IRequestHandler<UpdateContractCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IMediator _mediator;

    public UpdateContractCommandHandler(IApplicationDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    public async Task<Unit> Handle(UpdateContractCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _context.Contracts.FindAsync(request.Id);
            var party = await _context.ContractParties.Where(c => c.PartyName == request.Party).FirstOrDefaultAsync();
            if (party == null)
            {
                throw new Exception("طرف قرارداد معتبر نمی باشد");
            }

            if (entity == null)
            {
                throw new NotFoundException(nameof(Contract), request.Id);
            }
            entity.ContractPartyId = party.Id;
            entity.Type = request.Type;
            entity.Amount = request.Amount;
            entity.BudgetPlace = request.BudgetPlace;
            entity.EndDate = request.EndDate;
            entity.FinalAmount = request.FinalAmount;
            entity.Number = request.Number;
            entity.StartDate = request.StartDate;
            entity.Subject = request.Subject;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
        catch (Exception)
        {
            throw;
        }
    }
}

