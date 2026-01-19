using Core.Entities.Abstract;

namespace Entities.DTOs.Auth
{
    public class LoginDto : IDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
