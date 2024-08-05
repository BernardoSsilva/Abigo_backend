using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abigo.Application.UseCases.Accountables.Post;
using Abigo.Application.UseCases.Accountables.Post.Interfaces;
using Abigo.Communication.Requests;
using Abigo.Communication.Responses.Accountable;
using Abigo.Domain.Entities;
using Abigo.Domain.Models;
using Abigo.Domain.Repositories;
using AutoMapper;
using MD5Hash;
using Xunit;

public class RegisterNewAccountUseCaseTests
{
    private readonly List<AccountableEntity> _accountables;
    private readonly InMemoryAccountablesRepository _repository;
    private readonly InMemoryUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly RegisterNewAccountUseCase _useCase;

    public RegisterNewAccountUseCaseTests()
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
            cfg.CreateMap<AccountableEntity, AccountableShortResponseJson>();
        });
        _mapper = config.CreateMapper();

        _useCase = new RegisterNewAccountUseCase(_repository, _unitOfWork, _mapper);
    }

    [Fact]
    public async Task Execute_ShouldRegisterNewAccount_WhenAccountDoesNotExist()
    {
        // Arrange
        var request = new AccountableRequestJson
        {
            Name = "New User",
            ConnectionEmail = "newuser@example.com",
            AccessPassword = "newpassword123"
        };

        // Act
        var result = await _useCase.Execute(request);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("New User", result.Name);
        Assert.Equal("newuser@example.com", result.ConnectionEmail);
        Assert.NotNull(_accountables.FirstOrDefault(a => a.ConnectionEmail == "newuser@example.com"));
    }

    [Fact]
    public async Task Execute_ShouldThrowException_WhenAccountAlreadyExists()
    {
        // Arrange
        var request = new AccountableRequestJson
        {
            Name = "John Doe",
            ConnectionEmail = "john@example.com",
            AccessPassword = "password123"
        };

        // Act & Assert
        var exception = await Assert.ThrowsAsync<ArgumentException>(() => _useCase.Execute(request));
        Assert.Equal("Conflict", exception.Message);
    }

    [Fact]
    public async Task Execute_ShouldThrowException_WhenCreationFails()
    {
        // Arrange
        var faultyRepository = new InMemoryAccountablesRepository(_accountables)
        {
            ShouldFailOnCreate = true
        };

        var faultyUseCase = new RegisterNewAccountUseCase(faultyRepository, _unitOfWork, _mapper);

        var request = new AccountableRequestJson
        {
            Name = "Faulty User",
            ConnectionEmail = "faultyuser@example.com",
            AccessPassword = "password123"
        };

        // Act & Assert
        var exception = await Assert.ThrowsAsync<ArgumentException>(() => faultyUseCase.Execute(request));
        Assert.Equal("Error on create user", exception.Message);
    }
}

public class InMemoryUnitOfWork : IUnitOfWork
{
    public Task Commit()
    {
        return Task.CompletedTask;
    }
}

public class InMemoryAccountablesRepository : IAccountablesRepository
{
    private readonly List<AccountableEntity> _accountables;
    public bool ShouldFailOnCreate { get; set; } = false;

    public InMemoryAccountablesRepository(List<AccountableEntity> accountables)
    {
        _accountables = accountables ?? new List<AccountableEntity>();
    }

    public Task<bool> CreateNewAccount(AccountableEntity accountable)
    {
        if (ShouldFailOnCreate)
        {
            return Task.FromResult(false);
        }

        _accountables.Add(accountable);
        return Task.FromResult(true);
    }

    public Task<bool> DeleteAccountable(string accountableId)
    {
        var entityToDelete = _accountables.FirstOrDefault(a => a.Id == accountableId);
        if (entityToDelete != null)
        {
            _accountables.Remove(entityToDelete);
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }

    public Task<List<AccountableEntity>> FindAllAccountables()
    {
        return Task.FromResult(_accountables.ToList());
    }

    public Task<AccountableEntity?> SearchAccountable(string id)
    {
        var entity = _accountables.FirstOrDefault(a => a.Id == id);
        return Task.FromResult(entity);
    }

    public void UpdateAccountable(AccountableEntity accountable)
    {
        var entityToUpdate = _accountables.FirstOrDefault(a => a.Id == accountable.Id);
        if (entityToUpdate != null)
        {
            entityToUpdate.Name = accountable.Name;
            entityToUpdate.ConnectionEmail = accountable.ConnectionEmail;
            entityToUpdate.AccessPassword = accountable.AccessPassword;
        }
    }
}
