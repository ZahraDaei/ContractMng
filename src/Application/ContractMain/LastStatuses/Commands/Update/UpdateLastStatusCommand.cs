using ContractMng.Application.Common.Interfaces;
using MediatR;
using ContractMng.Domain.Entities;
using ContractMng.Application.Common.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace ContractMng.Application.ContractMain.LastStatuses.Commands.Update;

public class UpdateLastStatusCommand : IRequest
{
    public int Id { get; set; }
    public string Date { get; set; }
    public int ContractLastStatusId { get; set; }
    public decimal Amount { get; set; }
    public int AmountNumber { get; set; }
    public string ContractNumber { get; set; }
}

public class UpdateLastStatusCommandHandler : IRequestHandler<UpdateLastStatusCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IMediator _mediator;

    public UpdateLastStatusCommandHandler(IApplicationDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    public async Task<Unit> Handle(UpdateLastStatusCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _context.LastStatuses.FindAsync(request.Id);
            var contract = await _context.Contracts.Where(c => c.Number == request.ContractNumber).FirstOrDefaultAsync();
            var status = await _context.ContractLastStatuses
            .Where(c => c.Id == request.ContractLastStatusId).FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new NotFoundException(nameof(LastStatus), request.Id);
            }
            entity.Amount = request.Amount;
            entity.AmountNumber = request.AmountNumber;
            entity.ContractId = contract.Id;
            entity.Date = request.Date;
            entity.Progress = status.Status;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
        catch (Exception)
        {
            throw;
        }
    }
}

