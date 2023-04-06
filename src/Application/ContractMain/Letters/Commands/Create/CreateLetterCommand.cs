using ContractMng.Application.Common.Interfaces;
using MediatR;
using ContractMng.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContractMng.Application.ContractMain.Letters.Commands.Create;

public class CreateLetterCommand : IRequest<int>
{

    public string Type { get; set; }
    public string Subject { get; set; }
    public string Number { get; set; }
    public string LetterDate { get; set; }
    public string ContractNumber { get; set; }
}

public class CreateLetterCommandHandler : IRequestHandler<CreateLetterCommand, int>
{
    private readonly IApplicationDbContext _context;
    private readonly IMediator _mediator;

    public CreateLetterCommandHandler(IApplicationDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    public async Task<int> Handle(CreateLetterCommand request, CancellationToken cancellationToken)
    {
     try{

            var contract = await _context.Contracts.Where(c => c.Number == request.ContractNumber).FirstOrDefaultAsync();
     
        var entity= new Letter()
        {
            ContractId=contract.Id,
            Number=request.Number,
            LetterDate=request.LetterDate,
            Subject=request.Subject,
            Type=request.Type
        };
         await _context.Letters.AddAsync(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
     }
     catch(Exception){
     throw;
     }
    }
}

