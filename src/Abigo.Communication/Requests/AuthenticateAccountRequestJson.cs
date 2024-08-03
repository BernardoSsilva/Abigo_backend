namespace Abigo.Communication.Requests
{
    public class AuthenticateAccountRequestJson
    {
        public string ConnectionEmail { get; set; } = string.Empty;

        public string AccessPassword { get; set; } = string.Empty;
    }
}
