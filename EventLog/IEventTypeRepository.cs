using System;
using System.Collections.Generic;
using EventLog.Models;

namespace EventLog
{
    public interface IEventTypeRepository
    {
        //public void InsertEventType(Type newEventTypeToAdd);

        public IEnumerable<EventType> GetAllEventTypes();

    }
}
