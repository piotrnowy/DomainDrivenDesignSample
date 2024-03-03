using UserManagement.Application.Handlers;
using UserManagement.Application.Handlers.GetUserListBySearchPhrase.Dtos;
using UserManagement.Domain.User.UpdateParameters;

namespace UserManagement.AntiCorruption.User
{
    public class UserService : IUserService
    {
        private readonly IUserFromDatabaseRepository _userFromDatabaseRepository;
        private readonly IUserFromOrderCloud _userFromOrderCloud;

        public UserService(IUserFromDatabaseRepository userFromDatabaseRepository, IUserFromOrderCloud userFromOrderCloud)
        {
            _userFromDatabaseRepository = userFromDatabaseRepository;
            _userFromOrderCloud = userFromOrderCloud;
        }

        public async Task<List<UserDto>> GetUsersBySearchPhrase(string searchPhrase)
        {
            var usersFromDatabase = await _userFromDatabaseRepository.GetUsersBySearchPhrase(searchPhrase);

            var users = new List<UserDto>();
            foreach (var user in usersFromDatabase.Users)
            {
                var userEmail = await _userFromOrderCloud.GetUsersEmailByUserId(user.Id);
                users.Add(new UserDto(user.Id, user.FirstName, user.LastName, userEmail.Email));
            }

            return users;
        }

        public async Task UpdateEmail(Guid userId, UpdateEmailDto email)
        {
            var user = await _userFromDatabaseRepository.GetById(userId);
            user.UpdateEmail(email);

            await _userFromDatabaseRepository.UpdateUser(user);
        }
    }
}
