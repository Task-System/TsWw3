using Microsoft.EntityFrameworkCore;
using TsWw3TelegramBot.Models;

namespace TsWw3TelegramBot.Databases
{
    public class TsWw3Context : DbContext
    {
        public TsWw3Context(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<TsWwUser> TsWwUsers => Set<TsWwUser>();
    }
}
