using ContractMng.Application.Common.Interfaces;
using MediatR;
using ContractMng.Domain.Entities;
using ContractMng.Application.Common.Exceptions;


namespace ContractMng.Application.ContractBase.ContractLetters.Commands.Update;

public class UpdateContractLetterCommand : IRequest
{
         public int Id { get; set; }
    public string LetterType { get; set; }

}

public class UpdateContractLetterCommandHandler : IRequestHandler<UpdateContractLetterCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IMediator _mediator;

    public UpdateContractLetterCommandHandler(IApplicationDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    public async Task<Unit> Handle(UpdateContractLetterCommand request, CancellationToken cancellationToken)
    {
       try{
         var entity = await _context.ContractLetters.FindAsync(request.Id);

        if (entity == null)
        {
            throw new NotFoundException(nameof(ContractLetter), request.Id);
        }

        entity.LetterType = request.LetterType;
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
       }
       catch(Exception){
       throw;
       }
    }
}

