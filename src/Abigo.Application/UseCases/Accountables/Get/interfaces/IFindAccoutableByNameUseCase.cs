using Abigo.Communication.Responses.Accountable;

namespace Abigo.Application.UseCases.Accountables.Get.interfaces
{
    public interface IFindAccoutableByNameUseCase
    {
        Task<AccountableDetailedResponse> Execute(string name);
    }
}
