using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UpdateUserComand
{
    public interface IUpdateUserComandHandler
    {
        Task HandAsync(UpdateUserComand comand, CancellationToken cancellationToken);
    }
}
