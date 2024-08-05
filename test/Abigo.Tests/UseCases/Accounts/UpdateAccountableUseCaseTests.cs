using Abigo.Application.UseCases.Accountables.Put.Interfaces;
using Abigo.Communication.Requests;
using Abigo.Communication.Responses.Accountable;
using Abigo.Domain.Entities;
using Abigo.Domain.Models;
using Abigo.Domain.Repositories;
using AutoMapper;
using Xunit;

public class UpdateAccountableUseCaseTests
{
    private readonly List<AccountableEntity> _accountables;
    private readonly InMemoryAccountablesRepository _repository;
    private readonly InMemoryUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IUpdateAccountableUseCase _useCase;

    public UpdateAccountableUseCaseTests()
    {
        _accountables = new List<AccountableEntity>
        {
            new AccountableEntity { Id = "1", Name = "John Doe", ConnectionEmail = "john@example.com", AccessPassword = "password123".GetMD5() },
            new AccountableEntity { Id = "2", Name = "Jane Doe", ConnectionEmail = "jane@example.com", AccessPassword = "password123".GetMD5() }
        };

        _repository = new InMemoryAccountablesRepository(_accountables);
        _unitOfWork = new InMemoryUnitOfWork();

        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<AccountableRequestJson, AccountableEntity>();
            cfg.CreateMap<AccountableEntity, AccountableDetailedResponse>();
        });
        _mapper = config.CreateMapper();

        _useCase = new IUpdateAccountableUseCase(_repository, _unitOfWork, _mapper);
    }

    [Fact]
    public async Task Execute_ShouldUpdateAccountable_WhenAccountableExists()
    {
        // Arrange
        var token = "valid-token";
        var request = new AccountableRequestJson
        {
            Name = "John Updated",
            ConnectionEmail = "johnupdated@example.com",
            AccessPassword = "newpassword123"
        };

       

        // Act
        var result = await _useCase.Execute(request, token);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("John Updated", result.Name);
        Assert.Equal("johnupdated@example.com", result.ConnectionEmail);
    }

    [Fact]
    public async Task Execute_ShouldThrowException_WhenAccountableDoesNotExist()
    {
        // Arrange
        var token = "valid-token";
        var request = new AccountableRequestJson
        {
            Name = "Nonexistent User",
            ConnectionEmail = "nonexistent@example.com",
            AccessPassword = "password123"
        };

        // Mock token decoding
        var adminToken = new AdminToken();
        adminToken.DecodeToken = _ => new TokenPayload { AccountId = "99" };

        // Act & Assert
        var exception = await Assert.ThrowsAsync<ArgumentException>(() => _useCase.Execute(request, token));
        Assert.Equal("not found", exception.Message);
    }
}





