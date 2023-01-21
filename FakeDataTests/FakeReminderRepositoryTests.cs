using ToDoManager.TelegramBot.DataAccess.Fake;
using ToDoManagerTelegramBot.TodoItems;
using Xunit;


public class FakeReminderRepositoryTests
{
    [Fact]
    public void Add_ShouldAddNewValue()
    {
        // arrange
        var id = Guid.NewGuid();
        var userId = "userId";
        var name = "name";
        var deadLine = DateTime.UtcNow.Add(TimeSpan.FromHours(1));
        var priority = true;
        var status = true;

        var toDoItem = new ToDoItem(
            id,
            userId,
            name,
            deadLine,
            priority,
            status);
        var reminderedTime = DateTime.UtcNow.Add(TimeSpan.FromMinutes(17));
        var expectedToDoItemReminder = new ToDoItemReminder(toDoItem, reminderedTime);
        var fakeReminderRepository = new FakeReminderRepository();

        // act
        fakeReminderRepository.Add(expectedToDoItemReminder);
        var actualToDoReminder = fakeReminderRepository.Get(expectedToDoItemReminder.ReminderId);
        // assert
        Assert.Equal(expectedToDoItemReminder, actualToDoReminder);
    }

    [Fact]
    public void Get_ShouldGiveValue()
    {
        // arrange
        var id = Guid.NewGuid();
        var userId = "userId";
        var name = "name";
        var deadLine = DateTime.UtcNow.Add(TimeSpan.FromHours(1));
        var priority = true;
        var status = true;

        var toDoItem = new ToDoItem(
            id,
            userId,
            name,
            deadLine,
            priority,
            status);
        var reminderedTime = DateTime.UtcNow.Add(TimeSpan.FromMinutes(17));
        var expectedToDoItemReminder = new ToDoItemReminder(toDoItem, reminderedTime);
        var fakeReminderRepository = new FakeReminderRepository();
        fakeReminderRepository.Add(expectedToDoItemReminder);

        // act
        var actualToDoItemReminder = fakeReminderRepository.Get(expectedToDoItemReminder.ReminderId);

        // assert
        Assert.Equal(expectedToDoItemReminder, actualToDoItemReminder);
    }

    [Fact]
    public void Delete_ShouldDeleteValue_ReturnNull()
    {
        // arrange
        var id = Guid.NewGuid();
        var userId = "userId";
        var name = "name";
        var deadLine = DateTime.UtcNow.Add(TimeSpan.FromHours(1));
        var priority = true;
        var status = true;

        var toDoItem = new ToDoItem(
            id,
            userId,
            name,
            deadLine,
            priority,
            status);
        var reminderedTime = DateTime.UtcNow.Add(TimeSpan.FromMinutes(17));
        var toDoItemReminder = new ToDoItemReminder(toDoItem, reminderedTime);
        var fakeReminderRepository = new FakeReminderRepository();
        fakeReminderRepository.Add(toDoItemReminder);

        // act
        fakeReminderRepository.Delete(toDoItemReminder.ReminderId);

        // assert
        Assert.Null(fakeReminderRepository.Get(toDoItemReminder.ReminderId));
    }
}
