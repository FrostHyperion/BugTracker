using BugTracker.Data;
using BugTracker.Models;

namespace BugTracker.DAL;
public class TicketRepository : IRepository<Ticket>
{
    private readonly ApplicationDbContext _context;

    public TicketRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Create(Ticket? entity)
    {
        if(entity!=null)_context.Tickets.Add(entity);
    }

    public void Delete(Ticket? entity)
    {
        if (entity is not null) _context.Tickets.Remove(entity);
    }

    public Ticket? Get(Func<Ticket, bool>? firstFunction)
    {
        Ticket? Ticket = null;

        if (firstFunction != null)
        {
            Ticket = _context.Tickets.First(firstFunction);

        }
        return Ticket;
    }

    public List<Ticket>? GetList(Func<Ticket, bool>? whereFunction)
    {
        List<Ticket> Ticket = null;
        if (whereFunction != null)
        {
            Ticket = _context.Tickets.Where(whereFunction).ToList();
        }
        return Ticket;
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    public void Update(Ticket? entity)
    {
        if(entity is not null)_context.Tickets.Update(entity);
    }
}
