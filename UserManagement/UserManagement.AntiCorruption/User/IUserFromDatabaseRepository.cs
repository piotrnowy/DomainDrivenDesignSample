using UserManagement.AntiCorruption.User.PersistenceModel;
using UserManagement.Domain.User;
namespace UserManagement.AntiCorruption.User
{
    public interface IUserFromDatabaseRepository
    {
        Task<SearchUserResponseDto> GetUsersBySearchPhrase(string searchPhrase);
        Task<UserDto> GetById(Guid userId);
        Task UpdateUser(UserDto user);
    }
}
