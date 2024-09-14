using Domain.Repos;

namespace Application.DeleteUserComand
{
    public class DeleteUserComandHandler : IDeleteUserComandHandler
    {
        private readonly IUserRepository _userRepository;
        public DeleteUserComandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task HandleAsync(DeleteUserComand comand, CancellationToken cancellationToken)
        {
            _userRepository.DeleteUser(comand.Id, cancellationToken);
            return Task.CompletedTask;
        }
    }
}
