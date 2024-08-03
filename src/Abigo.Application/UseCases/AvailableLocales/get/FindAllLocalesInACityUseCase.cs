using Abigo.Application.UseCases.AvailableLocales.get.Interfaces;
using Abigo.Communication.Responses.AvailableLocales;
using Abigo.Communication.Responses.DisponibleLocales;
using Abigo.Domain.Repositories;
using AutoMapper;

namespace Abigo.Application.UseCases.AvailableLocales.get
{
    public class FindAllLocalesInACityUseCase : IFindAllLocalesInACityUseCase
    {
        private readonly IAvailableLocalesRepository _repository;
        private readonly IMapper _mapper;

        public FindAllLocalesInACityUseCase(IAvailableLocalesRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<MultipleLocalesResponseJson> Exectue(string cityName)
        {
            var response = await _repository.SearchAvailableLocaleByCity(cityName);

            return new MultipleLocalesResponseJson
            {
                Locales = _mapper.Map<List<AvailableLocalesShortResponseJson>>(response)
            };
        }
    }
}
