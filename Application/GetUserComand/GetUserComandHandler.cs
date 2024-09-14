﻿using Domain.Entities;
using Domain.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.GetUserComand
{
    public class GetUserComandHandler : IGetUserComandHandler
    {
        private readonly IUserRepository _userRepository;
        public GetUserComandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> HandleAsync(GetUserComand comand, CancellationToken cancellationToken)
        {
            User? user = await _userRepository.GetUserById(comand.Id, cancellationToken);
            if (user == null)
            {
                throw new KeyNotFoundException();
            }
            return user;
        }
    }
}
