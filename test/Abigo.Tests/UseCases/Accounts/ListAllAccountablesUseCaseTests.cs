using Abigo.Application.UseCases.Accountables.Get;
using Abigo.Communication.Responses.Accountable;
using Abigo.Domain.Entities;
using Abigo.Tests.Helppers;
using AutoMapper;
using Xunit;

public class ListAllAccountablesUseCaseTests
{
    private readonly List<AccountableEntity> _accountables;
    private readonly InMemoryAccountablesRepository _repository;
    private readonly IMapper _mapper;
    private readonly ListAllAccoutablesUseCase _useCase;

    public ListAllAccountablesUseCaseTests()
    {
        _accountables = new List<AccountableEntity>
        {
            new AccountableEntity { Id = "1", Name = "John Doe" },
            new AccountableEntity { Id = "2", Name = "Jane Doe" }
        };

        _repository = new InMemoryAccountablesRepository(_accountables);

        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<AccountableEntity, AccountableShortResponseJson>();
        });
        _mapper = config.CreateMapper();

        _useCase = new ListAllAccoutablesUseCase(_repository, _mapper);
    }

    [Fact]
    public async Task Execute_ShouldReturnAllAccountables_WhenAccountablesExist()
    {
        // Act
        var result = await _useCase.Execute();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.accounts.Count);
        Assert.Contains(result.accounts, acc => acc.Name == "John Doe");
        Assert.Contains(result.accounts, acc => acc.Name == "Jane Doe");
    }

    [Fact]
    public async Task Execute_ShouldReturnEmptyList_WhenNoAccountablesExist()
    {
        // Arrange
        _accountables.Clear();

        // Act
        var result = await _useCase.Execute();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result.accounts);
    }
}
