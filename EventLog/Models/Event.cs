﻿namespace EventLog.Models
{
    public class Event
    {
        public int EventID { get; set; }
        public DateOnly Date { get; set; }
        public string Attendees { get; set; }

        public string EventType { get; set; }
        public string SpecialAttributes { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }

        public IEnumerable<EventType> EventTypeList { get; set; }
    }
}
