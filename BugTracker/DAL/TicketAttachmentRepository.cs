using BugTracker.Data;
using BugTracker.Models;


namespace BugTracker.DAL;

    public class TicketAttachmentRepository: IRepository<TicketAttachment>
    {
        private readonly ApplicationDbContext _context; //

    public TicketAttachmentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Create(TicketAttachment? entity)
        {
        if (entity != null) _context.TicketAttachments.Add(entity);
            
        }

        public void Delete(TicketAttachment? entity)
        {
        if (entity is not null)
        {
            _context.TicketAttachments.Remove(entity);
        }
    }

        public TicketAttachment? Get(Func<TicketAttachment, bool>? firstFunction)
        {
        TicketAttachment? ticketAttachments = null;
        if (firstFunction != null)
        {
           ticketAttachments = _context.TicketAttachments.First(firstFunction);

        }
        return ticketAttachments;
    }


        public List<TicketAttachment>? GetList(Func<TicketAttachment, bool>? whereFunction)
        {
        List<TicketAttachment>? ticketAttachments = null;
        if (whereFunction != null)
        {
            ticketAttachments = _context.TicketAttachments.Where(whereFunction).ToList();
        }
        return ticketAttachments;
    }

        public void Save()
        {
                 _context.SaveChanges();

    }

    public void Update(TicketAttachment? entity)
        {
        if (entity != null) _context.TicketAttachments.Update(entity);

    }
}
