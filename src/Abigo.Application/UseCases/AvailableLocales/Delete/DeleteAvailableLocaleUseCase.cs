using Abigo.Application.UseCases.AvailableLocales.Delete.Interfaces;
using Abigo.Domain.Models;
using Abigo.Domain.Repositories;
using Abigo.JWTAdmin;
using AutoMapper;

namespace Abigo.Application.UseCases.AvailableLocales.Delete
{
    public class DeleteAvailableLocaleUseCase : IDeleteAvailableLocaleUseCase
    {
        private readonly IAvailableLocalesRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteAvailableLocaleUseCase(IAvailableLocalesRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {

            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task Execute(string localeId, string token)
        {
            var tokenAdmin = new AdminToken();

            var tokenIsAvailable = tokenAdmin.ValidateToken(token);

            if (!tokenIsAvailable)
            {
                throw new UnauthorizedAccessException("unhautorized");
            }

            var localeToDelete = await _repository.SearchDisponibleLocale(localeId);

            if(localeToDelete is null)
            {
                throw new ArgumentException("not found")
            }

            var decodedToken = tokenAdmin.DecodeToken(token);
            if(localeToDelete.AccountId != decodedToken.AccountId)
            {
                throw new UnauthorizedAccessException("unhautorized");
            }

            await _repository.DeleteLocale(localeId);
            await _unitOfWork.Commit();
        }
    }
}
