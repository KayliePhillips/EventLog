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

       
    }
}
