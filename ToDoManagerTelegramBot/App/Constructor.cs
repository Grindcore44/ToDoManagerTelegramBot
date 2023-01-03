﻿using System.ComponentModel.Design;
using System.Xml.Linq;

namespace ToDoManagerTelegramBot.App
{
    public class Constructor
    {
        private int _id;
        private string _userId;
        private string _name;
        private DateTime? _deadLine;
        private bool _priority;
        private bool _status;

        public Constructor(
            int id, 
            string userId, 
            string name, 
            DateTime? deadLine = null,
            bool priority = false,
            bool status = true)

        {
            _id = id;
            _userId = userId;
            _name = name;
            _deadLine = deadLine;
            _priority = priority;
            _status = status;
        }

        public int ID => _id;
        public string UserId => _userId;
        public string Name => _name;
        public DateTime? DeadLine => _deadLine;
        public bool Priority => _priority;
        public bool Status => _status;

        public void Closes()
        { 
            _status = false; 
        }

        public void Сhanges(string? name = null, DateTime? deadLine = null, bool? priority = null, bool? status = null)
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

    }
}