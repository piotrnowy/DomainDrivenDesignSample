using UserManagement.AntiCorruption.User;
using UserManagement.AntiCorruption.User.PersistenceModel;
using UserManagement.Infrastructure.OrderCloud.Contracts.GetUserEmail.Models;

namespace UserManagement.Infrastructure.OrderCloud
{
    public class UserFromOrderCloudRepository : IUserFromOrderCloud
    {
        public Task<UserEmailDto> GetUsersEmailByUserId(Guid userId)
        {
            var userWithEmail = new UserWithEmailResponse { Id = userId, Email = "test@email.com" };
            return Task.FromResult(new UserEmailDto(userWithEmail.Id, userWithEmail.Email));
        }

        public Task UpdateUser(Domain.User.User user)
        {
            // save to OrderCloud
            return Task.CompletedTask;
        }
    }
}
