namespace ToDoManager.TelegramBot.Domain.TodoItem.Repositories;

public interface IToDoItemRepository
{
    ToDoItem? Get(Guid Id);
    void Delete(Guid Id);
    void Update(ToDoItem toDoItem);
    void Add(ToDoItem toDoItem);
}
