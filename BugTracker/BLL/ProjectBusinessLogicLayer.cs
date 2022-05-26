using BugTracker.DAL;
using BugTracker.Models;
using Microsoft.AspNetCore.Identity;

namespace BugTracker.BLL
{
    public class ProjectBusinessLogic
    {
        IRepository<ProjectUser> repo;
        IRepository<Project> repos;
        private readonly UserManager<User> _userManager;
        public ProjectBusinessLogic(IRepository<ProjectUser> repoArg, IRepository<Project> repoArgs, UserManager<User> userManager)
        {
            repo = repoArg;
            _userManager = userManager;
            repos = repoArgs;
        }

        public void AddProject(Project project)
        {
            repos.Create(project);
            repos.Save();
        }

        public void Update(Project project)
        {
            repos.Update(project);
            repos.Save();
        }

        public void UsersAssign(string userId, int projectId)
        {
            ProjectUser pu = new()
            {
                ProjectId = projectId,
                UserId = userId
            };

            repo.Create(pu);
        }

        public void UsersunAssign(string userId, int projectId)
        {
            ProjectUser? pu = repo.Get(p => p.UserId == userId && p.ProjectId == projectId);

            repo.Delete(pu);
        }

    }
}
