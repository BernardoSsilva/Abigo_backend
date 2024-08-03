using Abigo.Application.UseCases.Accountables.Get.interfaces;
using Abigo.Communication.Responses.Accountable;
using Abigo.Domain.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
