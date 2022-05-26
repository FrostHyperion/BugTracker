using BugTracker.Data;
using BugTracker.Models;

namespace BugTracker.DAL
{
    public class UsersRepository : IRepository<User>
    {
        private readonly ApplicationDbContext _context;


        public UsersRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(User? entity)
        {
            if (entity != null) _context.Users.Add(entity);
        }

        public void Delete(User? entity)
        {
            if (entity!= null) _context.Users.Remove(entity);
        }

        public User? Get(Func<User, bool>? firstFunction)
        {

            User? userS = null;

            if (firstFunction != null)
            {
                userS = _context.Users.First(firstFunction);

            }
            return userS;
        }

        public List<User>? GetList(Func<User, bool>? whereFunction)
        {
            List<User> userS = null;
            if (whereFunction != null)
            {
                userS = _context.Users.Where(whereFunction).ToList();
            }
            return userS;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(User? entity)
        {
            if (entity is not null) _context.Users.Update(entity);
        }
    }
   }

