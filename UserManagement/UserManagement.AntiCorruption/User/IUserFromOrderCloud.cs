using UserManagement.AntiCorruption.User.PersistenceModel;

namespace UserManagement.AntiCorruption.User
{
    public interface IUserFromOrderCloud
    {
        Task<UserEmailDto> GetUsersEmailByUserId(Guid userId);
    }
}
