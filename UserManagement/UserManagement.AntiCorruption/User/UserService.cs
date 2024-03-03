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
                var domainUser = Domain.User.User.Reconstruct(user.Id, user.FirstName, user.LastName, userEmail.Email);
                users.Add(UserDto.FromDomain(domainUser));
            }

            return users;
        }

        public async Task UpdateEmail(Guid userId, UpdateEmailDto email)
        {
            var userEmail = await _userFromOrderCloud.GetUsersEmailByUserId(userId);
            var user = await _userFromDatabaseRepository.GetById(userId);
            var domainUser = Domain.User.User.Reconstruct(user.Id, user.FirstName, user.LastName, userEmail.Email);
            domainUser.UpdateEmail(email);

            await _userFromOrderCloud.UpdateUser(domainUser);
        }
    }
}
