using BugTracker.Data;
using BugTracker.Models;

namespace BugTracker.DAL;
public class TicketNotificationRepository : IRepository<TicketNotification>
{
    private readonly ApplicationDbContext _context;

    public TicketNotificationRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Create(TicketNotification? entity)
    {
       if(entity != null) _context.TicketNotifications.Add(entity);
    }

    public void Delete(TicketNotification? entity)
    {
        if (entity != null) _context.TicketNotifications.Remove(entity);
    }

    public TicketNotification? Get(Func<TicketNotification, bool>? firstFunction)
    {
        TicketNotification? Ticketnotifications = null;

        if (firstFunction != null)
        {
            Ticketnotifications = _context.TicketNotifications.First(firstFunction);

        }
        return Ticketnotifications;
    }

    public List<TicketNotification>? GetList(Func<TicketNotification, bool>? whereFunction)
    {
        List<TicketNotification> Ticketnotifications = null;
        if (whereFunction != null)
        {
            Ticketnotifications = _context.TicketNotifications.Where(whereFunction).ToList();
        }
        return Ticketnotifications;
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    public void Update(TicketNotification? entity)
    {
        if(entity!=null)_context.TicketNotifications.Update(entity);
    }
}
