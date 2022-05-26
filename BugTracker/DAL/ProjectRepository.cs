using BugTracker.Data;
using BugTracker.Models;

namespace BugTracker.DAL;

public class ProjectRepository : IRepository<Project>
{
    private readonly ApplicationDbContext _context;

    public ProjectRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<Project> GetList(Func<Project, bool>? whereFunction)
    {
        List<Project>? projects = null;
        if (whereFunction != null)
        {
            projects=_context.Projects.Where(whereFunction).ToList();
        }
        return projects;

    }

    public Project? Get(Func<Project, bool>? firstFunction)
    {
        Project? project = null;
        if (firstFunction != null)
        {
            project = _context.Projects.First(firstFunction);

          }  
            return project;

        
    }
    
    public void Update(Project? entity)
    {
        if(entity is not null) _context.Projects.Update(entity);
    }

    public void Create(Project? entity)
    {
        if(entity != null)_context.Projects.Add(entity);
    }

    public void Delete(Project? entity)
    {
        if(entity is not null) {
            _context.Projects.Remove(entity);
        }
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}
