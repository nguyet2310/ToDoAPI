using Microsoft.AspNetCore.Identity;
using ToDoAPI.Authentication;
using ToDoAPI.Models;

namespace ToDoAPI.Repositories
{
    public interface IAccountRepository
    {
        public Task<Response> RegisterAsync(RegisterModel model);
        public Task<string> LoginAsync(LoginModel model);
        //public Task<IdentityResult> RegisterAsync(RegisterModel model);
    }
}
