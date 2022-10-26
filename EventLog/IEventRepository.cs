﻿using System;
using System.Collections.Generic;
using EventLog.Models;

namespace EventLog
{
    public interface IEventRepository
    {
        public IEnumerable<Event> GetAllEvents();
        public Event GetEvent(int id);

        public void InsertEvent(Event eventToInsert);

        //Related to event_type
        public IEnumerable<EventType> GetEventTypes();
        public Event AssignEventProperties();

        //related to special_attribute
        public IEnumerable<SpecialAttribute> GetSpecialAttribute();

        //related to attendee
        public IEnumerable<Attendee> GetAttendee();

        public void UpdateEvent(Event eventToUpdate);

        public void DeleteEvent(Event eventToDelete);
       


    }
}
