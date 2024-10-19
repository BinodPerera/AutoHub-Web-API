using System;
namespace AutoHub.Models
{
	public class Bid
	{
        public int Id { get; set; }
        public int AuctionId { get; set; }
        public decimal Amount { get; set; }
        public DateTime BidTime { get; set; }
        public string Bidder { get; set; }  // Username or user ID
    }
}

