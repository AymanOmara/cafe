using cafe.Common;
using cafe.Domain.Common;
using cafe.Domain.Users.DTO;
using cafe.Domain.Users.Service;

namespace cafe.Application.Features.User.Service
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly LanguageService _localization;

        public UserService(IUnitOfWork userRepository, LanguageService localization)
        {
            _unitOfWork = userRepository;
            _localization = localization;
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

        public async Task<BaseResponse<bool>> DeleteUser(string userId)
        {
            var reuslt = await _unitOfWork.Users.DeleteUser(userId);
            if (!reuslt.IsOk) {
                return new BaseResponse<bool> { data = false,statusCode = 400,message = _localization.Getkey("error_try_later").Value};
            }
            return new BaseResponse<bool> { statusCode = 200,message = _localization.Getkey("success").Value,data =true};
        }

        public async Task<BaseResponse<ICollection<UserDTO>>> GetAllUsers()
        {
            var result = await _unitOfWork.Users.GetAllUsers();
            return new BaseResponse<ICollection<UserDTO>> { data = result , statusCode = 200, success = true };
        }

        public async Task<BaseResponse<TokenDTO>> Login(LoginDTO login)
        {
            var result = await _unitOfWork.Users.Login(login);
            if (!result.IsOk)
            {
                return new BaseResponse<TokenDTO>() { message = result.Error.Message, statusCode = 400 };
            }
            return new BaseResponse<TokenDTO>() { message = _localization.Getkey("success").Value, statusCode = 200, data = result.Value };
        }

        public async Task<BaseResponse<TokenDTO>> RefreshToken(TokenDTO dto)
        {
            var result = await _unitOfWork.Users.RefreshToken(dto);
            if (!result.IsOk)
            {
                return new BaseResponse<TokenDTO>() { message = result.Error.Message, statusCode = 400 };
            }
            return new BaseResponse<TokenDTO>() { message = _localization.Getkey("success").Value, statusCode = 200, data = result.Value };
        }
    }
}

