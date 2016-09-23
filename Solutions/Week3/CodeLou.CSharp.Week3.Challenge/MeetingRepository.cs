using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeLou.CSharp.Week3.Challenge
{
	public class MeetingRepository: CalendarItemRepositoryBase, ICalendarItemRepository<Meeting>
	{
		public Meeting Create()
		{
			return base.Create<Meeting>();
		}

		public new Meeting FindById(int id)
		{
			return (Meeting)base.FindById(id);
		}

		public Meeting Update(Meeting item)
		{
			return (Meeting)base.Update(item);
		}

		public void Delete(Meeting item)
		{
			DeleteById(item.Id);
		}

		public IEnumerable<Meeting> GetAllItems()
		{
			return Dictionary.Values.Cast<Meeting>();
		}

		public IEnumerable<Meeting> FindByDate(DateTime date)
		{
			return GetAllItems()
				.Where(item => item.StartDateTime >= date.Date && date.Date <= item.EndDateTime);
		}
	}
}
