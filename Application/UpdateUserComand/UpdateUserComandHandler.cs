using Domain.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UpdateUserComand
{
    public class UpdateUserComandHandler : IUpdateUserComandHandler
    {
        private readonly IUserRepository    _userRepository;
        public UpdateUserComandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task HandAsync(UpdateUserComand comand, CancellationToken cancellationToken)
        {
            var getUserToUpdate = await _userRepository.GetUserById(comand.Id, cancellationToken);
            if(getUserToUpdate == null)
            {
                throw new KeyNotFoundException();
            }
            getUserToUpdate.UpdateName(comand.Name);
            await _userRepository.UpdateUser(getUserToUpdate, cancellationToken);
        }
    }
}
