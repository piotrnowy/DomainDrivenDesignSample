using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Infrastructure.MsSql.User.StorageModel
{
    public record UserStorageModel(Guid Id, string FirstName, string LastName);
}
