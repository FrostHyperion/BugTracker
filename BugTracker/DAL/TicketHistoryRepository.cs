using BugTracker.Data;
using BugTracker.Models;

namespace BugTracker.DAL;
    public class TicketHistoryRepository : IRepository<TicketHistory>
{
    private readonly ApplicationDbContext _context; //

    public TicketHistoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Create(TicketHistory? entity)
    {
        if(entity != null) _context.TicketHistories.Add(entity);
    }

    public void Delete(TicketHistory? entity)
    {
        if (entity is not null) _context.TicketHistories.Remove(entity);
    }

    public TicketHistory? Get(Func<TicketHistory, bool>? firstFunction)
    {
        TicketHistory? Tickethistories = null;

        if (firstFunction != null)
        {
            Tickethistories = _context.TicketHistories.First(firstFunction);

        }
        return Tickethistories;
    }

    public List<TicketHistory>? GetList(Func<TicketHistory, bool>? whereFunction)
    {
        List<TicketHistory> Tickethistories = null;
        if (whereFunction != null)
        {
            Tickethistories = _context.TicketHistories.Where(whereFunction).ToList();
        }
        return Tickethistories;
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    public void Update(TicketHistory? entity)
    {
        if (entity != null) _context.TicketHistories.Update(entity);

    }
}
