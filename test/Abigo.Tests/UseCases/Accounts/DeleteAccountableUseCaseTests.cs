using Abigo.Application.UseCases.Accountables.Delete;
using Abigo.Domain.Entities;
using Abigo.JWTAdmin;
using Abigo.Tests.Helppers;
using AutoMapper;
using Xunit;

public class DeleteAccountableUseCaseTests
{
    private readonly List<AccountableEntity> _accountables;
    private readonly InMemoryAccountablesRepository _repository;
    private readonly InMemoryUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly DeleteAccountableUseCase _useCase;

    public DeleteAccountableUseCaseTests()
    {
        _accountables = new List<AccountableEntity>
        {
            new AccountableEntity { Id = Guid.NewGuid().ToString(), Name = "John Doe" },
            new AccountableEntity { Id =  Guid.NewGuid().ToString(), Name = "Jane Doe" }
        };

        _repository = new InMemoryAccountablesRepository(_accountables);
        _unitOfWork = new InMemoryUnitOfWork();

        var config = new MapperConfiguration(cfg => { /* Add your mappings here */ });
        _mapper = config.CreateMapper();

        _useCase = new DeleteAccountableUseCase(_repository, _unitOfWork, _mapper);
    }

    [Fact]
    public async Task Execute_ShouldDeleteAccountable_WhenAccountableExists()
    {
        // Arrange
        var token = "validToken"; // replace with a valid token
        var tokenAdmin = new AdminToken();
        var decodedToken = tokenAdmin.DecodeToken(token);
        decodedToken.AccountId = 1;

        // Act
        var result = await _useCase.Execute(token);

        // Assert
        Assert.True(result);
        Assert.Null(await _repository.SearchAccountable(1));
    }

    [Fact]
    public async Task Execute_ShouldThrowException_WhenAccountableDoesNotExist()
    {
        // Arrange
        var token = "invalidToken"; // replace with an invalid token
        var tokenAdmin = new AdminToken();
        var decodedToken = tokenAdmin.DecodeToken(token);
        decodedToken.AccountId = Guid.NewGuid().ToString(),;

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentException>(() => _useCase.Execute(token));
    }
}
