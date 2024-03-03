using UserManagement.AntiCorruption.User.PersistenceModel;
using UserManagement.Domain.User;
namespace UserManagement.AntiCorruption.User
{
    public interface IUserFromDatabaseRepository
    {
        Task<SearchUserResponseDto> GetUsersBySearchPhrase(string searchPhrase);
        Task<Domain.User.User> GetById(Guid userId);
        Task UpdateUser(Domain.User.User user);
    }
}
