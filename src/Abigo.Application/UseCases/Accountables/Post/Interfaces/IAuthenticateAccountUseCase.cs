using Abigo.Communication.Requests;

namespace Abigo.Application.UseCases.Accountables.Post.Interfaces
{
    public interface IAuthenticateAccountUseCase
    {
         Task<string> Execute(AuthenticateAccountRequestJson request);
    }
}
