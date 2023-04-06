
using ContractMng.Application.ContractBase.ContractLetters.Commands.Create;
using ContractMng.Application.ContractBase.ContractLetters.Commands.Delete;
using ContractMng.Application.ContractBase.ContractLetters.Commands.Update;
using ContractMng.Application.ContractBase.ContractLetters.Queries.Get;
using Microsoft.AspNetCore.Mvc;

namespace ContractMng.WebUI.Controllers;

[ApiController]
[Route("[controller]")]
public class ContractLetterController : ApiControllerBase
{
   

    private readonly ILogger<ContractLetterController> _logger;

    public ContractLetterController(ILogger<ContractLetterController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<ContractLetterVm>> Get()
    {

        return await Mediator.Send(new GetContractLetterQuery());

    }


    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateContractLetterCommand command)
    {

        return await Mediator.Send(command);           

    }


    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id,UpdateContractLetterCommand command)
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

         await Mediator.Send(new DeleteContractLetterCommand() { Id=id});
        return NoContent();

    }
}




