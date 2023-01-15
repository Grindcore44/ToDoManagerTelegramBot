using ToDoManagerTelegramBot.App;
namespace FakeData;

public class FakeData : IToDoItemRepository
{
    private Dictionary<Guid, ToDoItem> _data;

    public ToDoItem Get(Guid id)
    {
        if (_data.TryGetValue(id, out var item))
        {
            return _data.GetValueOrDefault(id);
        }
        else
        {
            throw new ArgumentException();
        }
    }

    public void Delete(Guid id)
    {
        if (_data.TryGetValue(id, out var item))
        {
            _data.Remove(id);
        }
        else
        {
            throw new ArgumentException();
        }
    }

    public void Update(Guid id, ToDoItem toDoItem)
    {
        if (_data.TryGetValue(id, out var item))
        {
            _data.Remove(id);
            _data.Add(id, toDoItem);
        }
        else
        {
            _data.Add(id, toDoItem);
        }
    }

    public void Add(Guid id, ToDoItem toDoItem)
    {
        if (_data.TryGetValue(id, out var item))
        {
            _data.Remove(id);
            _data.Add(id, toDoItem);
        }
        else
        {
            _data.Add(id, toDoItem);
        }
    }
}