using Abigo.Communication.Responses.Accountable;

namespace Abigo.Application.UseCases.Accountables.Get.interfaces
{
    public interface IListAllAccountablesUseCase
    {
        Task<MultiplleAccountablesResponseJson> Execute();
    }
}
