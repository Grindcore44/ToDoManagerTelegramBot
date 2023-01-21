using ToDoManager.TelegramBot.Domain.TodoItem.Repositories;
using ToDoManagerTelegramBot.TodoItems;

namespace ToDoManager.TelegramBot.DataAccess.Fake;

public class FakeReminderRepository : IToDoItemReminderRepository
{
    private Dictionary<Guid, ToDoItemReminder> _data;

    public FakeReminderRepository()
    {
        _data = new Dictionary<Guid, ToDoItemReminder>();
    }

    public ToDoItemReminder? Get(Guid id)
    {
        _data.TryGetValue(id, out var item);

        return item;
    }

    public void Delete(Guid id)
    {
        if (_data.TryGetValue(id, out _))
        {
            _data.Remove(id);
        }
        else
        {
            throw new ArgumentException("id is not present");
        }
    }

    public void Update(ToDoItemReminder toDoItemReminder)
    {
        if (_data.TryGetValue(toDoItemReminder.ReminderId, out var item))
        {
            // the addition will be later
        }
        else
        {
            throw new ArgumentException("id is not present");
        }
    }

    public void Add(ToDoItemReminder toDoItemReminder)
    {
        if (_data.TryGetValue(toDoItemReminder.ReminderId, out var item))
        {
            throw new ArgumentException("id is present");
        }
        else
        {
            _data.Add(toDoItemReminder.ReminderId, toDoItemReminder);
        }
    }
}
