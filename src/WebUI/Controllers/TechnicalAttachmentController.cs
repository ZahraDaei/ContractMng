
using ContractMng.Application.ContractMain.TechnicalAttachments.Commands.Create;
using ContractMng.Application.ContractMain.TechnicalAttachments.Commands.Delete;
using ContractMng.Application.ContractMain.TechnicalAttachments.Commands.Update;
using ContractMng.Application.ContractMain.TechnicalAttachments.Queries.Get;
using Microsoft.AspNetCore.Mvc;

namespace ContractMng.WebUI.Controllers;

[ApiController]
[Route("[controller]")]
public class TechnicalAttachmentController : ApiControllerBase
{
   

    private readonly ILogger<TechnicalAttachmentController> _logger;

    public TechnicalAttachmentController(ILogger<TechnicalAttachmentController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<TechnicalAttachmentVm>> Get()
    {

        return await Mediator.Send(new GetTechnicalAttachmentQuery());

    }


    [HttpPost]
    public async Task<ActionResult<int>> Create([FromForm] CreateTechnicalAttachmentCommand command)
    {

        return await Mediator.Send(command);           

    }


    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id,  UpdateTechnicalAttachmentCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

            await Mediator.Send(command);
        return NoContent();

    }


    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {

         await Mediator.Send(new DeleteTechnicalAttachmentCommand() { Id=id});
        return NoContent();

    }
}




