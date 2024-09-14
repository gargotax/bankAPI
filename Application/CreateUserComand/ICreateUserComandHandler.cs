using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CreateUserComand
{
    public interface ICreateUserComandHandler
    {
        Task<Guid> HandleAsync(CreateUserComand comand, CancellationToken cancellationToken);
    }
}
