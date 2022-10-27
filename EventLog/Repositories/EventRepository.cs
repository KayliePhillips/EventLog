﻿using Dapper;
using EventLog.Models;
using System.Data;

namespace EventLog.Repositories
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
            return _conn.QuerySingle<Event>("SELECT * FROM all_events WHERE EventID = @ID", new { id });
        }

        public void InsertEvent(Event eventToInsert)
        {
            _conn.Execute("INSERT INTO all_events (EventName, Attendees, EventType, SpecialAttribute, Address, Description) " +
                "VALUES (@EventName, @Attendees, @EventType, @SpecialAttribute, @Address, @Description);",
                new
                {
                    eventToInsert.EventName,
                    eventToInsert.Attendees,
                    eventToInsert.EventType,
                    eventToInsert.SpecialAttribute,
                    eventToInsert.Address,
                    eventToInsert.Description
                });

        }

        public Event AssignEventProperties()
        {
            var eventList = GetEventTypes();
            var attendeeList = GetAttendee();
            var specialAttributeList = GetSpecialAttribute();
            var newEvent = new Event()
            {
                EventTypeList = eventList,
                AttendeeList = attendeeList,
                SpecialAttributeList = specialAttributeList
            };
            return newEvent;
        }
        //Event Type Section
        public IEnumerable<EventType> GetEventTypes()
        {
            return _conn.Query<EventType>("SELECT * FROM event_type;");
        }

        //Special attribute section
        public IEnumerable<SpecialAttribute> GetSpecialAttribute()
        {
            return _conn.Query<SpecialAttribute>("SELECT * FROM special_attribute;");
        }

        //Attendee section
        public IEnumerable<Attendee> GetAttendee()
        {
            return _conn.Query<Attendee>("SELECT * FROM attendee;");
        }

        //Update event
        public void UpdateEvent(Event eventToUpdate)
        {
            _conn.Execute("UPDATE all_events SET EventName=@EventName, Attendees=@Attendees, EventType=@EventType, " +
                "SpecialAttribute=@SpecialAttribute, Address=Address, Description = @Description WHERE EventID=@EventID",
                new
                {
                    eventToUpdate.EventID,
                    eventToUpdate.EventName,
                    eventToUpdate.Attendees,
                    eventToUpdate.EventType,
                    eventToUpdate.SpecialAttribute,
                    eventToUpdate.Address,
                    eventToUpdate.Description,

                });
        }

        public void DeleteEvent(Event eventToDelete)
        {
            _conn.Execute("DELETE FROM all_events WHERE EventID = @id;", new { id = eventToDelete.EventID });
        }


    }
}