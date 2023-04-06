
using ContractMng.Application.ContractBase.ContractTypes.Commands.Create;
using ContractMng.Application.ContractBase.ContractTypes.Commands.Delete;
using ContractMng.Application.ContractBase.ContractTypes.Commands.Update;
using ContractMng.Application.ContractBase.ContractTypes.Queries.Get;
using Microsoft.AspNetCore.Mvc;

namespace ContractMng.WebUI.Controllers;

[ApiController]
[Route("[controller]")]
public class ContractTypeController : ApiControllerBase
{
   

    private readonly ILogger<ContractTypeController> _logger;

    public ContractTypeController(ILogger<ContractTypeController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<ContractTypeVm>> Get()
    {

        return await Mediator.Send(new GetContractTypeQuery());

    }


    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateContractTypeCommand command)
    {

        return await Mediator.Send(command);           

    }


    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id,UpdateContractTypeCommand command)
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

         await Mediator.Send(new DeleteContractTypeCommand() { Id=id});
        return NoContent();

    }
}




