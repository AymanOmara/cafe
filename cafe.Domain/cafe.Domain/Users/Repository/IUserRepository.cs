using cafe.Domain.Common;
using cafe.Domain.Users.DTO;

namespace cafe.Domain.Users.Repository
{
	public interface IUserRepository
	{
        Task<Result<string, Exception>> CreateUser(RegistrationDTO registration);


		Task<Result<TokenDTO, Exception>> Login(LoginDTO login);


        Task<Result<TokenDTO, Exception>> RefreshToken(TokenDTO token);

        Task<ICollection<UserDTO>> GetAllUsers();

        Task<Result<bool, Exception>> DeleteUser(string userId);

    }
}

