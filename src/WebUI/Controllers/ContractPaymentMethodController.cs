
using ContractMng.Application.ContractBase.ContractPaymentMethods.Commands.Create;
using ContractMng.Application.ContractBase.ContractPaymentMethods.Commands.Delete;
using ContractMng.Application.ContractBase.ContractPaymentMethods.Commands.Update;
using ContractMng.Application.ContractBase.ContractPaymentMethods.Queries.Get;
using Microsoft.AspNetCore.Mvc;

namespace ContractMng.WebUI.Controllers;

[ApiController]
[Route("[controller]")]
public class ContractPaymentMethodController : ApiControllerBase
{
   

    private readonly ILogger<ContractPaymentMethodController> _logger;

    public ContractPaymentMethodController(ILogger<ContractPaymentMethodController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<ContractPaymentMethodVm>> Get()
    {

        return await Mediator.Send(new GetContractPaymentMethodQuery());

    }


    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateContractPaymentMethodCommand command)
    {

        return await Mediator.Send(command);           

    }


    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id,UpdateContractPaymentMethodCommand command)
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

         await Mediator.Send(new DeleteContractPaymentMethodCommand() { Id=id});
        return NoContent();

    }
}




