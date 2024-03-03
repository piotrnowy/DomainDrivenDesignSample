namespace UserManagement.Application.Handlers.GetUserListBySearchPhrase.Dtos
{
    public record UserDto(Guid Id, string FirstName, string LastName, string Email);
}