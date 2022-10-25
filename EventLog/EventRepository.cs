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
            return _conn.QuerySingle<Event>("SELECT * FROM all_events WHERE entryID = @id", new { id = id });
        }

        public IEnumerable<EventType> GetEventTypes()
        {
            return _conn.Query<EventType>("SELECT * FROM event_type;");
        }

        public void InsertEvent(Event eventToInsert)
        {
            _conn.Execute("INSERT INTO all_events (Attendees, EventType, SpecialAttributes, Address, Description) " +
                "VALUES (@Attendees, @EventType, @SpecialAttributes, @address, @Description);",
                new { Attendees = eventToInsert.Attendees, EventType= eventToInsert.EventType, SpecialAttribute=eventToInsert.SpecialAttributes,
                Address=eventToInsert.Address, Description=eventToInsert.Description});
                
        }
        public Event AssignEvent()
        {
            var eventList = GetEventTypes();
            var newEvent = new Event();
            newEvent.EventTypeList = eventList;
            return newEvent;
        }
    }
}
