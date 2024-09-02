using Microsoft.EntityFrameworkCore;

namespace RockClub.Infra.Persistence
{
    public class RockClubDbContext(DbContextOptions options) : DbContext(options)
    {

    }
}
