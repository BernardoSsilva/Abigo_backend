using Abigo.Application.UseCases.Accountables.Get.interfaces;
using Abigo.Communication.Responses.Accountable;
using Abigo.Domain.Repositories;
using AutoMapper;

namespace Abigo.Application.UseCases.Accountables.Get
{
    public class FindAccoutableByNameUseCase : IFindAccoutableByNameUseCase
    {
        private readonly IAccountablesRepository _repository;
        private readonly IMapper _mapper;


        public FindAccoutableByNameUseCase(IAccountablesRepository repository, IMapper mapper)
        {

            _mapper = mapper;
            _repository = repository;
        }
        public async Task<AccountableDetailedResponse> Execute(string name)
        {
            var result = await _repository.FindAllAccountables();



            return _mapper.Map<AccountableDetailedResponse>(result.FirstOrDefault(accoutable => accoutable.Name == name));
        }
    }
}
