using Abigo.Application.UseCases.Accountables.Get;
using Abigo.Communication.Responses.Accountable;
using Abigo.Domain.Entities;
using Abigo.Tests.Helppers;
using AutoMapper;
using Xunit;

public class FindAccoutableByNameUseCaseTests
{
    private readonly List<AccountableEntity> _accountables;
    private readonly InMemoryAccountablesRepository _repository;
    private readonly IMapper _mapper;
    private readonly FindAccoutableByNameUseCase _useCase;

    public FindAccoutableByNameUseCaseTests()
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

        _useCase = new FindAccoutableByNameUseCase(_repository, _mapper);
    }

    [Fact]
    public async Task Execute_ShouldReturnAccountable_WhenAccountableExists()
    {
        // Arrange
        var name = "John Doe";

        // Act
        var result = await _useCase.Execute(name);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("John Doe", result.Name);
    }

    [Fact]
    public async Task Execute_ShouldReturnNull_WhenAccountableDoesNotExist()
    {
        // Arrange
        var name = "Nonexistent Name";

        // Act
        var result = await _useCase.Execute(name);

        // Assert
        Assert.Null(result);
    }
}
