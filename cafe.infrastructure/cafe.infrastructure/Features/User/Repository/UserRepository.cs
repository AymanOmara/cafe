using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using cafe.Domain.Common;
using cafe.Domain.Users.DTO;
using cafe.Domain.Users.entity;
using cafe.Domain.Users.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace cafe.infrastructure.Features.User.Repository
{
    public class UserRepository : IUserRepository
    {
        public readonly UserManager<CafeUser> _userManager;
        public readonly SignInManager<CafeUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly CafeDbContext _context;
        public UserRepository(UserManager<CafeUser> userManager, SignInManager<CafeUser> signInManager, IConfiguration configuration, CafeDbContext context)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _configuration = configuration;
            _context = context;
        }

        public async Task<Result<string, Exception>> CreateUser(RegistrationDTO registration)
        {
            var isUserExict = await IsUserExist(registration.UserName, registration.Email);
            if (isUserExict)
            {
                return new Exception("Username or email already exists.");

            }
            CafeUser user = new()
            {
                Email = registration.Email,
                UserName = registration.UserName,
                EmailConfirmed = true,
            };

            var result = await _userManager.CreateAsync(user,registration.Password);

            if (!result.Succeeded) {
                return new Exception(String.Join(",", result.Errors.ToList()));
            }
            var role = (CafeRoles)registration.Role;
            
            await _userManager.AddToRoleAsync(user, role.ToString());
            return "user created success fully";
        }


        public async Task<Result<TokenDTO, Exception>> RefreshToken(TokenDTO dto)
        {
            var user = _context.Users.Where(U => U.RefreshToken == dto.RefreshToken).FirstOrDefault();
            if (user == null) {
                return new Exception("not found");
            }
            var token = await CreateJwtToken(user);
            user.RefreshToken = token.RefreshToken;
            await _userManager.UpdateAsync(user);
            return token;
        }
        public async Task<bool> IsUserExist(String userName, String email)
        {
            var isEmailExist = await _userManager.FindByEmailAsync(email);
            var isUserNameExist = await _userManager.FindByNameAsync(userName);
            return isEmailExist != null && isUserNameExist != null;
        }

        public async Task<Result<TokenDTO, Exception>> Login(LoginDTO login)
        {
            var user = await _userManager.FindByNameAsync(login.UserName);
            if (user == null) {
                return new Exception("not found");
            }
            var result = await _userManager.CheckPasswordAsync(user, login.Password);
            if (!result) {
                return new Exception("wrong password");
            }
            var token = await CreateJwtToken(user);
            user.RefreshToken = token.RefreshToken;
            await _userManager.UpdateAsync(user);
            return token;
        }
        private async Task<TokenDTO> CreateJwtToken(CafeUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var tokenDes = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Iss, _configuration["Jwt:Issuer"].ToString()),
                    new Claim(JwtRegisteredClaimNames.Aud, _configuration["Jwt:Audience"].ToString()),
                    new Claim("uid", user.Id),
                }),
                Expires = DateTime.UtcNow.AddHours(12),
                SigningCredentials = signingCredentials
            };

            tokenDes.Subject.AddClaims(roles.Select(role => new Claim(ClaimsIdentity.DefaultRoleClaimType, role)));
            var token = jwtTokenHandler.CreateToken(tokenDes);
            var jwtToken = jwtTokenHandler.WriteToken(token);
            return new TokenDTO() {AccessToken = jwtToken, RefreshToken = RefreshTokenGeneration()};
        }

        private string RefreshTokenGeneration()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
    }
}

