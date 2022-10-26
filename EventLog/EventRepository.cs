using Dapper;
using EventLog.Models;
using System.Data;

namespace EventLog
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
            return _conn.QuerySingle<Event>("SELECT * FROM all_events WHERE EventID = @id", new { id = id });
        }
          
        public void InsertEvent(Event eventToInsert)
        {
            _conn.Execute("INSERT INTO all_events (Attendees, EventType, SpecialAttribute, Address, Description) " +
                "VALUES (@Attendees, @EventType, @SpecialAttribute, @address, @Description);",
                new { Attendees = eventToInsert.Attendees, EventType= eventToInsert.EventType, SpecialAttribute=eventToInsert.SpecialAttribute,
                Address=eventToInsert.Address, Description=eventToInsert.Description});
                
        }
        //Event Type Section
        public IEnumerable<EventType>GetEventTypes()
        {
            return _conn.Query<EventType>("SELECT * FROM event_type;");
        }
        public Event AssignEventProperties()
        {
            var eventList = GetEventTypes();
            var attendeeList = GetAttendee();
            var specialAttributeList = GetSpecialAttribute();
            var newEvent = new Event()
            {
                EventTypeList = eventList,
                AttendeeList = attendeeList,
                SpecialAttributeList = specialAttributeList
            };
            return newEvent;
        }
        //Special attribute section
        public IEnumerable<SpecialAttribute> GetSpecialAttribute()
        {
            return _conn.Query<SpecialAttribute>("SELECT * FROM special_attribute;");
        }

        //public Event AssignSpecialAttribute()
        //{
        //    var specialList = GetSpecialAttribute();
        //    var newSpecial = new Event();
        //    newSpecial.SpecialAttributeList = specialList;
        //    return newSpecial;
        //}

        //Attendee section
        public IEnumerable<Attendee> GetAttendee()
        {
            return _conn.Query<Attendee>("SELECT * FROM attendee;");
        }

        //public Event AssignAttendee()
        //{
        //    var attendeeList = GetAttendee();
        //    var newAttendee = new Event();
        //    newAttendee.AttendeeList = attendeeList;
        //    return newAttendee;
        //}
    }
}
