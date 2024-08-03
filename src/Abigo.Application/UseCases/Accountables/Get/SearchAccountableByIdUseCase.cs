using Abigo.Application.UseCases.Accountables.Get.interfaces;
using Abigo.Communication.Responses.Accountable;
using Abigo.Domain.Repositories;
using AutoMapper;

namespace Abigo.Application.UseCases.Accountables.Get
{
    public class SearchAccountableByIdUseCase : ISearchAccountableByIdUseCase
    {
        private readonly IAccountablesRepository _repository;
        private readonly IMapper _mapper;


        public SearchAccountableByIdUseCase(IAccountablesRepository repository, IMapper mapper)
        {

            _mapper = mapper;
            _repository = repository;
        }
        public async Task<AccountableDetailedResponse> Execute(string id)
        {
            var result = await _repository.SearchAccountable(id);

            return _mapper.Map<AccountableDetailedResponse>(result);
        }
    }
}
