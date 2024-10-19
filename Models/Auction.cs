using System;
namespace AutoHub.Models
{
    public class Auction
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal StartingBid { get; set; }
        public DateTime EndTime { get; set; }

        // New property to store the image file name
        public string ImageFileName { get; set; }

        // List of bids related to this auction
        public List<Bid> Bids { get; set; } = new List<Bid>();
    }
}

