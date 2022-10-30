using ContaBancaria.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace ContaBancaria.Api.Persistence
{
    public class BancoMatheusContext : DbContext
    {
        public DbSet<Conta> Contas { get; set; }

        public BancoMatheusContext(DbContextOptions options) : base(options)
        {
        }

    }
}
