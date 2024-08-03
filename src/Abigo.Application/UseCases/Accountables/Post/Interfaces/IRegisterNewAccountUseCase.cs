using Abigo.Communication.Requests;

namespace Abigo.Application.UseCases.Accountables.Post.Interfaces
{
    public interface IRegisterNewAccountUseCase
    {
        Task Execute(AccountableRequestJson request);
    }
}
