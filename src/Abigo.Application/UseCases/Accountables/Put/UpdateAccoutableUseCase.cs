﻿using Abigo.Application.UseCases.Accountables.Put.Interfaces;
using Abigo.Communication.Requests;
using Abigo.Domain.Entities;
using Abigo.Domain.Models;
using Abigo.Domain.Repositories;
using Abigo.JWTAdmin;
using AutoMapper;

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
        public async Task Execute(AccountableRequestJson request, string id, string token)
        {
            var tokenAdmin = new AdminToken();

            var decodedToken = tokenAdmin.DecodeToken(token);
            if (decodedToken.AccountId != id)
            {
                throw new UnauthorizedAccessException("Unauthorized");
            }

            var accountToUpdate = await _repository.SearchAccountable(id);

         
            if(accountToUpdate is null)
            {
                throw new ArgumentException("not found");
            }
            var newAccoutableData = _mapper.Map<AccountableEntity>(request);
            accountToUpdate = _mapper.Map(accountToUpdate, newAccoutableData);

            await _repository.UpdateAccountable(accountToUpdate);
            await _unitOfWork.Commit();
            return;
        }
    }
}
