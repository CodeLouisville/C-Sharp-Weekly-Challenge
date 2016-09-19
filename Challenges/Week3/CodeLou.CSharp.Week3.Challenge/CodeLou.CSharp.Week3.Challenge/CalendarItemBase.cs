using System;

namespace CodeLou.CSharp.Week3.Challenge
{
	public abstract class CalendarItemBase
	{
		public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public DateTime EndDate { get; set; }
        public TimeSpan EndTime { get; set; }
        public string Location { get; set; }
        public string AttendeeFirstName { get; set; }
        public string AttendeeLastName { get; set; }

        public string AttendeeFullName() => $"{AttendeeFirstName}, {AttendeeLastName}";
    }
}
