using ContractMng.Application.Common.Interfaces;
using MediatR;
using ContractMng.Domain.Entities;


namespace ContractMng.Application.ContractBase.ContractLetters.Commands.Create;

public class CreateContractLetterCommand : IRequest<int>
{
    public string LetterType { get; set; }


}

public class CreateContractLetterCommandHandler : IRequestHandler<CreateContractLetterCommand, int>
{
    private readonly IApplicationDbContext _context;
    private readonly IMediator _mediator;

    public CreateContractLetterCommandHandler(IApplicationDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    public async Task<int> Handle(CreateContractLetterCommand request, CancellationToken cancellationToken)
    {
        try
        {

            var entity = new ContractLetter(){
             LetterType=request.LetterType
        };
         await _context.ContractLetters.AddAsync(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
     }
     catch(Exception){
     throw;
     }
    }
}

