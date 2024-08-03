using Abigo.Communication.Requests;

namespace Abigo.Application.UseCases.Accountables.Post.Interfaces
{
    public class IAuthenticateAccountUseCase
    {
         Task<string> Execute(AuthenticateAccountRequestJson request);
    }
}
