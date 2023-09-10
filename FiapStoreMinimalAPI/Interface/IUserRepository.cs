using FiapStoreMinimalAPI.Entity;

namespace FiapStoreMinimalAPI.Interface
{
    public interface IUserRepository
    {
        IList<User> GetAll();
        User GetById(int id);
        void Insert(User user);
        void Update(User user);
        void Delete(int id);
    }
}
