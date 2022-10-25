using Dapper;
using EventLog.Models;
using System.Data;

namespace EventLog
{
    public class AllEventsRepository : IAllEventsRepository
    {
        private readonly IDbConnection _conn;

        public AllEventsRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<AllEvents> GetAllEvents()
        {
            return _conn.Query<AllEvents>("SELECT * FROM all_events;");
        }
    }
}
