using System.Collections.Generic;
using System.Threading.Tasks;
using Abigo.Application.UseCases.Accountables.Get;
using Abigo.Communication.Responses.Accountable;
using Abigo.Domain.Entities;
using Abigo.Domain.Repositories;
using Abigo.Tests.Helppers;
using AutoMapper;
using Xunit;

public class SearchAccountableByIdUseCaseTests
{
    private readonly List<AccountableEntity> _accountables;
    private readonly InMemoryAccountablesRepository _repository;
    private readonly IMapper _mapper;
    private readonly SearchAccountableByIdUseCase _useCase;

    public SearchAccountableByIdUseCaseTests()
    {
        _accountables = new List<AccountableEntity>
        {
            new AccountableEntity { Id = "1", Name = "John Doe" },
            new AccountableEntity { Id = "2", Name = "Jane Doe" }
        };

        _repository = new InMemoryAccountablesRepository(_accountables);

        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<AccountableEntity, AccountableDetailedResponse>();
        });
        _mapper = config.CreateMapper();

        _useCase = new SearchAccountableByIdUseCase(_repository, _mapper);
    }

    [Fact]
    public async Task Execute_ShouldReturnAccountable_WhenAccountableExists()
    {
        // Arrange
        var id = "1";

        // Act
        var result = await _useCase.Execute(id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("John Doe", result.Name);
    }

    [Fact]
    public async Task Execute_ShouldReturnNull_WhenAccountableDoesNotExist()
    {
        // Arrange
        var id = "99";

        // Act
        var result = await _useCase.Execute(id);

        // Assert
        Assert.Null(result);
    }
}
