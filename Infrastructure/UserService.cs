using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Infrastructure
{
    public interface IUserService
    {
        bool Authenticate(User item);
        List<User> GetAll();
        User GetDetails(int id);
    }
    public class UserService : IUserService
    {
        SchoolManagementDbContext _context;
        public UserService (SchoolManagementDbContext context)
        {
            _context=context;
        }
        public bool Authenticate(User item)
        {
            var obj=_context.Users.FirstOrDefault(
                c=>c.StaffTypeId.Equals(item.StaffTypeId) &&
                    c.TypeName.Equals(item.TypeName)
            );
            if(obj !=null)
                return true;
            else 
                return false;
        }
        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }
        public User GetDetails(int id)
        {
            throw new NotImplementedException();
        }
    }
}