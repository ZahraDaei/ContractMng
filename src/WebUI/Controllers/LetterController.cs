
using ContractMng.Application.ContractMain.Letters.Commands.Create;
using ContractMng.Application.ContractMain.Letters.Commands.Delete;
using ContractMng.Application.ContractMain.Letters.Commands.Update;
using ContractMng.Application.ContractMain.Letters.Queries.Get;
using Microsoft.AspNetCore.Mvc;

namespace ContractMng.WebUI.Controllers;

[ApiController]
[Route("[controller]")]
public class LetterController : ApiControllerBase
{
   

    private readonly ILogger<LetterController> _logger;

    public LetterController(ILogger<LetterController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<LetterVm>> Get()
    {

        return await Mediator.Send(new GetLetterQuery());

    }


    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateLetterCommand command)
    {

        return await Mediator.Send(command);           

    }


    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id,UpdateLetterCommand command)
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

         await Mediator.Send(new DeleteLetterCommand() { Id=id});
        return NoContent();

    }
}




