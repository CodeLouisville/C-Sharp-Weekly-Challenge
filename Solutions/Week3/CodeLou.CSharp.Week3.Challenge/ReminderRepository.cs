using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeLou.CSharp.Week3.Challenge
{
	public class ReminderRepository: CalendarItemRepositoryBase, ICalendarItemRepository<Reminder>
	{
		public Reminder Create()
		{
			return base.Create<Reminder>();
		}

		public new Reminder FindById(int id)
		{
			return (Reminder)base.FindById(id);
		}

		public Reminder Update(Reminder item)
		{
			return (Reminder)base.Update(item);
		}

		public void Delete(Reminder item)
		{
			DeleteById(item.Id);
		}

		public IEnumerable<Reminder> GetAllItems()
		{
			return Dictionary.Values.Cast<Reminder>();
		}

		public IEnumerable<Reminder> FindByDate(DateTime date)
		{
			return GetAllItems()
				.Where(item => item.StartDateTime.Date == date.Date);
		}
	}
}
