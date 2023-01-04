using Xunit;

namespace ToDoManagerTelegramBot.App;

public class ToDoItemTests
{
    [Fact]
    public void Constructor_ShouldCreateInstant_SubstantialValue()
    {
        // arrange
        var expectedId = 111;
        var expectedUserId = "userId";
        var expectedName = "name";
        var expectedDeadLine = DateTime.Now;
        var expectedPriority = false;
        var expectedStatus = false;

        // act
        var constructor = new ToDoItem(
            expectedId,
            expectedUserId,
            expectedName,
            expectedDeadLine,
            expectedPriority,
            expectedStatus);

        var actualId = constructor.Id;
        var actualUserId = constructor.UserId;
        var actualName = constructor.Name;
        var actualDeadLine = constructor.DeadLine;
        var actualPriority = constructor.Priority;
        var actualStatus = constructor.Status;

        // assert
        Assert.Equal(expectedId, actualId);
        Assert.Equal(expectedUserId, actualUserId);
        Assert.Equal(expectedName, actualName);
        Assert.Equal(expectedDeadLine, actualDeadLine);
        Assert.Equal(expectedPriority, actualPriority);
        Assert.Equal(expectedStatus, actualStatus);
    }

    [Fact]
    public void Constructor_ShouldCreateInstant_WithOutStatusAndPriority()
    {
        // arrange
        var expectedId = 111;
        var expectedUserId = "userId";
        var expectedName = "name";
        DateTime? expectedDeadLine = null;
        var expectedPriority = false;
        var expectedStatus = true;

        // act
        var constructor = new ToDoItem(
            expectedId,
            expectedUserId,
            expectedName);

        var actualId = constructor.Id;
        var actualUserId = constructor.UserId;
        var actualName = constructor.Name;
        var actualDeadLine = constructor.DeadLine;
        var actualPriority = constructor.Priority;
        var actualStatus = constructor.Status;

        // assert
        Assert.Equal(expectedId, actualId);
        Assert.Equal(expectedUserId, actualUserId);
        Assert.Equal(expectedName, actualName);
        Assert.Equal(expectedDeadLine, actualDeadLine);
        Assert.Equal(expectedPriority, actualPriority);
        Assert.Equal(expectedStatus, actualStatus);
    }

    [Fact]
    public void Close_ShouldClose_DoesNotClosed()
    {
        // arrange
        var expectedId = 111;
        var expectedUserId = "userId";
        var expectedName = "name";

        var constructor = new ToDoItem(
           expectedId,
           expectedUserId,
           expectedName);

        // act
        constructor.Close();
        
        // assert
        Assert.False(constructor.Status);
    }

    [Theory]
    [InlineData("TestName1", false, false)]
    [InlineData("TestName2", true, false)]
    [InlineData("TestName3", true, true)]
    [InlineData("TestName4", false, true)]
    public void Update_ShouldUpdate(
        string? name = null, 
        bool priority = false, 
        bool? status = null)
    {
        // arrange
        var expectedName = name;
        var expectedPriority = priority;
        var expectedStatus = status;
        var constructor = new ToDoItem(
            111, 
            "userId", 
            "name", 
            null);

        // act
        constructor.Update(
            name, 
            DateTime.Now, 
            priority, 
            status);

        var actualname = constructor.Name;
        var actualPriority = priority;
        var actualStatus = constructor.Status;

        // assert
        Assert.Equal(expectedName, actualname);
        Assert.Equal(expectedPriority, actualPriority);
        Assert.Equal(expectedStatus, actualStatus);
    }

    [Fact]
    public void Update_ShouldUpdate_WithDateTime()
    {
        // arrange
        var expectedName = "name";
        var expectedDeadLine = DateTime.Now;
        var expectedPriority = true;
        var expectedStatus = true;

        var constructor = new ToDoItem(
            111, 
            "userId", 
            expectedName, 
            expectedDeadLine, 
            expectedPriority,
            expectedStatus);

        // act
        constructor.Update();
        var actualname = constructor.Name;
        var actualDeadLine = constructor.DeadLine;
        var actualPriority = constructor.Priority;
        var actualStatus = constructor.Status;

        // assert
        Assert.Equal(expectedName, actualname);
        Assert.Equal(expectedDeadLine, actualDeadLine);
        Assert.Equal(expectedPriority, actualPriority);
        Assert.Equal(expectedStatus, actualStatus);
    }
}
