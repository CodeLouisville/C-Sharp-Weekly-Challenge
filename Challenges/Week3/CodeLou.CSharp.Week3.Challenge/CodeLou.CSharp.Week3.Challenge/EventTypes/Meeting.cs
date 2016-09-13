using System;

namespace CodeLou.CSharp.Week3.Challenge
{
	public class Meeting: CalendarItemBase
	{
        public DateTime EndDateAndTime { get; set; }
        public string Location { get; set; }
        public int Attendees { get; set; }
    }
}
