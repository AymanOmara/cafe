using cafe.Domain.Common;
using cafe.Domain.Users.DTO;
using cafe.Domain.Users.Repository;
using cafe.Domain.Users.Service;

namespace cafe.Application.Features.User.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<BaseResponse<bool>> CreateUser(RegistrationDTO registration)
        {
            var result = await _userRepository.CreateUser(registration);
            if (!result.IsOk)
            {
                return new BaseResponse<bool>() { message = result.Error.Message, statusCode = 400 };
            }
            else
            {
                return new BaseResponse<bool>() { message = result.Value, statusCode = 200, success = true, data = true };
            }
        }

        public async Task<BaseResponse<TokenDTO>> Login(LoginDTO login)
        {
            var result = await _userRepository.Login(login);
            if (!result.IsOk)
            {
                return new BaseResponse<TokenDTO>() { message = result.Error.Message, statusCode = 400 };
            }
            return new BaseResponse<TokenDTO>() { message = "success", statusCode = 200, data = result.Value };
        }

        public async Task<BaseResponse<TokenDTO>> RefreshToken(TokenDTO dto)
        {
            var result = await _userRepository.RefreshToken(dto);
            if (!result.IsOk)
            {
                return new BaseResponse<TokenDTO>() { message = result.Error.Message, statusCode = 400 };
            }
            return new BaseResponse<TokenDTO>() { message = "success", statusCode = 200, data = result.Value };
        }
    }
}

