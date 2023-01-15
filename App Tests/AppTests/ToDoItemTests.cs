using System;
using Xunit;

namespace App_Tests.AppTests;

public class ToDoItemTests
{
    [Fact]
    public void Constructor_ShouldCreateInstant()
    {
        // arrange
        var expectedId = Guid.NewGuid();
        var expectedUserId = "userId";
        var expectedName = "name";
        var expectedDeadLine = DateTime.UtcNow;
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
    public void Close_ShouldClose_DoesNotClosed()
    {
        // arrange
        var expectedId = Guid.NewGuid();
        var expectedUserId = "userId";
        var expectedName = "name";
        var deadLine = DateTime.UtcNow;

        var constructor = new ToDoItem(
           expectedId,
           expectedUserId,
           expectedName,
           deadLine,
           true,
           true);

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
            Guid.NewGuid(),
            "userId",
            "name",
            DateTime.UtcNow,
            true,
            true);

        // act
        constructor.Update(
            name,
            DateTime.UtcNow,
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
        var expectedDeadLine = DateTime.UtcNow;
        var expectedPriority = true;
        var expectedStatus = true;

        var constructor = new ToDoItem(
            Guid.NewGuid(),
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


    [Fact]
    public void CreateReminder_ShouldCreateNewRemainder()
    {
        // arrange
        var id = Guid.NewGuid();
        var userId = "userId";
        var name = "name";
        var deadLine = DateTime.UtcNow.Add(TimeSpan.FromHours(25));
        var priority = true;
        var status = true;
        var expectedToDoItem = new ToDoItem(
            id,
            userId,
            name,
            deadLine,
            priority,
            status);

        var expectedReminderTime = DateTime.UtcNow.Add(TimeSpan.FromMinutes(1));

        // act
        var actualReminder = expectedToDoItem.CreateReminder(expectedReminderTime);

        // assert
        Assert.False(actualReminder.Reminded);
        Assert.Equal(expectedReminderTime, actualReminder.ReminderTime);
        Assert.Equal(expectedToDoItem, actualReminder.ToDoItem);
    }

    [Fact]
    public void Create_ShouldCreateNewToDoItem()
    {
        // arrange
        var expectedUserId = "userId";
        var expectedName = "name";

        //act
        var todoItem = ToDoItem.Create(expectedUserId, expectedName);

        // assert
        Assert.True(todoItem.Status);
        Assert.False(todoItem.Priority);
        Assert.Null(todoItem.DeadLine);
        Assert.Equal(expectedUserId, todoItem.UserId);
        Assert.Equal(expectedName, todoItem.Name);
        Assert.NotNull(todoItem.Id);
    }

    [Fact]
    public void Create_ShouldThrow_WhiteSpace()
    {
        // arrange
        var expectedUserId = " ";
        var expectedName = " ";

        //act   //assert
        Assert.Throws<ArgumentNullException>(() => ToDoItem.Create(expectedUserId, expectedName));
        Assert.Throws<ArgumentNullException>(() => ToDoItem.Create(expectedUserId, expectedName));
    }

    [Fact]
    public void Create_ShouldThrow_DeadlineInPast()
    {
        // arrange
        var userId = "userId";
        var name = "name";
        var deadLine = DateTime.UtcNow.Add(TimeSpan.FromMinutes(-33));

        //act  // assert
        Assert.Throws<ArgumentException>(() => ToDoItem.Create(userId, name, deadLine));
    }
}
