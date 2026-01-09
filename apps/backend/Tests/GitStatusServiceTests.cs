using Xunit;
using GitRelax.Backend.Services;

namespace GitRelax.Backend.Tests.Services;

public class GitStatusServiceTests
{
    [Fact]
    public void Constructor_ShouldCreateInstance()
    {
        // Arrange & Act
        var service = new GitStatusService(null!);

        // Assert
        Assert.NotNull(service);
    }

    [Fact]
    public async Task GetStatusAsync_WithNullPath_ShouldThrowArgumentException()
    {
        // Arrange
        var service = new GitStatusService(null!);

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentException>(() => service.GetStatusAsync(null!));
    }

    [Fact]
    public async Task GetStatusAsync_WithEmptyPath_ShouldThrowArgumentException()
    {
        // Arrange
        var service = new GitStatusService(null!);

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentException>(() => service.GetStatusAsync(string.Empty));
    }
}
