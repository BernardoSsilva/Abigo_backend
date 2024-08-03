using Abigo.Application.UseCases.Accountables.Put.Interfaces;
using Abigo.Communication.Requests;
using Abigo.Communication.Responses.Accountable;
using Abigo.Domain.Entities;
using Abigo.Domain.Models;
using Abigo.Domain.Repositories;
using Abigo.JWTAdmin;
using AutoMapper;
using MD5Hash;

namespace Abigo.Application.UseCases.Accountables.Put
{
    public class UpdateAccoutableUseCase : IUpdateAccountableUseCase
    {
        private readonly IAccountablesRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateAccoutableUseCase(IAccountablesRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {

            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<AccountableDetailedResponse> Execute(AccountableRequestJson request,  string token)
        {
            var tokenAdmin = new AdminToken();

            var decodedToken = tokenAdmin.DecodeToken(token);
          

            var accountToUpdate = await _repository.SearchAccountable(decodedToken.AccountId);

         
            if(accountToUpdate is null)
            {
                throw new ArgumentException("not found");
            }
            accountToUpdate = _mapper.Map(request, accountToUpdate);

            accountToUpdate.AccessPassword = accountToUpdate.AccessPassword.ToString().GetMD5();
            _repository.UpdateAccountable(accountToUpdate);
            await _unitOfWork.Commit();
            return _mapper.Map<AccountableDetailedResponse>(accountToUpdate);
        }
    }
}
