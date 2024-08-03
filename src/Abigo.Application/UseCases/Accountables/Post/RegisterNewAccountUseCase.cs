using Abigo.Application.UseCases.Accountables.Post.Interfaces;
using Abigo.Communication.Requests;
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
  
        public async Task Execute(AccountableRequestJson request)
        {

            try
            {
                var newEntity = _mapper.Map<AccountableEntity>(request);

                await _repository.CreateNewAccount(newEntity);
            } catch (Exception ex)
            {
                throw new Exception("Error on create user");
            }
        }

    }
}
