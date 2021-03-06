namespace BugTracker.Models;

public class TicketAttachment
{
    public int Id { get; set; }
    public virtual Ticket? Ticket { get; set; }
    public int TicketId { get; set; }
    public string? FilaPath { get; set; }
    public string? Description { get; set; }
    public DateTime Created { get; set; } = DateTime.Now;
    public virtual User? User { get; set; }
    public string? UserId { get; set; }
    public string? FileUrl { get; set; }
}
