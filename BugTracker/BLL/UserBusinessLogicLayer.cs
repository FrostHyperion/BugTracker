using BugTracker.DAL;
using BugTracker.Models;
using Microsoft.AspNetCore.Identity;

namespace BugTracker.BLL;

public class UserBusinessLogicLayer
{
    private readonly IRepository<User> _userRepository;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<User> _userManager;

    public UserBusinessLogicLayer(IRepository<User> userRepository, RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
    {
        _userRepository = userRepository;
        _roleManager = roleManager;
        _userManager = userManager;
    }

    public List<User> GetAll()
    {
        return _userRepository.GetList(_ => true);
    }

    public User? Get(string? userId)
    {
        return _userRepository.Get(u => u.Id == userId);
    }

    public void Create(User? entity)
    {
        _userRepository.Create(entity);
        _userRepository.Save();
    }

    public void Update(User? entity)
    {
        _userRepository.Update(entity);
        _userRepository.Save();
    }

    public void Delete(User? entity)
    {
        _userRepository.Delete(entity);
        _userRepository.Save();
    }

    public async Task AssignToRole(string? userId, string? roleId)
    {
        var user = Get(userId);
        IdentityRole role = await _roleManager.FindByIdAsync(roleId);
        await _userManager.AddToRoleAsync(user, role.Name);
        _userRepository.Save();
    }

    public User? GetUserByName(string name)
    {
        return _userRepository.Get(u => u.UserName == name);
    }
}
