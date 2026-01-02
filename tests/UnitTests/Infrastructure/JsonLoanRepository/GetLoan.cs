using NSubstitute;
using Library.ApplicationCore;
using Library.ApplicationCore.Entities;
using Library.Infrastructure.Data;
using Microsoft.Extensions.Configuration;

namespace Library.UnitTests.Infrastructure.JsonLoanRepositoryTests;

public class GetLoanTest
{
    private readonly JsonLoanRepository _jsonLoanRepository;
    private readonly ILoanRepository _mockLoanRepository;

    public GetLoanTest()
    {
        string rootPath = @"C:\Development\AccelerateDevGitHubCopilot";
        var config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["JsonPaths:Authors"] = Path.Combine(rootPath, "src", "Library.Console", "Json", "Authors.json"),
                ["JsonPaths:Books"] = Path.Combine(rootPath, "src", "Library.Console", "Json", "Books.json"),
                ["JsonPaths:BookItems"] = Path.Combine(rootPath, "src", "Library.Console", "Json", "BookItems.json"),
                ["JsonPaths:Patrons"] = Path.Combine(rootPath, "src", "Library.Console", "Json", "Patrons.json"),
                ["JsonPaths:Loans"] = Path.Combine(rootPath, "src", "Library.Console", "Json", "Loans.json")
            })
            .Build();

        var jsonData = new JsonData(config);
        _jsonLoanRepository = new JsonLoanRepository(jsonData);

        // Mock for potential use
        _mockLoanRepository = Substitute.For<ILoanRepository>();
    }

    [Fact]
    public async Task GetLoan_WithValidId_ReturnsLoan()
    {
        // Arrange
        int loanId = 1; // Known to exist in Loans.json

        // Act
        var result = await _jsonLoanRepository.GetLoan(loanId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(loanId, result.Id);
    }

    [Fact]
    public async Task GetLoan_WithInvalidId_ReturnsNull()
    {
        // Arrange
        int loanId = 999; // Known not to exist

        // Act
        var result = await _jsonLoanRepository.GetLoan(loanId);

        // Assert
        Assert.Null(result);
    }
}