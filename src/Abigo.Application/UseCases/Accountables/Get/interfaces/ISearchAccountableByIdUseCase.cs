using Abigo.Communication.Responses.Accountable;

namespace Abigo.Application.UseCases.Accountables.Get.interfaces
{
    public interface ISearchAccountableByIdUseCase
    {
        Task<AccountableDetailedResponse> Execute(string id);
    }
}
