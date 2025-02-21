using Microsoft.AspNetCore.Mvc;

namespace CSharpAssignment2.Controllers
{
    [ApiController]
    [Route("api/J1")]
    public class J1TelemarketerController : ControllerBase
    {
        /// <summary>
        /// Determines if a given phone number is a telemarketer number based on its last four digits.
        /// </summary>
        /// <param name="digit1">First digit of the last four digits of the phone number.</param>
        /// <param name="digit2">Second digit of the last four digits of the phone number.</param>
        /// <param name="digit3">Third digit of the last four digits of the phone number.</param>
        /// <param name="digit4">Fourth digit of the last four digits of the phone number.</param>
        /// <returns>Either "ignore" (if it's a telemarketer number) or "answer" (otherwise).</returns>
        /// <example>
        /// POST /api/J1/Telemarketer
        /// Request Body: {"digit1": 9, "digit2": 6, "digit3": 6, "digit4": 8}
        /// Response: "ignore"
        /// </example>
        [HttpPost("Telemarketer")]
        public IActionResult IsTelemarketer([FromBody] TelemarketerRequest request)
        {
            if (request == null)
            {
                return BadRequest("Input is missing.");
            }

            int first = request.Digit1;
            int second = request.Digit2;
            int third = request.Digit3;
            int fourth = request.Digit4;

            // Check if the first and last digits are 8 or 9
            // Check if the second and third digits are the same
            if ((first == 8 || first == 9) && (fourth == 8 || fourth == 9) && second == third)
            {
                return Ok("ignore");
            }

            return Ok("answer");
        }
    }

    public class TelemarketerRequest
    {
        public int Digit1 { get; set; }
        public int Digit2 { get; set; }
        public int Digit3 { get; set; }
        public int Digit4 { get; set; }
    }
}