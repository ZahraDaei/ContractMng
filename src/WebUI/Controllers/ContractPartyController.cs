
using ContractMng.Application.ContractBase.ContractParties.Commands.Create;
using ContractMng.Application.ContractBase.ContractParties.Commands.Delete;
using ContractMng.Application.ContractBase.ContractParties.Commands.Update;
using ContractMng.Application.ContractBase.ContractParties.Queries.Get;
using Microsoft.AspNetCore.Mvc;

namespace ContractMng.WebUI.Controllers;

[ApiController]
[Route("[controller]")]
public class ContractPartyController : ApiControllerBase
{
   

    private readonly ILogger<ContractPartyController> _logger;

    public ContractPartyController(ILogger<ContractPartyController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<ContractPartyVm>> Get()
    {

        return await Mediator.Send(new GetContractPartyQuery());

    }


    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateContractPartyCommand command)
    {

        return await Mediator.Send(command);           

    }


    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id,UpdateContractPartyCommand command)
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

         await Mediator.Send(new DeleteContractPartyCommand() { Id=id});
        return NoContent();

    }
}




