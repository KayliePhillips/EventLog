using System;
using System.Collections.Generic;
using EventLog.Models;

namespace EventLog
{
    public interface IEventTypeRepository
    {
        public IEnumerable<EventType> GetAllEventTypes();
        public void InsertEventType(EventType eventTypeToInsert);
    }
}
