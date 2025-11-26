using Loan_API.DTO;
using Loan_API.Models;

namespace Loan_API.Services.Interface
{
    public interface IUserService
    {
        User Registration(UserDto userDto);
        User GetUserById(int id);

        void BlockUser(int id);
    }
}
