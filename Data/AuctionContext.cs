using System;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using AutoHub.Models;

namespace AutoHub.Data
{
    public class AuctionContext : DbContext
    {
        public AuctionContext(DbContextOptions<AuctionContext> options) : base(options) { }

        //public DbSet<Auction> Auctions { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}

