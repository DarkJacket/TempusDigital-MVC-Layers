using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DAL.Map;
using BOL.Entity;


namespace DAL
{
    public class TempusDigitalContext : DbContext
    {
        public TempusDigitalContext(DbContextOptions options) : base(options) { }


        public DbSet<Cliente> Cliente { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new ClienteMap());

            base.OnModelCreating(modelBuilder);

        }
    }
}
 