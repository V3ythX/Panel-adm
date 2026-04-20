using BLL.Interfaces;
using DTO.Payment;
using Microsoft.AspNetCore.Mvc;

namespace courseWork.Controllers;


[ApiController]
[Route("payments")]
public class PaymentController(IPaymentService paymentService):ControllerBase
{
    [HttpGet]
    [Route("GetAll")]
    public async Task<ActionResult<List<PaymentDto>>> GetPayments() => Ok(await paymentService.GetPayments());
    
    [HttpGet("{id}")]
    public async Task<ActionResult<PaymentDto>> GetPayment(Guid id)=> Ok(await paymentService.GetPayment(id));

    [HttpPost]
    public async Task<ActionResult<PaymentDto>> CreatePayment([FromBody] CreatePaymentDto payment) =>
        Ok(await paymentService.CreatePayment(payment));

    [HttpPut("{id}")]
    public async Task<ActionResult<PaymentDto>> UpdatePayment(Guid id, [FromBody] UpdatePaymentDto payment)
    {
        payment.Id = id;
        return Ok(await paymentService.UpdatePayment(payment));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await paymentService.DeletePayment(id);
        return Ok();
    }
}