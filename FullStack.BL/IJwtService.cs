using FullStack.Domain;

namespace FullStack.BL
{
    public interface IJwtService
    {
        string GetJwtToken(UserAccount userAccount);
    }
}
