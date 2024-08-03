using Abigo.Communication.Responses.DisponibleLocales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abigo.Application.UseCases.AvailableLocales.get.Interfaces
{
    public interface IFindAllLocalesInACityUseCase
    {
        Task<MultipleLocalesResponseJson> Exectue(string cityName);
    }
}
