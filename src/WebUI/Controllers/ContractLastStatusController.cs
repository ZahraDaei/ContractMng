
using ContractMng.Application.ContractBase.ContractLastStatuses.Commands.Create;
using ContractMng.Application.ContractBase.ContractLastStatuses.Commands.Delete;
using ContractMng.Application.ContractBase.ContractLastStatuses.Commands.Update;
using ContractMng.Application.ContractBase.ContractLastStatuses.Queries.Get;
using Microsoft.AspNetCore.Mvc;

namespace ContractMng.WebUI.Controllers;

[ApiController]
[Route("[controller]")]
public class ContractLastStatusController : ApiControllerBase
{
   

    private readonly ILogger<ContractLastStatusController> _logger;

    public ContractLastStatusController(ILogger<ContractLastStatusController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<ContractLastStatusVm>> Get()
    {

        return await Mediator.Send(new GetContractLastStatusQuery());

    }


    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateContractLastStatusCommand command)
    {

        return await Mediator.Send(command);           

    }


    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id,UpdateContractLastStatusCommand command)
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

         await Mediator.Send(new DeleteContractLastStatusCommand() { Id=id});
        return NoContent();

    }
}




