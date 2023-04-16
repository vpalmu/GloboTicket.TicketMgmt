using Microsoft.EntityFrameworkCore;

namespace GloboTicket.TicketManagement.Persistance
{
    public class DbInitialiser
    {
        private readonly GloboTicketDbContext _context;

        public DbInitialiser(GloboTicketDbContext context)
        {
            _context = context;
        }

        public void Run()
        {
            _context.Database.EnsureDeleted();
            // _context.Database.EnsureCreated();

            _context.Database.Migrate();
            // TODO: Seed with sample data
        }
    }
}
