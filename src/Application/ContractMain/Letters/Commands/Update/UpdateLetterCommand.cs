using ContractMng.Application.Common.Interfaces;
using MediatR;
using ContractMng.Domain.Entities;
using ContractMng.Application.Common.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace ContractMng.Application.ContractMain.Letters.Commands.Update;

public class UpdateLetterCommand : IRequest
{
    public int Id { get; set; }
    public string Type { get; set; }
    public string Subject { get; set; }
    public string Number { get; set; }
    public string LetterDate { get; set; }
    public string ContractNumber { get; set; }
}

public class UpdateLetterCommandHandler : IRequestHandler<UpdateLetterCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IMediator _mediator;

    public UpdateLetterCommandHandler(IApplicationDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    public async Task<Unit> Handle(UpdateLetterCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _context.Letters.FindAsync(request.Id);

            if (entity == null)
            {

                throw new NotFoundException(nameof(Letter), request.Id);
            }
            var contract = await _context.Contracts.Where(c => c.Number == request.ContractNumber).FirstOrDefaultAsync();

            entity.ContractId = contract.Id;
            entity.Number = request.Number;
            entity.LetterDate = request.LetterDate;
            entity.Subject = request.Subject;
            entity.Type = request.Type;
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
        catch (Exception)
        {
            throw;
        }
    }
}

