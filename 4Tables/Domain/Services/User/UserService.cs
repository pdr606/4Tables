﻿using _4Tables.Application.Controllers.User.Adapter;
using _4Tables.Application.Controllers.User.Dto;
using _4Tables.Config.Auth;
using _4Tables.Domain.Base.Common;
using _4Tables.Domain.Entities.User;
using _4Tables.Domain.Repositories.User;
using BCrypt.Net;

namespace _4Tables.Domain.Services.User
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<BasicResult> Add(CreateUserDto dto)
        {
            BasicResult result = new BasicResult();
            if (await ((IUserService)this).ExistUser(dto.email))
            {
                result.ISSUCESS(false);
                result.ERROR(new Error(System.Net.HttpStatusCode.Conflict, $"Usuário com email {dto.email} já cadastrado"));
                return result;
            }

            var entity = UserAdapter.toDomainModel(dto);
            entity.AddPasswordHash(GenerateBCryptHash(dto.password));

            await _userRepository.Add(entity);
            result.ISSUCESS(true);
            return result;
        }

        public async Task<bool> ExistUser(string email)
        {
            return await _userRepository.ExistUserByEmail(email);
        }

        public async Task<UserEntity> FindEntityByEmail(string email)
        {
            return await _userRepository.FindUserEntityByEmail(email);
        }

        public bool ValidateCredentials(string loginPassword, string userPassword, string loginEmail, string userEmail)
        {
            return (BCrypt.Net.BCrypt.Verify(loginPassword, userPassword) && loginEmail == userEmail);
        }

        private string GenerateBCryptHash(string password) {

            var salt = BCrypt.Net.BCrypt.GenerateSalt(12);

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(password, salt);

            return passwordHash;
        }
    }
}
