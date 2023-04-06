
using ContractMng.Application.ContractBase.ContractDocuments.Commands.Create;
using ContractMng.Application.ContractBase.ContractDocuments.Commands.Delete;
using ContractMng.Application.ContractBase.ContractDocuments.Commands.Update;
using ContractMng.Application.ContractBase.ContractDocuments.Queries.Get;
using Microsoft.AspNetCore.Mvc;

namespace ContractMng.WebUI.Controllers;

[ApiController]
[Route("[controller]")]
public class ContractDocumentController : ApiControllerBase
{
   

    private readonly ILogger<ContractDocumentController> _logger;

    public ContractDocumentController(ILogger<ContractDocumentController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<ContractDocumentVm>> Get()
    {

        return await Mediator.Send(new GetContractDocumentQuery());

    }


    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateContractDocumentCommand command)
    {

        return await Mediator.Send(command);           

    }


    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id,UpdateContractDocumentCommand command)
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

         await Mediator.Send(new DeleteContractDocumentCommand() { Id=id});
        return NoContent();

    }
}




