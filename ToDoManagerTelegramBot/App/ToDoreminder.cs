namespace ToDoManagerTelegramBot.App;

public sealed class ToDoReminder
{
    private ToDoItem _toDoitem;
    private DateTime _reminderTime;

    public ToDoReminder(ToDoItem toDoItem, DateTime reminderTime)
    {
        _toDoitem = toDoItem;
        _reminderTime = reminderTime;

        Remindered = false;
    }

    public ToDoItem ToDoItem => _toDoitem;
    public TimeSpan RemainingTime => _reminderTime.Subtract(DateTime.Now);
    public bool Remindered { get; private set; }

    public bool NeedToRemainder()
    {
        return Remindered == false && DateTime.UtcNow > _reminderTime;
    }

    public void Remaindered()
    {
        Remindered = true;
    }
}
