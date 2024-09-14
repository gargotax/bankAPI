using Domain.Entities;
using Domain.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CreateUserComand
{
    public class CreateUserComandHandler : ICreateUserComandHandler
    {
        private readonly IUserRepository _userRepository;
        public CreateUserComandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Guid> HandleAsync(CreateUserComand comand, CancellationToken cancellationToken)
        {
            User user = new(Guid.NewGuid(), comand.Name);
            Guid userId = await _userRepository.CreateUser(user, cancellationToken);
            return userId;
        }
    }
}
