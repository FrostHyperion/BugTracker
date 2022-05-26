using BugTracker.Data;
using BugTracker.Models;

namespace BugTracker.DAL
{
    public class TicketLogItemRepository : IRepository<TicketLogItem>
    {
        private readonly ApplicationDbContext _context;

        public TicketLogItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(TicketLogItem? entity)
        {
            if (entity != null) _context.TicketLogItems.Add(entity);
        }

        public void Delete(TicketLogItem? entity)
        {
            if (entity != null) _context.TicketLogItems.Remove(entity);
        }

        public TicketLogItem? Get(Func<TicketLogItem, bool> firstFunction)
        {
            TicketLogItem? Ticketnotifications = null;

            if (firstFunction != null)
            {
                Ticketnotifications = _context.TicketLogItems.First(firstFunction);

            }
            return Ticketnotifications;
        }

        public List<TicketLogItem> GetList(Func<TicketLogItem, bool> whereFunction)
        {
            List<TicketLogItem> Ticketnotifications = null;
            if (whereFunction != null)
            {
                Ticketnotifications = _context.TicketLogItems.Where(whereFunction).ToList();
            }
            return Ticketnotifications;
        }

        public void Update(TicketLogItem? entity)
        {
            if (entity != null) _context.TicketLogItems.Update(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
