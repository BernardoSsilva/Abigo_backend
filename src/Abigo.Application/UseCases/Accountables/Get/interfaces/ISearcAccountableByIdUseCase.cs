using Abigo.Communication.Responses.Accountable;

namespace Abigo.Application.UseCases.Accountables.Get.interfaces
{
    public interface ISearcAccountableByIdUseCase
    {
        Task<AccountableDetailedResponse> Execute(string id);
    }
}
