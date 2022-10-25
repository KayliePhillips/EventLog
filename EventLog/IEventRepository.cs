using System;
using System.Collections.Generic;
using EventLog.Models;

namespace EventLog
{
    public interface IEventRepository
    {
        public IEnumerable<Event> GetAllEvents();
        public Event GetEvent(int id);
    }
}
