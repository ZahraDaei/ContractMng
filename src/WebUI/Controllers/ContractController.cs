
using ContractMng.Application.ContractMain.Contracts.Commands.Create;
using ContractMng.Application.ContractMain.Contracts.Commands.Delete;
using ContractMng.Application.ContractMain.Contracts.Commands.Update;
using ContractMng.Application.ContractMain.Contracts.Queries.Get;
using Microsoft.AspNetCore.Mvc;

namespace ContractMng.WebUI.Controllers;

[ApiController]
[Route("[controller]")]
public class ContractController : ApiControllerBase
{
   

    private readonly ILogger<ContractController> _logger;

    public ContractController(ILogger<ContractController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<ContractVm>> Get()
    {

        return await Mediator.Send(new GetContractQuery());

    }


    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateContractCommand command)
    {

        return await Mediator.Send(command);           

    }


    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id,UpdateContractCommand command)
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

         await Mediator.Send(new DeleteContractCommand() { Id=id});
        return NoContent();

    }
}




