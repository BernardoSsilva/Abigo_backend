using Abigo.Application.UseCases.AvailableLocales.get.Interfaces;
using Abigo.Communication.Responses.AvailableLocales;
using Abigo.Communication.Responses.DisponibleLocales;
using Abigo.Domain.Enums;
using Abigo.Domain.Repositories;
using AutoMapper;

namespace Abigo.Application.UseCases.AvailableLocales.get
{
    internal class IFIndAllLocalesByCategoryUseCase : IFindAllLocalesByCategoryUseCase
    {

        private readonly IAvailableLocalesRepository _repository;
        private readonly IMapper _mapper;

        public IFIndAllLocalesByCategoryUseCase(IAvailableLocalesRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<MultipleLocalesResponseJson> Execute(LocalesCategories category)
        {
            var response = await _repository.FindLocalesByCategory(category);

            return new MultipleLocalesResponseJson
            {
                Locales = _mapper.Map<List<AvailableLocalesShortResponseJson>>(response)
            };
        }
    }
}
