using BugTracker.Data;
using BugTracker.Models;

namespace BugTracker.DAL;

public class TicketCommentRepository : IRepository<TicketComment>
{
    private readonly ApplicationDbContext _context; //

    public TicketCommentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Create(TicketComment? entity)
    {
        if (entity != null) _context.TicketComments.Add(entity);

    }

    public void Delete(TicketComment? entity)
    {
        if (entity is not null)
        {
            _context.TicketComments.Remove(entity);
        }
    }

    public TicketComment? Get(Func<TicketComment, bool>? firstFunction)
    {
        TicketComment? Ticketcomments = null;

        if (firstFunction != null)
        {
            Ticketcomments = _context.TicketComments.First(firstFunction);

        }
        return Ticketcomments;
    }

        public List<TicketComment>? GetList(Func<TicketComment, bool>? whereFunction)
    {
        List<TicketComment> Ticketcomments = null;
        if (whereFunction != null)
        {
            Ticketcomments = _context.TicketComments.Where(whereFunction).ToList();
        }
        return Ticketcomments;
    }

    public void Save()
    {
        _context.SaveChanges();

    }

    public void Update(TicketComment? entity)
    {
        if (entity != null) _context.TicketComments.Update(entity);
    }
}
