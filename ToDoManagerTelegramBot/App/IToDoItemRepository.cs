namespace ToDoManagerTelegramBot.App;

public interface IToDoItemRepository
{
    public ToDoItem Get(Guid Id);
    public void Delete(Guid Id);
    public void Update(Guid Id, ToDoItem todoItem);
    public void Add(Guid id, ToDoItem toDoItem);
}
