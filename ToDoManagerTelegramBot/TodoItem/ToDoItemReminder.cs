namespace ToDoManagerTelegramBot.TodoItems;

public sealed class ToDoItemReminder
{
    private Guid _reminderId;
    private ToDoItem _toDoitem;
    private DateTime _reminderTime;

    public ToDoItemReminder(ToDoItem toDoItem, DateTime reminderTime)
    {
        _toDoitem = toDoItem;
        _reminderTime = reminderTime;
        _reminderId = Guid.NewGuid();

        Reminded = false;
    }

    public Guid ReminderId => _reminderId;
    public ToDoItem ToDoItem => _toDoitem;
    public DateTime ReminderTime => _reminderTime;
    public bool Reminded { get; private set; }

    public bool NeedToRemainder()
    {
        return Reminded == false && DateTime.UtcNow > _reminderTime;
    }

    public void Remaindered()
    {
        Reminded = true;
    }
}
