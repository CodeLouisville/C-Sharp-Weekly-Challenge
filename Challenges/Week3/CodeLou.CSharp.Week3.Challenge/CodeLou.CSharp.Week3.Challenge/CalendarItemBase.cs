using System;

namespace CodeLou.CSharp.Week3.Challenge
{
	public abstract class CalendarItemBase
	{
		public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
