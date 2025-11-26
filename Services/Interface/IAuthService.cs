using Loan_API.DTO;

namespace Loan_API.Services.Interface
{
    public interface IAuthService
    {
        string Login(UserLoginDto userLoginDto);

    }
}
