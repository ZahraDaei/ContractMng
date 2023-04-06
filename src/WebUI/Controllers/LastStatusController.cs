
using ContractMng.Application.ContractMain.LastStatuses.Commands.Create;
using ContractMng.Application.ContractMain.LastStatuses.Commands.Delete;
using ContractMng.Application.ContractMain.LastStatuses.Commands.Update;
using ContractMng.Application.ContractMain.LastStatuses.Queries.Get;
using Microsoft.AspNetCore.Mvc;

namespace ContractMng.WebUI.Controllers;

[ApiController]
[Route("[controller]")]
public class LastStatusController : ApiControllerBase
{
   

    private readonly ILogger<LastStatusController> _logger;

    public LastStatusController(ILogger<LastStatusController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<LastStatusVm>> Get()
    {

        return await Mediator.Send(new GetLastStatusQuery());

    }


    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateLastStatusCommand command)
    {

        return await Mediator.Send(command);           

    }


    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id,UpdateLastStatusCommand command)
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

         await Mediator.Send(new DeleteLastStatusCommand() { Id=id});
        return NoContent();

    }
}




