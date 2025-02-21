using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CSharpAssignment2.Controllers
{
    [ApiController]
    [Route("api/J2")]
    public class J2AuctionController : ControllerBase
    {
        /// <summary>
        /// Determines the winner of the silent auction.
        /// </summary>
        /// <param name="bids">A list of bids, each containing a name and an amount.</param>
        /// <returns>The name of the person who won the auction.</returns>
        /// <example>
        /// POST /api/J2/SilentAuction
        /// Request Body: [{"name": "Ahmed", "bid": 300}, {"name": "Suzanne", "bid": 500}, {"name": "Ivona", "bid": 450}]
        /// Response: "Suzanne"
        /// </example>
        [HttpPost("SilentAuction")]
        public string DetermineWinner([FromBody] List<Bid> bids)
        {
            string winner = "";
            int highestBid = -1;

            foreach (var bid in bids)
            {
                if (bid.Amount > highestBid)
                {
                    highestBid = bid.Amount;
                    winner = bid.Name;
                }
            }

            return winner;
        }
    }

    public class Bid
    {
        public string Name { get; set; } = string.Empty;  // Default value
        public int Amount { get; set; }

        // Default constructor
        public Bid() { }

        // Optional: Constructor for initialization
        public Bid(string name, int amount)
        {
            Name = name;
            Amount = amount;
        }
    }
}