using UserManagement.Application.Handlers.GetUserListBySearchPhrase.Dtos;
using UserManagement.Domain.User.UpdateParameters;

namespace UserManagement.Application.Handlers
{
    public interface IUserService
    {
        Task<List<UserDto>> GetUsersBySearchPhrase(string searchPhrase);
        Task UpdateEmail(Guid userId, UpdateEmailDto email);
    }
}
