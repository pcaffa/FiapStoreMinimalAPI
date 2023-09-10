using FiapStoreMinimalAPI.Entity;
using FiapStoreMinimalAPI.Interface;

namespace FiapStoreMinimalAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private IList<User> _users = new List<User>();
        public void Delete(int id)
        {
            _users.Remove(GetById(id));
        }

        public IList<User> GetAll()
        {
            return _users;
        }

        public User GetById(int id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }

        public void Insert(User user)
        {
            _users.Add(user);
        }

        public void Update(User user)
        {
            var userUpdate = GetById(user.Id);
            if(userUpdate != null)
                userUpdate.Name = user.Name;
        }
    }
}
