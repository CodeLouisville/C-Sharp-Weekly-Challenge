using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLou.CSharp.Week3.Challenge
{
	public class Appointment: CalendarItemBase
	{
		//assigned a start date and time, an end date and time, and a location
		public DateTime StartDateTime { get; set; }
		public DateTime EndDateTime { get; set; }

		public string Location { get; set; }
	}
}
