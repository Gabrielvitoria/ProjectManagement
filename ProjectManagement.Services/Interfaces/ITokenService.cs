namespace ProjectManagement.Services.Interfaces
{
    public interface ITokenService
    {
        Tuple<string, string> GenerateToken(string username, string password);
    }
}
