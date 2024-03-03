using UserManagement.AntiCorruption.User;
using UserManagement.AntiCorruption.User.PersistenceModel;
using UserManagement.Infrastructure.MsSql.User.StorageModel;

namespace UserManagement.Infrastructure.MsSql.User
{
    public class UserFromDatabaseRepository : IUserFromDatabaseRepository
    {
        public Task<UserDto> GetById(Guid userId)
        {
            return Task.FromResult(new UserDto(userId, "John", "Doe"));
        }

        public Task<SearchUserResponseDto> GetUsersBySearchPhrase(string searchPhrase)
        {
            var users = new List<UserStorageModel> { new UserStorageModel(Guid.NewGuid(), "John", "Doe") };

            var mappedUsers = users.Select(u => new UserDto(u.Id, u.FirstName, u.LastName)).ToList();

            return Task.FromResult(new SearchUserResponseDto(mappedUsers));
        }

        public Task UpdateUser(UserDto user)
        {
            // save to DB
            return Task.CompletedTask;
        }
    }
}
