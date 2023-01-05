namespace ToDoManagerTelegramBot.App;

public sealed class ToDoReminder
{
    private ToDoItem _toDoitem;
    private DateTime _reminderTime;

    public ToDoReminder(ToDoItem toDoItem, DateTime reminderTime)
    {
        _toDoitem = toDoItem;
        _reminderTime = reminderTime;
    }

    public bool ToDoStatus => _toDoitem.Status;
    public TimeSpan RemainingTime => _reminderTime.Subtract(DateTime.Now);
}
