using Dapper;
using EventLog.Models;
using System.Data;

namespace EventLog.Repositories
{
    public class AttendeeRepository : IAttendeeRepository
    {
        private readonly IDbConnection _attendeeConn;

        public AttendeeRepository(IDbConnection attendeeConn)
        {
            _attendeeConn = attendeeConn;
        }

        public IEnumerable<Attendee> GetAllAttendees()
        {
            return _attendeeConn.Query<Attendee>("SELECT * FROM attendee ORDER BY AttendeeName;");
        }

        public void InsertAttendee(Attendee attendeeToInsert)
        {
            _attendeeConn.Execute("INSERT INTO attendee (AttendeeName) VALUES (@AttendeeName);", new { attendeeToInsert.AttendeeName });
        }
        public Attendee GetAttendee(int id)
        {
            return _attendeeConn.QuerySingle<Attendee>("SELECT * FROM attendee WHERE attendeeID = @id", new {id=id});
        }

        public void UpdateAttendee(Attendee attendeeToUpdate)
        {
            _attendeeConn.Execute("UPDATE attendee SET AttendeeName = @name WHERE AttendeeID = @id", 
                new { name = attendeeToUpdate.AttendeeName, id = attendeeToUpdate.AttendeeID});
        }

        public void DeleteAttendee(Attendee attendeeToDelete)
        {
            _attendeeConn.Execute("DELETE FROM all_events WHERE Attendees = @name;", new {name = attendeeToDelete.AttendeeName});
            _attendeeConn.Execute("DELETE FROM attendee WHERE AttendeeName = @name;", new { name = attendeeToDelete.AttendeeName });
        }
    }
}
