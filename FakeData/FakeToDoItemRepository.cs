using ToDoManager.TelegramBot.Domain.TodoItem.Repositories;

namespace ToDoManager.TelegramBot.DataAccess.Fake;

public class FakeToDoItemRepository : IToDoItemRepository
{
    private Dictionary<Guid, ToDoItem> _data;

    public FakeToDoItemRepository()
    {
        _data = new Dictionary<Guid, ToDoItem>();
    }
    public ToDoItem? Get(Guid id)
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

    public void Update(ToDoItem toDoItem)
    {
        if (_data.TryGetValue(toDoItem.Id, out var item))
        {
            // the addition will be later
        }
        else
        {
            throw new ArgumentException("id is not present");
        }
    }

    public void Add(ToDoItem toDoItem)
    {
        if (_data.TryGetValue(toDoItem.Id, out var item))
        {
            throw new ArgumentException("id is present");
        }
        else
        {
            _data.Add(toDoItem.Id, toDoItem);
        }
    }
}