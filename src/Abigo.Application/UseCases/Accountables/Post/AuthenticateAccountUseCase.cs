using Abigo.Application.UseCases.Accountables.Post.Interfaces;
using Abigo.Communication.Requests;
using Abigo.Domain.Repositories;
using Abigo.JWTAdmin;
using AutoMapper;
using MD5Hash;
namespace Abigo.Application.UseCases.Accountables.Post
{
    internal class AuthenticateAccountUseCase : IAuthenticateAccountUseCase
    {
        private readonly IAccountablesRepository _repository;
        private readonly IMapper _mapper;

        public AuthenticateAccountUseCase(IAccountablesRepository repository, IMapper mapper)
        {

            _repository = repository;
            _mapper = mapper;
        }
        public async Task<string> Execute(AuthenticateAccountRequestJson request)
        {
            var tokenAdmin = new AdminToken();

            var allUsers = await _repository.FindAllAccountables();

            var userToLogin =  allUsers.FirstOrDefault(user => user.ConnectionEmail == request.ConnectionEmail);

            if(userToLogin is null)
            {
                throw new UnauthorizedAccessException("Unauthorized");
            }
            if (userToLogin.AccessPassword != request.AccessPassword.ToString().GetMD5())
            {
                throw new  UnauthorizedAccessException("Unauthorized");
            }

            var tokenPayload = new TokenPayload
            {
                AccountConnectionEmail = request.ConnectionEmail,
                AccountId = userToLogin.Id,
                AccountName = userToLogin.Name,
            };
            var token = tokenAdmin.Generate(tokenPayload);

            return token.ToString();


        }
    }
}
