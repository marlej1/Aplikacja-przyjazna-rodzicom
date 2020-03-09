using BoboTu.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoboTu.Data
{
    public class BoboTuDbContext : DbContext
    {
        public BoboTuDbContext(DbContextOptions<BoboTuDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }

    }
}
