using Microsoft.AspNetCore.Mvc;

namespace RestWithAspNetCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {

            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                return Ok(ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber));
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
        public IActionResult Subtraction(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                return Ok(ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber));
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
        public IActionResult Multiplication(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                return Ok(ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber));
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("divison/{firstNumber}/{secondNumber}")]
        public IActionResult Divison(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                return Ok(ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber));
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("mean/{firstNumber}/{secondNumber}")]
        public IActionResult Mean(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                return Ok((ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2);
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("square-root/{firstNumber}")]
        public IActionResult SquareRoot(string firstNumber)
        {
            if (IsNumeric(firstNumber))
            {
                return Ok(Math.Sqrt((double)ConvertToDecimal(firstNumber)));
            }
            return BadRequest("Invalid Input");
        }


        private decimal ConvertToDecimal(string strNumber)
        {
            return decimal.TryParse(strNumber, out decimal result) ? result : 0;
        }

        private bool IsNumeric(string strNumber)
        {
            return double.TryParse(strNumber,
                                   System.Globalization.NumberStyles.Any,
                                   System.Globalization.CultureInfo.InvariantCulture,
                                   out _);
        }
    }
}
