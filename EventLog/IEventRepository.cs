using System;
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

        //public Event AssignSpecialAttribute();

        //related to attendee
        public IEnumerable<Attendee> GetAttendee();

        //public Event AssignAttendee();
       


    }
}
