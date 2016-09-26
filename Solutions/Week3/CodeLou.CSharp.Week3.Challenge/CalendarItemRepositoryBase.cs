using System.Collections.Generic;
using Newtonsoft.Json;

namespace CodeLou.CSharp.Week3.Challenge
{
	public abstract class CalendarItemRepositoryBase
	{
		//Info: This is a neat type that allows you to lookup items by ID, be careful not to ask for an item that isn't there.
		protected readonly Dictionary<int, CalendarItemBase> Dictionary;

		protected CalendarItemRepositoryBase()
		{
			Dictionary = new Dictionary<int, CalendarItemBase>();
		}

		public virtual T Create<T>() where T : CalendarItemBase, new()
		{
			//Challenge: Can you find a more efficient way to do this?
			var nextAvailableId = 0;
			foreach (var currentId in Dictionary.Keys)
			{
				if (nextAvailableId > currentId)
					continue;
				if (nextAvailableId < currentId)
					break;

				nextAvailableId++;
			}

			var appointment = new T {Id = nextAvailableId};
			Dictionary.Add(nextAvailableId, appointment);

			return appointment;
		}

		public virtual CalendarItemBase FindById(int id)
		{
			if (Dictionary.ContainsKey(id))
				return Dictionary[id];

			return null;
		}

		public virtual CalendarItemBase Update(CalendarItemBase item)
		{
			Dictionary[item.Id] = item;
			return item;
		}

		public virtual void DeleteById(int id)
		{
			Dictionary.Remove(id);
		}

		public string ToJson()
		{
			return JsonConvert.SerializeObject(Dictionary, Formatting.Indented);
		}

		public void LoadFromJson(string json)
		{
			var dictionary = JsonConvert.DeserializeObject<Dictionary<int, Appointment>>(json);
			foreach (var item in dictionary)
			{
				//This will add or update an item
				Dictionary[item.Key] = item.Value;
			}
		}
	}
}
