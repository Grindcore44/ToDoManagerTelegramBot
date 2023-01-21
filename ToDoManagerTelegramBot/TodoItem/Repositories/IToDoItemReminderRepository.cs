using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoManagerTelegramBot.TodoItems;

namespace ToDoManager.TelegramBot.Domain.TodoItem.Repositories
{
    public interface IToDoItemReminderRepository
    {
        ToDoItemReminder? Get(Guid Id);
        void Delete(Guid Id);
        void Update(ToDoItemReminder toDoItemReminder);
        void Add(ToDoItemReminder toDoItemReminder);
    }
}
