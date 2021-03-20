using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WisdomTradeApp.Models;

namespace WisdomTradeApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Position> Positions { get; set; }
        public DbSet<TraderAccount> TraderAccount { get; set; }
        public DbSet<TraderAccount_Position> TraderAccount_Position { get; set; }
    }
}
