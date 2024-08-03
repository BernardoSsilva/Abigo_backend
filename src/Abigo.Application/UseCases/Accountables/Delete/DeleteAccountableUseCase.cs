using Abigo.Application.UseCases.Accountables.Delete.interfaces;
using Abigo.Domain.Models;
using Abigo.Domain.Repositories;
using Abigo.JWTAdmin;
using AutoMapper;

namespace Abigo.Application.UseCases.Accountables.Delete
{
    public class DeleteAccountableUseCase : IDeleteAccountableUseCase
    {
        private readonly IAccountablesRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteAccountableUseCase(IAccountablesRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {

            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task Execute(string id, string token)
        {
            var tokenAdmin = new AdminToken();

            var decodedToken = tokenAdmin.DecodeToken(token);
            
            
            if (decodedToken.AccountId != id)
            {
                throw new UnauthorizedAccessException("Unauthorized");
            }

            var entityToDelete = await _repository.SearchAccountable(id);

            if(entityToDelete is null)
            {
                throw new ArgumentException("not found");
            }
            await _repository.DeleteAccountable(id);
            await _unitOfWork.Commit();
            return;

        }
    }
}
