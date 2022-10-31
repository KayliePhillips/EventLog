using System;
using System.Collections.Generic;
using EventLog.Models;

namespace EventLog.Repositories
{
    public interface IEventRepository
    {
        public IEnumerable<Event> GetAllEvents();
        public Event GetEvent(int id);

        public void InsertEvent(Event eventToInsert);

        
        public IEnumerable<EventType> GetEventTypes();
        public Event AssignEventProperties();
        public Event AssignEventProperties(Event eventToUpdate);

        public IEnumerable<SpecialAttribute> GetSpecialAttribute();

        public IEnumerable<Attendee> GetAttendee();

        public void UpdateEvent(Event eventToUpdate);

        public void DeleteEvent(Event eventToDelete);



    }
}
