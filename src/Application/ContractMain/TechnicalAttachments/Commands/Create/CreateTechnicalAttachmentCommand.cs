using ContractMng.Application.Common.Interfaces;
using ContractMng.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ContractMng.Application.ContractMain.TechnicalAttachments.Commands.Create;

public class CreateTechnicalAttachmentCommand : IRequest<int>
{

    public string Name { get; set; }
    public string Number { get; set; }
    public IFormFile File { get; set; }
    public string ContractNumber { get; set; }
}

public class CreateTechnicalAttachmentCommandHandler : IRequestHandler<CreateTechnicalAttachmentCommand, int>
{
    private readonly IApplicationDbContext _context;
    private readonly IMediator _mediator;
    private readonly IConfiguration _configuration;

    public CreateTechnicalAttachmentCommandHandler(IApplicationDbContext context, IMediator mediator,IConfiguration configuration)
    {
        _context = context;
        _mediator = mediator;
        _configuration = configuration;
    }

    public async Task<int> Handle(CreateTechnicalAttachmentCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var contract = await _context.Contracts.Where(c => c.Number == request.ContractNumber).FirstOrDefaultAsync();

            var entity = new TechnicalAttachment()
            {
                ContractId = contract.Id,
                Name = request.Name,
                Number = request.Number,
                FileName = request.File.FileName

            };

            if (request.File.Length > 0)
            {
                var filePath=_configuration["AttachmentsPath"];
                using (var stream = new FileStream(Path.Combine(filePath, request.File.FileName), FileMode.Create))
                {
                    await (request.File.CopyToAsync(stream));
                }
                entity.FilePath = filePath;
            }

            await _context.TechnicalAttachments.AddAsync(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
        catch (Exception)
        {
            throw;
        }
    }
}

