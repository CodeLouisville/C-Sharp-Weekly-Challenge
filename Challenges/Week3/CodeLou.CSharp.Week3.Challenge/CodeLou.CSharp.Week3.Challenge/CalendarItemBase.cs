namespace CodeLou.CSharp.Week3.Challenge
{
	public abstract class CalendarItemBase
	{
		public int Id { get; set; }
        protected int Date { get; set; }
        protected int Time { get; set; }
        protected string Attendee { get; set; }
    }
}
