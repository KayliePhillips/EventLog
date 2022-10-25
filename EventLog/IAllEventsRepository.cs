using System;
using System.Collections.Generic;
using EventLog.Models;

namespace EventLog
{
    public interface IAllEventsRepository
    {
        public IEnumerable<AllEvents> GetAllEvents();

    }
}
