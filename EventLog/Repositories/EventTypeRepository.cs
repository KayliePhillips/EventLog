using Dapper;
using EventLog.Models;
using System.Data;

namespace EventLog.Repositories
{
    public class EventTypeRepository : IEventTypeRepository
    {
        private readonly IDbConnection _connection;

        public EventTypeRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<EventType> GetAllEventTypes()
        {
            return _connection.Query<EventType>("SELECT * FROM event_type ORDER BY EventTypeName;");
        }

        public void InsertEventType(EventType eventTypeToInsert)
        {
            _connection.Execute("INSERT INTO event_type (EventTypeName) VALUES (@EventTypeName);", new { eventTypeToInsert.EventTypeName });
        }
        public EventType GetEventType(int id)
        {
            return _connection.QuerySingle<EventType>("SELECT * FROM event_type WHERE EventTypeID = @id;", new { id });
        }
        public void UpdateEventType(EventType eventTypeToUpdate)
        {
            _connection.Execute("UPDATE event_type SET EventTypeName = @name WHERE EventTypeID = @id;",
                new { name = eventTypeToUpdate.EventTypeName, id = eventTypeToUpdate.EventTypeID });
        }
        public void DeleteEventType(EventType eventTypeToDelete)
        {            
            _connection.Execute("DELETE FROM event_type WHERE EventTypeID = @id;", new { id = eventTypeToDelete.EventTypeID });
            _connection.Execute("DELETE FROM all_events WHERE EventType = @name;", new { name = eventTypeToDelete.EventTypeName });
        }
    }
}
