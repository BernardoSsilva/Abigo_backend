using Abigo.Application.UseCases.Accountables.Get.interfaces;
using Abigo.Communication.Responses.Accountable;
using Abigo.Domain.Repositories;
using AutoMapper;

namespace Abigo.Application.UseCases.Accountables.Get
{

    public class ListAllAccoutablesUseCase : IListAllAccountablesUseCase
    {

        private readonly IAccountablesRepository _repository;
        private readonly IMapper _mapper;


    public ListAllAccoutablesUseCase(IAccountablesRepository repository, IMapper mapper)
    {
            
            _mapper = mapper;
            _repository = repository;
    }
    public async Task<MultiplleAccountablesResponseJson> Execute()
        {
            var requestResult = await _repository.FindAllAccountables();

            return new MultiplleAccountablesResponseJson
            {
                accounts = _mapper.Map<List<AccountableShortResponseJson>>(requestResult)
            };
        }
    
    }
}
