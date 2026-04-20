using BLL.Interfaces;
using DTO.PaymentMethod;
using DTO.PaymentStatus;
using Microsoft.AspNetCore.Mvc;

namespace courseWork.Controllers;

[ApiController]
[Route("paymentMethods")]
public class PaymentMethodController(IPaymentMethodService paymentMethodService) : ControllerBase
{
    [HttpGet]
    [Route("GetAll")]
    public async Task<ActionResult<List<PaymentMethodDto>>> GetPaymentMethods() =>
        Ok(await paymentMethodService.GetPaymentMethods());

    [HttpGet("{id}")]
    public async Task<ActionResult<PaymentMethodDto>> GetPaymentMethod(Guid id) =>
        Ok(await paymentMethodService.GetPaymentMethod(id));

    [HttpPost]
    public async Task<ActionResult<PaymentMethodDto>>
        CreatePaymentMethod([FromBody] CreatePaymentMethodDto paymentMethod) =>
        Ok(await paymentMethodService.CreatePaymentMethod(paymentMethod));

    [HttpPut("{id}")]
    public async Task<ActionResult<PaymentMethodDto>> UpdatePaymentMethod(Guid id,
        [FromBody] UpdatePaymentMethodDto paymentMethod)
    {
        paymentMethod.Id = id;

        return Ok(await paymentMethodService.UpdatePaymentMethod(paymentMethod));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeletePaymentMethod(Guid id)
    {
        await paymentMethodService.DeletePaymentMethod(id);
        return Ok();
    }
}