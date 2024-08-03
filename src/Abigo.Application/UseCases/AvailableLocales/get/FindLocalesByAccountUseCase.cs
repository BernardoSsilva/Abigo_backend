using Abigo.Application.UseCases.AvailableLocales.get.Interfaces;
using Abigo.Communication.Responses.AvailableLocales;
using Abigo.Communication.Responses.DisponibleLocales;
using Abigo.Domain.Repositories;
using AutoMapper;

namespace Abigo.Application.UseCases.AvailableLocales.get
{
    public class FindLocalesByAccountUseCase : IFindLocalesByAccountUseCase
    {
        private readonly IAvailableLocalesRepository _repository;
        private readonly IMapper _mapper;

        public FindLocalesByAccountUseCase(IAvailableLocalesRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<MultipleLocalesResponseJson> Execute(string accountId)
        {
            var response = await _repository.SearchAvailableLocalesByAccount(accountId);

            return new MultipleLocalesResponseJson
            {
                Locales = _mapper.Map<List<AvailableLocalesShortResponseJson>>(response)
            };
        }
    }
}
