using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CodeLou.CSharp.Week3.Challenge
{
	public class ReminderRepisitory: ICalendarItemRepository<Reminder>
	{
		//Info: This is a neat type that allows you to lookup items by ID, be careful not to ask for an item that isn't there
		private readonly Dictionary<int, Reminder> _dictionary; 

		public ReminderRepisitory()
		{
			_dictionary = new Dictionary<int, Reminder>();
		}

		public Reminder Create()
		{
			//Challenge: Can you find a more efficient way to do this?
			var nextAvailableId = 0;
			foreach (var currentId in _dictionary.Keys)
			{
				if (nextAvailableId > currentId)
					continue;
				if (nextAvailableId < currentId)
					break;

				nextAvailableId++;
			}

			//Oops: You may need to modify this constructor
			var reminder = new Reminder();
			reminder.Id = nextAvailableId;
			_dictionary.Add(nextAvailableId, new Reminder());

			return reminder;
		}

		//Callenge: Are you finding that you are writing this same code many times? Is there a better way? Could you use inheritance?
		public Reminder FindById(int id)
		{
			throw new NotImplementedException();
		}

		public Reminder Update(Reminder item)
		{
			throw new NotImplementedException();
		}

		public void Delete(Reminder item)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Reminder> FindByDate(DateTime date)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Reminder> GetAllItems()
		{
			throw new NotImplementedException();
		}

		public string ToJson()
		{
			return JsonConvert.SerializeObject(_dictionary, Formatting.Indented);
		}

		public void LoadFromJson(string json)
		{
			var dictionary = JsonConvert.DeserializeObject<Dictionary<int, Reminder>>(json);
			foreach (var item in dictionary)
			{
				//This will add or update an item
				_dictionary[item.Key] = item.Value;
			}
		}
	}
}
