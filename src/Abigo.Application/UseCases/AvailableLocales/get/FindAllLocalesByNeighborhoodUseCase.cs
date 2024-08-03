using Abigo.Application.UseCases.AvailableLocales.get.Interfaces;
using Abigo.Communication.Responses.AvailableLocales;
using Abigo.Communication.Responses.DisponibleLocales;
using Abigo.Domain.Repositories;
using AutoMapper;

namespace Abigo.Application.UseCases.AvailableLocales.get
{
    public class FindAllLocalesByNeighborhoodUseCase : IFindAllLocalesByNeighborhoodUseCase
    {
        private readonly IAvailableLocalesRepository _repository;
        private readonly IMapper _mapper;

        public FindAllLocalesByNeighborhoodUseCase(IAvailableLocalesRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<MultipleLocalesResponseJson> Execute(string neighborhoodName)
        {
            var allAvailablesLocales = await _repository.SearchAvailableLocalesByNeighborHood(neighborhoodName);

            return new MultipleLocalesResponseJson
                {
                    Locales = _mapper.Map<List<AvailableLocalesShortResponseJson>>(allAvailablesLocales)
                };
        }
    }
}
