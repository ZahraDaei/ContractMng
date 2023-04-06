using ContractMng.Application.Common.Interfaces;
using MediatR;
using ContractMng.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContractMng.Application.ContractMain.LastStatuses.Commands.Create;

public class CreateLastStatusCommand : IRequest<int>
{
    public string Date { get; set; }
    public int ContractLastStatusId { get; set; }
    public decimal Amount { get; set; }
    public int AmountNumber { get; set; }
    public string ContractNumber { get; set; }

}

public class CreateLastStatusCommandHandler : IRequestHandler<CreateLastStatusCommand, int>
{
    private readonly IApplicationDbContext _context;
    private readonly IMediator _mediator;

    public CreateLastStatusCommandHandler(IApplicationDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    public async Task<int> Handle(CreateLastStatusCommand request, CancellationToken cancellationToken)
    {

        var status = await _context.ContractLastStatuses
            .Where(c => c.Id == request.ContractLastStatusId).FirstOrDefaultAsync();
        var contract = await _context.Contracts.Where(c => c.Number == request.ContractNumber).FirstOrDefaultAsync();
       
     try
        {

            var entity = new LastStatus()
            {
                Amount = request.Amount,
                AmountNumber = request.AmountNumber,
                ContractId = contract.Id,
                Date = request.Date,
                Progress = status.Status,
                ContractLastStatusId=request.ContractLastStatusId
            };
            await _context.LastStatuses.AddAsync(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
        catch (Exception)
        {
            throw;
        }
    }
}

