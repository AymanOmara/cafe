using cafe.Domain.Common;
using cafe.Domain.Users.DTO;
using cafe.Domain.Users.Service;

namespace cafe.Application.Features.User.Service
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork userRepository)
        {
            _unitOfWork = userRepository;
        }

        public async Task<BaseResponse<bool>> CreateUser(RegistrationDTO registration)
        {
            var result = await _unitOfWork.Users.CreateUser(registration);
            if (!result.IsOk)
            {
                return new BaseResponse<bool>() { message = result.Error.Message, statusCode = 400 };
            }
            else
            {
                return new BaseResponse<bool>() { message = result.Value, statusCode = 200, success = true, data = true };
            }
        }

        //todo
        public Task<BaseResponse<string>> DeleteUSer(string userName)
        {
            throw new NotImplementedException();
        }

        //todo
        public Task<BaseResponse<string>> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse<TokenDTO>> Login(LoginDTO login)
        {
            var result = await _unitOfWork.Users.Login(login);
            if (!result.IsOk)
            {
                return new BaseResponse<TokenDTO>() { message = result.Error.Message, statusCode = 400 };
            }
            return new BaseResponse<TokenDTO>() { message = "success", statusCode = 200, data = result.Value };
        }

        public async Task<BaseResponse<TokenDTO>> RefreshToken(TokenDTO dto)
        {
            var result = await _unitOfWork.Users.RefreshToken(dto);
            if (!result.IsOk)
            {
                return new BaseResponse<TokenDTO>() { message = result.Error.Message, statusCode = 400 };
            }
            return new BaseResponse<TokenDTO>() { message = "success", statusCode = 200, data = result.Value };
        }
    }
}

