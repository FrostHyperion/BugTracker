using BugTracker.DAL;
using BugTracker.Models;

namespace BugTracker.BLL;

public class UserBusinessLogicLayer
{
    private readonly IRepository<User> _userRepository;

    public UserBusinessLogicLayer(IRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }
}
