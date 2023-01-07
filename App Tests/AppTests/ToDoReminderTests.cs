using Xunit;

namespace ToDoManagerTelegramBot.App;
public class ToDoReminderTests
{
    [Fact]
    public void Constructor_ShouldCreateInstant()
    {
        // arrange
        var id = Guid.NewGuid();
        var userId = "userId";
        var name = "name";
        var deadLine = DateTime.UtcNow.Add(TimeSpan.FromHours(1));
        var priority = true;
        var status = true;
        var expectedToDoItem = new ToDoItem(
            id,
            userId,
            name,
            deadLine,
            priority,
            status);
        var expectedReminderedTime = DateTime.UtcNow.Add(TimeSpan.FromMinutes(17));

        // act
        var todoReminder = new ToDoReminder(expectedToDoItem, expectedReminderedTime);
        var actualTodoItem = todoReminder.ToDoItem;
        var actualReminderedTime = todoReminder.ReminderTime;

        // assert
        Assert.Equal(expectedToDoItem, actualTodoItem);
        Assert.Equal(expectedReminderedTime, actualReminderedTime);
        Assert.False(todoReminder.Reminded);
    }

    [Fact]
    public void NeedToRemainder_ShouldBeReturnTrue_reminderTimeIsUp()
    {
        // arrange
        var id = Guid.NewGuid();
        var userId = "userId";
        var name = "name";
        var deadLine = DateTime.UtcNow.Add(TimeSpan.FromHours(25));
        var priority = true;
        var status = true;
        var toDoItem = new ToDoItem(
            id,
            userId,
            name,
            deadLine,
            priority,
            status);
        var reminderedTime = DateTime.UtcNow.Add(TimeSpan.FromMinutes(-1));
        var todoReminder = new ToDoReminder(toDoItem, reminderedTime);

        // act
        var result = todoReminder.NeedToRemainder();

        // assert
        Assert.True(result);
    }

    [Fact]

    public void NeedToRemainder_ShouldBeReturnFalse_reminderTimeHasNotComeYet()
    {
        // arrange
        var id = Guid.NewGuid();
        var userId = "userId";
        var name = "name";
        var deadLine = DateTime.UtcNow.Add(TimeSpan.FromHours(25));
        var priority = true;
        var status = true;
        var toDoItem = new ToDoItem(
            id,
            userId,
            name,
            deadLine,
            priority,
            status);
        var reminderedTime = DateTime.UtcNow.Add(TimeSpan.FromMinutes(22));
        var todoReminder = new ToDoReminder(toDoItem, reminderedTime);

        // act
        var result = todoReminder.NeedToRemainder();

        // assert
        Assert.False(result);
    }

    [Fact]

    public void Remaindered_ShouldReminderedIsTrue()
    {
        // arrange
        var id = Guid.NewGuid();
        var userId = "userId";
        var name = "name";
        var deadLine = DateTime.UtcNow.Add(TimeSpan.FromHours(25));
        var priority = true;
        var status = true;
        var toDoItem = new ToDoItem(
            id,
            userId,
            name,
            deadLine,
            priority,
            status);
        var reminderedTime = DateTime.UtcNow.Add(TimeSpan.FromMinutes(22));
        var todoReminder = new ToDoReminder(toDoItem, reminderedTime);

        // act
        todoReminder.Remaindered();

        // assert
        Assert.True(todoReminder.Reminded);
    }
}