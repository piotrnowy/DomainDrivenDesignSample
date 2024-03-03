using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.AntiCorruption.User.PersistenceModel
{
    public record SearchUserResponseDto(IReadOnlyCollection<UserDto> Users);

    public record UserDto(Guid Id, string FirstName, string LastName);
}
