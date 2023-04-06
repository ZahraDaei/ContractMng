
using ContractMng.Application.ContractBase.ContractBudgets.Commands.Create;
using ContractMng.Application.ContractBase.ContractBudgets.Commands.Delete;
using ContractMng.Application.ContractBase.ContractBudgets.Commands.Update;
using ContractMng.Application.ContractBase.ContractBudgets.Queries.Get;
using Microsoft.AspNetCore.Mvc;

namespace ContractMng.WebUI.Controllers;

[ApiController]
[Route("[controller]")]
public class ContractBudgetController : ApiControllerBase
{
   

    private readonly ILogger<ContractBudgetController> _logger;

    public ContractBudgetController(ILogger<ContractBudgetController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<ContractBudgetVm>> Get()
    {

        return await Mediator.Send(new GetContractBudgetQuery());

    }


    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateContractBudgetCommand command)
    {

        return await Mediator.Send(command);           

    }


    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id,UpdateContractBudgetCommand command)
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

         await Mediator.Send(new DeleteContractBudgetCommand() { Id=id});
        return NoContent();

    }
}




