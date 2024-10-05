// Controllers/CalculatorController.cs
using Microsoft.AspNetCore.Mvc;

namespace CalcApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculatorController : ControllerBase
    {
        [HttpPost]
        public IActionResult Calculate([FromBody] CalculationRequest request)
        {
            double result;

            switch (request.Operation.ToLower())
            {
                case "add":
                    result = request.Num1 + request.Num2;
                    break;
                case "subtract":
                    result = request.Num1 - request.Num2;
                    break;
                case "multiply":
                    result = request.Num1 * request.Num2;
                    break;
                case "divide":
                    if (request.Num2 == 0)
                        return BadRequest("Division by zero is not allowed.");
                    result = request.Num1 / request.Num2;
                    break;
                default:
                    return BadRequest("Invalid operation.");
            }

            return Ok(new { result });
        }
    }

    public class CalculationRequest
    {
        public double Num1 { get; set; }
        public double Num2 { get; set; }
        public required string Operation { get; set; }
    }
}