namespace EventLog.Models
{
    public class AllEvents
    {
        public int EntryID { get; set; }
        public DateOnly Date { get; set; }
        public string Attendees { get; set; }

        public string Event_Type { get; set; }
        public string Special_Attributes { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
    }
}
