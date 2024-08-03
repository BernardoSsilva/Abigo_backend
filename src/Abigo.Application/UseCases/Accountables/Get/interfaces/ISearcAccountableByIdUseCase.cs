using Abigo.Communication.Responses.Accountable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abigo.Application.UseCases.Accountables.Get.interfaces
{
    public interface ISearcAccountableByIdUseCase
    {
        Task<AccountableDetailedResponse> Execute(string id);
    }
}
