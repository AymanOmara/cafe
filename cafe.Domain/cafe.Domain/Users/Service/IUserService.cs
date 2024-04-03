using cafe.Domain.Common;
using cafe.Domain.Users.DTO;

namespace cafe.Domain.Users.Service
{
	public interface IUserService
	{
        Task<BaseResponse<bool>> CreateUser(RegistrationDTO registration);

        Task<BaseResponse<TokenDTO>> Login(LoginDTO login);

        Task<BaseResponse<TokenDTO>> RefreshToken(TokenDTO dto);
        
        Task<BaseResponse<ICollection<UserDTO>>> GetAllUsers();

        Task<BaseResponse<bool>> DeleteUser(string userId);
    }
}

