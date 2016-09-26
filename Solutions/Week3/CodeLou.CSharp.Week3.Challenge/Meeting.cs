using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLou.CSharp.Week3.Challenge
{
	public class Meeting: Appointment
	{
		public List<string> Attendees { get; set; } 
	}
}
