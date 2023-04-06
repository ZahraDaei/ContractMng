using ContractMng.Application.Reports.ReportByParties.Get;
using ContractMng.Application.Reports.ReportByPayments.Get;
using ContractMng.Application.Reports.ReportByStatuses.Get;
using Microsoft.AspNetCore.Mvc;

namespace ContractMng.WebUI.Controllers;

[ApiController]
[Route("[controller]")]
public class ReportController : ApiControllerBase
{
   

    private readonly ILogger<ContractController> _logger;

    public ReportController(ILogger<ContractController> logger)
    {
        _logger = logger;
    }

    [HttpGet("ReportByParties")]
    public async Task<ActionResult<ReportByPartyVm>> GetReportByParties()
    {

        return await Mediator.Send(new ReportByPartyQuery());

    }
    [HttpGet("ReportByPayments")]
    public async Task<ActionResult<ReportByPaymentVm>> GetReportByPayments()
    {

        return await Mediator.Send(new ReportByPaymentQuery());

    }
    [HttpGet("ReportByStatuses")]
    public async Task<ActionResult<ReportByStatusVm>> GetReportByStatuses()
    {

        return await Mediator.Send(new ReportByStatusQuery());

    }


   
}




