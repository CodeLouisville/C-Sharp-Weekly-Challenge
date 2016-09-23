using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeLou.CSharp.Week3.Challenge
{
	public class AppointmentRepository: CalendarItemRepositoryBase, ICalendarItemRepository<Appointment>
	{
		public Appointment Create()
		{
			return base.Create<Appointment>();
		}
		
		public new Appointment FindById(int id)
		{
			return (Appointment)base.FindById(id);
		}

		public Appointment Update(Appointment item)
		{
			return (Appointment) base.Update(item);
		}

		public void Delete(Appointment item)
		{
			DeleteById(item.Id);
		}

		public IEnumerable<Appointment> FindByDate(DateTime date)
		{
			return GetAllItems()
				.Where(item => item.StartDateTime >= date.Date && date.Date <= item.EndDateTime);
		}

		public IEnumerable<Appointment> GetAllItems()
		{
			return Dictionary.Values.Cast<Appointment>();
		}
	}
}
