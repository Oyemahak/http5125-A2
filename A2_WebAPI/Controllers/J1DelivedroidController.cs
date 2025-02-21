using Microsoft.AspNetCore.Mvc;

namespace CSharpAssignment2.Controllers
{
    [ApiController]
    [Route("api/j1")]
    public class DelivedroidController : ControllerBase
    {
        /// <summary>
        /// Calculates the final score in the Deliv-e-droid game.
        /// </summary>
        /// <param name="collisions">The number of obstacles collided with.</param>
        /// <param name="deliveries">The number of packages delivered.</param>
        /// <returns>The final score based on game rules.</returns>
        /// <example>
        /// POST /api/j1/delivedroid
        /// Request Body: collisions=2&deliveries=5
        /// Response: 730
        /// </example>
        [HttpPost("delivedroid")]
        public int CalculateScore([FromForm] int collisions, [FromForm] int deliveries)
        {
            int score = (deliveries * 50) - (collisions * 10);
            if (deliveries > collisions)
            {
                score += 500;
            }
            return score;
        }
    }
}