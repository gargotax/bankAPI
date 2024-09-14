using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repos
{
    public interface IUserRepository
    {
        Task<Guid> CreateUser(User user, CancellationToken cancellationToken);
        Task<User?> GetUserById(Guid id, CancellationToken cancellationToken);
        Task UpdateUser(User user, CancellationToken cancellationToken);
        Task DeleteUser(Guid id, CancellationToken cancellationToken);
    }
}
