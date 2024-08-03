using Abigo.Application.UseCases.AvailableLocales.Post.Interfaces;
using Abigo.Communication.Requests;
using Abigo.Communication.Responses.AvailableLocales;
using Abigo.Domain.Entities;
using Abigo.Domain.Models;
using Abigo.Domain.Repositories;
using Abigo.JWTAdmin;
using AutoMapper;

namespace Abigo.Application.UseCases.AvailableLocales.Post
{
    public class RegisterNewAvailableLocale : IRegisterNewAvailableLocale
    {
        private readonly IAvailableLocalesRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RegisterNewAvailableLocale(IAvailableLocalesRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<AvailableLocalesShortResponseJson> Execute(AvailableLocalesRequestJson request, string token)
        {
            var tokenAdmin = new AdminToken();

            var tokenIsAvailable = tokenAdmin.ValidateToken(token);

            if (!tokenIsAvailable)
            {
                throw new UnauthorizedAccessException("unhautorized ");
            }

            var newLocale = _mapper.Map<AvailableLocalesEntity>(request);
            newLocale.AccountId = tokenAdmin.DecodeToken(token).AccountId;

            await _repository.CreateNewDisponibleLocale(_mapper.Map<AvailableLocalesEntity>(request));
            var response = new AvailableLocalesShortResponseJson
            {
                AccountId = newLocale.AccountId,
                Category = newLocale.Category,
                City = newLocale.City,
                DonationKey = newLocale.DonationKey,
                Id = newLocale.Id,
                IsActive = newLocale.IsActive,
                NeighboorHood = newLocale.NeighboorHood,
                VacanciesNumber = newLocale.VacanciesNumber,
                contactPhone = newLocale.contactPhone,

            };

            await _unitOfWork.Commit();

            return response;
        }
    }
}
