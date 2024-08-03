using Abigo.Application.UseCases.Accountables.Post.Interfaces;
using Abigo.Communication.Requests;
using Abigo.Communication.Responses.Accountable;
using Abigo.Communication.Responses.AvailableLocales;
using Abigo.Domain.Entities;
using Abigo.Domain.Models;
using Abigo.Domain.Repositories;
using AutoMapper;

namespace Abigo.Application.UseCases.Accountables.Post
{
    internal class RegisterNewAccountUseCase : IRegisterNewAccountUseCase
    {
        private readonly IAccountablesRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RegisterNewAccountUseCase(IAccountablesRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {

            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
  
        public async Task<AccountableShortResponseJson> Execute(AccountableRequestJson request)
        {

           
                var newEntity = _mapper.Map<AccountableEntity>(request);

                var result = await _repository.CreateNewAccount(newEntity);

            if (!result)
            {
                throw new ArgumentException("Error on create user");
            }

            return _mapper.Map<AccountableShortResponseJson>(newEntity);
           
        }

    }
}
