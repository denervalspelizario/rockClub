using Microsoft.EntityFrameworkCore;
using RockClub.Shared.Entity;

namespace RockClub.Infra.Persistence
{
    public class RockClubDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<ColaboradorModel> Colaborador { get; set; }
    }
}
