using Dapper;
using EventLog.Models;
using System.Data;

namespace EventLog
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
            return _connection.Query<EventType>("SELECT * FROM event_type;");
        }

        public void InsertEventType(EventType eventTypeToInsert)
        {
            _connection.Execute("INSERT INTO event_type (EventTypeName) VALUES (@EventTypeName);", new { EventTypeName = eventTypeToInsert.EventTypeName });
        }
    }
}
