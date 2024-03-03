using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Application.Handlers.GetUserListBySearchPhrase.Dtos
{
    public record GetUserListResponseDto(List<UserDto> Users);
}
