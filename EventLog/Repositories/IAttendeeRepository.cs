using System;
using System.Collections.Generic;
using EventLog.Models;

namespace EventLog.Repositories
{
    public interface IAttendeeRepository
    {
        public IEnumerable<Attendee> GetAllAttendees();
        public void InsertAttendee(Attendee attendeeToInsert);

        public Attendee GetAttendee(int id);

        public void UpdateAttendee(Attendee attendeeToUpdate);
        public void DeleteAttendee(Attendee attendeeToDelete);
    }
}
