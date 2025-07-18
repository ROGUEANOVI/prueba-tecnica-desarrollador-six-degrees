using Backend.Entities;

namespace Backend.DataAccess.Repository;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAllAsync();
}
