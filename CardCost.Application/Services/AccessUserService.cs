using AutoMapper;
using CardCost.Application.Interfaces;
using CardCost.Core.Models;
using CardCost.Core.Entities;
using CardCost.Core.Repositories;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CardCost.Application.Services
{
    public class AccessUserService : IAccessUserService
    {
        #region Fields

        private const string BearerSecret = "tAhu65&6Hdhb42?5Am6d94m$4Q*nui71Okm86*k2duH7*0x3cjf1C00&4bCc!h469cTe&9j7tIu9j58$Cix*p463kb4Y!w98xpN?j691wXu026a&";
        private readonly IAccessUserRepository _accessUserRepository;
        private readonly IMapper _mapper;

        #endregion

        #region Constructor

        public AccessUserService(IAccessUserRepository accessUserRepository, IMapper mapper)
        {
            _accessUserRepository = accessUserRepository;
            _mapper = mapper;
        }

        #endregion

        #region Public Methods

        public async Task<AccessUser> CreateUser(AccessUserInput request)
        {
            var isValid = this.ValidateRequest(request);

            if (isValid)
            {
                byte[] passwordHash, passwordSalt;
                this.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);

                try
                {
                    var userEntity = _mapper.Map<AccessUser>(request);

                    userEntity.PasswordHash = passwordHash;
                    userEntity.PasswordSalt = passwordSalt;

                    var user = await _accessUserRepository.AddUserAsync(userEntity);
                    if (user == null)
                        return null;
                    return user;
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error has occured. {ex}");
                }
            }
            return null;
        }

        public async Task<AccessUser> GetUser(AccessUserInput request)
        {
            var isValid = this.ValidateRequest(request);

            if (isValid)
            {
                var user = await _accessUserRepository.GetUserAsync(request.Username);

                if (user == null || !VerifyPassword(request.Password, user.PasswordHash, user.PasswordSalt))
                    return null;

                user.PasswordHash = new byte[0];
                user.PasswordSalt = new byte[0];

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(BearerSecret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(10),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                user.Token = tokenHandler.WriteToken(token);

                return user;
            }

            return null;
        }

        #endregion

        #region Private Methods

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) return false;
                }
            }
            return true;
        }

        private bool ValidateRequest(AccessUserInput request)
        {
            return request != null &&
                !string.IsNullOrEmpty(request.Password) &&
                !string.IsNullOrWhiteSpace(request.Password) &&
                !string.IsNullOrEmpty(request.Username) &&
                !string.IsNullOrWhiteSpace(request.Username);
        }

    #endregion
}
}
