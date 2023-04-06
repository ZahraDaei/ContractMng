using ContractMng.Application.Common.Interfaces;
using MediatR;
using ContractMng.Domain.Entities;
using ContractMng.Application.Common.Exceptions;


namespace ContractMng.Application.ContractBase.ContractLetters.Commands.Delete;

public class DeleteContractLetterCommand : IRequest
{
         public int Id { get; set; }
}

public class DeleteContractLetterCommandHandler : IRequestHandler<DeleteContractLetterCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IMediator _mediator;

    public DeleteContractLetterCommandHandler(IApplicationDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    public async Task<Unit> Handle(DeleteContractLetterCommand request, CancellationToken cancellationToken)
    {
        try{
         var entity = await _context.ContractLetters.FindAsync(request.Id);

        if (entity == null)
        {
            throw new NotFoundException(nameof(ContractLetter), request.Id);
        }

         
        _context.ContractLetters.Remove(entity);
        
         
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
        }
        catch(Exception){
        throw;
        }
    }
}

