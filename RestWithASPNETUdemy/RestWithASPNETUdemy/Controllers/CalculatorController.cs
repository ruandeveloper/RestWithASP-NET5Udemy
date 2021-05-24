using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
            if (!IsNumeric(firstNumber) || !IsNumeric(secondNumber)) return BadRequest("Invalid Input");
            
            var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
            return Ok(sum.ToString(CultureInfo.InvariantCulture));
        }
        
        [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
        public IActionResult Subtraction(string firstNumber, string secondNumber)
        {
            if (!IsNumeric(firstNumber) || !IsNumeric(secondNumber)) return BadRequest("Invalid Input");
            
            var sum = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
            return Ok(sum.ToString(CultureInfo.InvariantCulture));
        }
        
        [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
        public IActionResult Multiplication(string firstNumber, string secondNumber)
        {
            if (!IsNumeric(firstNumber) || !IsNumeric(secondNumber)) return BadRequest("Invalid Input");
            
            var sum = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
            return Ok(sum.ToString(CultureInfo.InvariantCulture));
        }
        
        [HttpGet("division/{firstNumber}/{secondNumber}")]
        public IActionResult Division(string firstNumber, string secondNumber)
        {
            if (!IsNumeric(firstNumber) || !IsNumeric(secondNumber)) return BadRequest("Invalid Input");
            
            var sum = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
            return Ok(sum.ToString(CultureInfo.InvariantCulture));
        }
        
        [HttpGet("mean/{firstNumber}/{secondNumber}")]
        public IActionResult Mean(string firstNumber, string secondNumber)
        {
            if (!IsNumeric(firstNumber) || !IsNumeric(secondNumber)) return BadRequest("Invalid Input");
            
            var sum = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2;
            return Ok(sum.ToString(CultureInfo.InvariantCulture));
        }
        
        [HttpGet("square-root/{firstNumber}/")]
        public IActionResult SquareRoot(string firstNumber)
        {
            if (!IsNumeric(firstNumber)) return BadRequest("Invalid Input");
            
            var squareRoot = Math.Sqrt((double) ConvertToDecimal(firstNumber));
            return Ok(squareRoot.ToString(CultureInfo.InvariantCulture));
        }

        private static decimal ConvertToDecimal(string srtNumber)
        {
            return decimal.TryParse(srtNumber, out var decimalValue) ? decimalValue : 0;
        }

        private static bool IsNumeric(string srtNumber)
        {
            var isNumber = double.TryParse(
                srtNumber, 
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo, 
                out _);
            return isNumber;
        }
    }
}
