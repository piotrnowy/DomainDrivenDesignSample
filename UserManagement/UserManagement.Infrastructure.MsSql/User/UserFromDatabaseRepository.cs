using UserManagement.AntiCorruption.User;
using UserManagement.AntiCorruption.User.PersistenceModel;
using UserManagement.Infrastructure.MsSql.User.StorageModel;

namespace UserManagement.Infrastructure.MsSql.User
{
    public class UserFromDatabaseRepository : IUserFromDatabaseRepository
    {
        public Task<Domain.User.User> GetById(Guid userId)
        {
            return Task.FromResult(Domain.User.User.Reconstruct(userId, "John", "Doe", "someEmial@email.com"));
        }

        public Task<SearchUserResponseDto> GetUsersBySearchPhrase(string searchPhrase)
        {
            var users = new List<UserStorageModel> { new UserStorageModel(Guid.NewGuid(), "John", "Doe") };

            var mappedUsers = users.Select(u => new UserDto(u.Id, u.FirstName, u.LastName)).ToList();

            return Task.FromResult(new SearchUserResponseDto(mappedUsers));
        }

        public Task UpdateUser(Domain.User.User user)
        {
            // save to DB

            return Task.CompletedTask;
        }
    }
}
