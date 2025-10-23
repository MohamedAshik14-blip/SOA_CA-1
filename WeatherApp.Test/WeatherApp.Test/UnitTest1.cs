using Xunit;

public class UnitTest1
{
    // This runs before each test (xUnit does not have [SetUp], use constructor)
    public UnitTest1()
    {
        // setup code here
    }

    [Fact]  // single test case
    public void TestSomething()
    {
        // Arrange

        // Act

        // Assert
        Assert.True(true);
    }
}