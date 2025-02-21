using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CSharpAssignment2.Controllers
{
    [ApiController]
    [Route("api/J3")]
    public class J3Controller : ControllerBase
    {
        /// <summary>
        /// Decodes a sequence of secret instructions.
        /// </summary>
        /// <param name="request">Object containing a list of 5-digit numbers representing encoded directions and steps.</param>
        /// <returns>A list of decoded instructions.</returns>
        /// <example>
        /// POST /api/J3/SecretInstructions
        /// Request Body: {"instructions": [57234, 907, 34100, 99999]}
        /// Response: ["right 234", "right 907", "left 100"]
        /// </example>
        [HttpPost("SecretInstructions")]
        public IActionResult DecodeInstructions([FromBody] InstructionRequest request)
        {
            if (request?.Instructions == null || request.Instructions.Count < 2)
            {
                return BadRequest("At least two valid instructions are required.");
            }

            List<string> decodedInstructions = new();
            string lastDirection = "";

            foreach (int instruction in request.Instructions)
            {
                if (instruction == 99999)
                    break;

                string instructionStr = instruction.ToString("D5"); // Ensure it's always 5 digits
                int firstTwoDigits = int.Parse(instructionStr.Substring(0, 2));
                int lastThreeDigits = int.Parse(instructionStr.Substring(2));

                string direction;
                int sumFirstTwo = (firstTwoDigits / 10) + (firstTwoDigits % 10);

                if (sumFirstTwo == 0)
                {
                    direction = lastDirection; // Repeat last direction if sum is 0
                }
                else if (sumFirstTwo % 2 == 0)
                {
                    direction = "right";
                }
                else
                {
                    direction = "left";
                }

                lastDirection = direction;
                decodedInstructions.Add($"{direction} {lastThreeDigits}");
            }

            return Ok(decodedInstructions);
        }
    }

    public class InstructionRequest
    {
        public List<int> Instructions { get; set; } = new();
    }
}