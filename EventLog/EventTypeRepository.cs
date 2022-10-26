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
        //public void InsertEventType(Type newEventTypeToAdd)
        //{
        //    _connection.Execute("INSERT INTO event_type (EventTypeName) VALUES (@EventTypeName);", new {name = newEventTypeToAdd.Name});
        //}

        public IEnumerable<EventType> GetAllEventTypes()
        {
            return _connection.Query<EventType>("SELECT * FROM event_type;");
        }
        

       

        
    }
}
