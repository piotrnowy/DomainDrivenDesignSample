namespace UserManagement.Application.Handlers.GetUserListBySearchPhrase.Dtos
{
    public record UserDto(Guid Id, string FirstName, string LastName, string Email)
    {
        public static UserDto FromDomain(Domain.User.User user)
        {
            return new UserDto(user.Id, user.FirstName, user.LastName, user.Email);
        }
    }
}