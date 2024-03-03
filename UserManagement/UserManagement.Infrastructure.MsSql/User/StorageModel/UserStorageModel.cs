using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Infrastructure.MsSql.User.StorageModel
{
    public record UserStorageModel(Guid Id, string FirstName, string LastName)
    {
        public static Domain.User.User ToDomain(UserStorageModel model, string email)
        {
            return Domain.User.User.Reconstruct(model.Id, model.FirstName, model.LastName, email);
        }
    };
}
