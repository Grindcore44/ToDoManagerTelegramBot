namespace ToDoManagerTelegramBot.App;

sealed public class ToDoReminder
{
    private DateTime? _deadLine;
    private bool _status;

    public ToDoReminder(ToDoItem toDoItem)
    {
        _deadLine = toDoItem.DeadLine;
        _status = toDoItem.Status;
    }

    public bool Status => _status;
    public DateTime? DeadLine => _deadLine;
    public DateTime? DateTimeNow => DateTime.Now;
    public DateTime? RemainingTime => _deadLine.Subtract(DateTime.Now);

    public void DecideSendMessage()
    {
        if (_status != false)
        { 
            // я не знаю как прописать разницу между дейттаймами
            // напоминания присылаются в 3-х случаях за сутки, за 2 часа, за час
        }
    }

    public void SendMessage(string message)
    {
        /// присылает сообщение о том, сколько осталось времени => RemainingTime
    }


}
