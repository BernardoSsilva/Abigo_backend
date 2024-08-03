using Abigo.Application.UseCases.AvailableLocales.get.Interfaces;
using Abigo.Communication.Responses.AvailableLocales;
using Abigo.Communication.Responses.DisponibleLocales;
using Abigo.Domain.Models;
using Abigo.Domain.Repositories;
using AutoMapper;

namespace Abigo.Application.UseCases.AvailableLocales.get
{
    public class FindAllAvailablesLocalesUseCase : IFIndAllAvailableLocalesUseCase
    {
        private readonly IAvailableLocalesRepository _repository;
        private readonly IMapper _mapper;

        public FindAllAvailablesLocalesUseCase(IAvailableLocalesRepository repository,  IMapper mapper)
        {

            _repository = repository;
            _mapper = mapper;
        }
        public async Task<MultipleLocalesResponseJson> Execute()
        {
            var response = await _repository.FindAllAvailableLocales();

            return new MultipleLocalesResponseJson { Locales = _mapper.Map<List<AvailableLocalesShortResponseJson>>(response) };
        }
    }
}
