using System;

namespace CodeLou.CSharp.Week3.Challenge
{
	public class MeetingItem: CalendarItemBase
	{
        public DateTime EndDateAndTime { get; set; }
        public string Location { get; set; }
        public int Attendees { get; set; }
    }
}
