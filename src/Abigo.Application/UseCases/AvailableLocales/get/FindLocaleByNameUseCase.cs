using Abigo.Application.UseCases.AvailableLocales.get.Interfaces;
using Abigo.Communication.Responses.AvailableLocales;
using Abigo.Domain.Repositories;
using AutoMapper;

namespace Abigo.Application.UseCases.AvailableLocales.get
{
    public class FindLocaleByNameUseCase:IFindLocaleByNameUseCase
    {
        private readonly IAvailableLocalesRepository _repository;
        private readonly IMapper _mapper;

        public FindLocaleByNameUseCase(IAvailableLocalesRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<AvailableLocalesDetailedResponseJson> Execute(string name)
        {

            var response = await _repository.SearchAvailableLocaleByName(name);

            return _mapper.Map<AvailableLocalesDetailedResponseJson>(response);
        }
    }
}
