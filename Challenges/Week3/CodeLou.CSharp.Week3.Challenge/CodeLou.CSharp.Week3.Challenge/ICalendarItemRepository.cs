using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CodeLou.CSharp.Week3.Challenge
{
	public interface ICalendarItemRepository<T> where T : CalendarItemBase
	{
		T FindById(int id);
		T Update(T item);
		void Delete(T item);

		IEnumerable<T> FindByDate(DateTime date);
		IEnumerable<T> GetAllItems();
		string ToJson();
		void LoadFromJson(string json);
	}
}
