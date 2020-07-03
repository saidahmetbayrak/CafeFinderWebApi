using System;
using CafeFinderWebApi.Model;
using Microsoft.EntityFrameworkCore;

namespace CafeFinderWebApi.Data
{
    public class CafeDbContext :DbContext
    {
       public CafeDbContext(DbContextOptions<CafeDbContext> options) : base(options) { }

        public DbSet<Cafe> Cafes { get; set; }
    }
}
