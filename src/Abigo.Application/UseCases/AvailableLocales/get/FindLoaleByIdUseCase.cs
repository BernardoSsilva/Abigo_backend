using Abigo.Application.UseCases.AvailableLocales.get.Interfaces;
using Abigo.Communication.Responses.AvailableLocales;
using Abigo.Domain.Repositories;
using AutoMapper;

namespace Abigo.Application.UseCases.AvailableLocales.get
{
    internal class FindLoaleByIdUseCase : IFindLocaleByNameUseCase
    {
        private readonly IAvailableLocalesRepository _repository;
        private readonly IMapper _mapper;

        public FindLoaleByIdUseCase(IAvailableLocalesRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<AvailableLocalesDetailedResponseJson> Execute(string id)
        {

            var response = await _repository.SearchDisponibleLocale(id);

            return _mapper.Map<AvailableLocalesDetailedResponseJson>(response);
        }
    }
}
