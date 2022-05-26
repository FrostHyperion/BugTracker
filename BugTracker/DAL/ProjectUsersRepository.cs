
using BugTracker.Data;
using BugTracker.Models;

namespace BugTracker.DAL;

public class ProjectUsersRepository : IRepository<ProjectUser>
{
    private readonly ApplicationDbContext _context; //

    public ProjectUsersRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Create(ProjectUser? entity)
    {
        if (entity != null) _context.ProjectUsers.Add(entity);

    }

    public void Delete(ProjectUser? entity)
    {   
        if (entity is not null)
        {
            _context.ProjectUsers.Remove(entity);
        }
    }

    public ProjectUser? Get(Func<ProjectUser, bool>? firstFunction)
    {
        ProjectUser? projectUsers = null;
        if(firstFunction != null)
        {
            projectUsers = _context.ProjectUsers.First(firstFunction);
            
        }
        return projectUsers;
    }

    public List<ProjectUser>? GetList(Func<ProjectUser, bool>? whereFunction)
    {
        List<ProjectUser>? projectsusers = null;
        if (whereFunction != null)
        {
            projectsusers = _context.ProjectUsers.Where(whereFunction).ToList();
        }
        return projectsusers;

    }

    public void Save()
    {
        _context.SaveChanges();
    }

    public void Update(ProjectUser? entity)
    {
        if(entity != null)_context.ProjectUsers.Update(entity);
    }
}
