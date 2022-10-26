﻿using System;
using System.Collections.Generic;
using EventLog.Models;

namespace EventLog
{
    public interface IEventTypeRepository
    {
        public IEnumerable<EventType> GetAllEventTypes();
        public void InsertEventType(EventType eventTypeToInsert);
        public EventType GetEventType(int id);
        public void UpdateEventType(EventType eventTypeToUpdate);
    }
}
