using Backend.Entities;

namespace Backend.BusinessLogic.Services;

public interface IUserService
{
    Task<IEnumerable<User>> GetUsersAsync();
}
