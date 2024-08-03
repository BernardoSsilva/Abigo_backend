using Abigo.Application.UseCases.AvailableLocales.Put.Interfaces;
using Abigo.Communication.Requests;
using Abigo.Domain.Entities;
using Abigo.Domain.Models;
using Abigo.Domain.Repositories;
using Abigo.JWTAdmin;
using AutoMapper;

namespace Abigo.Application.UseCases.AvailableLocales.Put
{
    public class UpdateAvailableLocaleUseCase : IUpdateAvailableLocaleUseCase
    {
        private readonly IAvailableLocalesRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateAvailableLocaleUseCase(IAvailableLocalesRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {

            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task Execute(string localeId, string token, AvailableLocalesRequestJson request)
        {
            var tokenAdmin = new AdminToken();

            var tokenIsAvailable = tokenAdmin.ValidateToken(token);

            if (!tokenIsAvailable)
            {
                throw new UnauthorizedAccessException("unhautorized");
            }

            var localeToUpdate = await _repository.SearchDisponibleLocale(localeId);
        
            if(localeToUpdate is null)
            {
                throw new ArgumentException("not found");
            }

            var decodedToken = tokenAdmin.DecodeToken(token);
            if (localeToUpdate.AccountId != decodedToken.AccountId)
            {
                throw new UnauthorizedAccessException("unauthorized");
            }



            localeToUpdate = _mapper.Map(request, localeToUpdate);

            _repository.EditLocale(localeToUpdate);
            await _unitOfWork.Commit();


        }
    }
}
