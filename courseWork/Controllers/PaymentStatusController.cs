using BLL.Interfaces;
using DTO.PaymentStatus;
using Microsoft.AspNetCore.Mvc;

namespace courseWork.Controllers;
[ApiController]
[Route("paymentStatuses")]
public class PaymentStatusController(IPaymentStatusService paymentStatusService):ControllerBase
{
    [HttpGet]
    [Route("GetAll")]
    public async Task<ActionResult<List<PaymentStatusDto>>> GetPaymentStatuses() => Ok(await paymentStatusService.GetPaymentStatuses());
    
    [HttpGet("{id}")]
    public async Task<ActionResult<PaymentStatusDto>> GetPaymentStatus(Guid id)=> Ok(await paymentStatusService.GetPaymentStatus(id));
    
    [HttpPost]
    public async Task<ActionResult<PaymentStatusDto>> CreatePaymentStatus([FromBody]CreatePaymentStatusDto paymentStatus)=> Ok(await paymentStatusService.CreatePaymentStatus(paymentStatus));
    
    [HttpPut("{id}")]
    public async Task<ActionResult<PaymentStatusDto>> UpdatePaymentStatus(Guid id, [FromBody] UpdatePaymentStatusDto paymentStatus)
    {
        paymentStatus.Id = id;
        
        return Ok(await paymentStatusService.UpdatePaymentStatus(paymentStatus));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeletePaymentStatus(Guid id)
    {
        await paymentStatusService.DeletePaymentStatus(id);
        return Ok();
    }
}