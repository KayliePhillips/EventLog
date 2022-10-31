using Dapper;
using EventLog.Models;
using System.Data;

namespace EventLog.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly IDbConnection _conn;

        public EventRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Event> GetAllEvents()
        {
            return _conn.Query<Event>("SELECT * FROM all_events;");
        }

        public Event GetEvent(int id)
        {
            return _conn.QuerySingle<Event>("SELECT * FROM all_events WHERE EventID = @ID", new { id });
        }

        public void InsertEvent(Event eventToInsert)
        {
            _conn.Execute("INSERT INTO all_events (Date, EventName, Attendees, EventType, SpecialAttribute, Address, Description) " +
                "VALUES (@date, @eventName, @attendees, @eventType, @specialAttribute, @address, @description);",
                new
                {
                    date = eventToInsert.Date,
                    eventName= eventToInsert.EventName,
                    attendees= eventToInsert.Attendees,
                    eventType = eventToInsert.EventType,
                    specialAttribute = eventToInsert.SpecialAttribute,
                    address = eventToInsert.Address,
                    description = eventToInsert.Description
                });

        }

        public Event AssignEventProperties()
        {
            var eventTypeList = GetEventTypes();
            var attendeeList = GetAttendee();
            var specialAttributeList = GetSpecialAttribute();
            var newEvent = new Event()
            {
                EventTypeList = eventTypeList,
                AttendeeList = attendeeList,
                SpecialAttributeList = specialAttributeList
            };
            return newEvent;
        }
        public Event AssignEventProperties(Event eventToUpdate)
        {
            var eventTypeList = GetEventTypes();
            var attendeeList = GetAttendee();
            var specialAttributeList = GetSpecialAttribute();
            eventToUpdate.EventTypeList = eventTypeList;
            eventToUpdate.AttendeeList = attendeeList;
            eventToUpdate.SpecialAttributeList = specialAttributeList;
            
            return eventToUpdate;
        }
        
        public IEnumerable<EventType> GetEventTypes()
        {
            return _conn.Query<EventType>("SELECT * FROM event_type;");
        }
        public IEnumerable<SpecialAttribute> GetSpecialAttribute()
        {
            return _conn.Query<SpecialAttribute>("SELECT * FROM special_attribute;");
        }

        public IEnumerable<Attendee> GetAttendee()
        {
            return _conn.Query<Attendee>("SELECT * FROM attendee;");
        }

        public void UpdateEvent(Event eventToUpdate)
        {
            _conn.Execute("UPDATE all_events SET Date=@date, EventName=@eventName, Attendees=@attendees, EventType=@eventType, " +
                "SpecialAttribute=@specialAttribute, Address=@address, Description = @description WHERE EventID=@eventID",
                new
                {
                    date = eventToUpdate.Date,
                    eventName = eventToUpdate.EventName,
                    attendees = eventToUpdate.Attendees,
                    eventType = eventToUpdate.EventType,
                    specialAttribute = eventToUpdate.SpecialAttribute,
                    address = eventToUpdate.Address,
                    description = eventToUpdate.Description,
                    eventID = eventToUpdate.EventID

                });
        }

        public void DeleteEvent(Event eventToDelete)
        {
            _conn.Execute("DELETE FROM all_events WHERE EventID = @id;", new { id = eventToDelete.EventID });
        }


    }
}
