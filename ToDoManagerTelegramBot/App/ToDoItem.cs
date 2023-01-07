using ToDoManagerTelegramBot.App;

public sealed class ToDoItem
{
    private Guid _id;
    private string _userId;
    private string _name;
    private DateTime? _deadLine;
    private bool _priority;
    private bool _status;

    public ToDoItem(
        Guid id,
        string userId,
        string name,
        DateTime? deadLine,
        bool priority,
        bool status)

    {
        _id = id;
        _userId = userId;
        _name = name;
        _deadLine = deadLine;
        _priority = priority;
        _status = status;
    }

    public Guid Id => _id;
    public string UserId => _userId;
    public string Name => _name;
    public DateTime? DeadLine => _deadLine;
    public bool Priority => _priority;
    public bool Status => _status;

    public void Close()
    { 
        _status = false; 
    }

    public void Update(
        string? name = null, 
        DateTime? deadLine = null, 
        bool? priority = null, 
        bool? status = null)
    {
        if (name != null)
        { 
            _name = name; 
        }
        
        if (deadLine != null) 
        {
            _deadLine = deadLine;
        }
        
        if (priority != null)
        {
            _priority = priority.Value;
        }

        if (status != null)
        {
            _status = status.Value;
        }
    }

    public ToDoReminder CreateReminder(DateTime reminderTime)
    {
        var todoReminder = new ToDoReminder(this, reminderTime);
        return todoReminder;
    }

    public static ToDoItem Create(
        string userId,
        string name,
        DateTime? deadLine = null,
        bool priority = false)
    { 
        var id = Guid.NewGuid();

        if (string.IsNullOrWhiteSpace(userId))
        { 
            throw new ArgumentNullException(); 
        }

        if (string.IsNullOrWhiteSpace(name))
        { 
            throw new ArgumentNullException(); 
        }

        if (deadLine.HasValue && DateTime.UtcNow > deadLine.Value)
        {
           throw new ArgumentException();
        }

        return new ToDoItem(id, userId, name, deadLine, priority, true);
    }
}