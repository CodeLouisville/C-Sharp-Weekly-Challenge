using System;
using System.Collections.Generic;
using Newtonsoft.Json; //Build the project to cause Visual Studio to load this external NuGet package.

namespace CodeLou.CSharp.Week3.Challenge
{
	public class ReminderRepository: ICalendarItemRepository<Reminder>
	{
		//Info: This is a neat type that allows you to lookup items by ID, be careful not to ask for an item that isn't there.
		private readonly Dictionary<int, Reminder> _dictionary; 

		public ReminderRepository()
		{
			_dictionary = new Dictionary<int, Reminder>();
		}

		public Reminder Create()
		{

            //Challenge: Can you find a more efficient way to do this?
            //OLD WAY
            //var nextAvailableId = 0;
            //foreach (var currentId in _dictionary.Keys)
            //{
            //	if (nextAvailableId > currentId)
            //		continue;
            //	if (nextAvailableId < currentId)
            //		break;

            //	nextAvailableId++;
            //}

            var nextAvailableId = _dictionary.Keys.Count+1;
            Console.WriteLine("Enter Start date and time (Ex: 01/01/2016 12:00): ");
            var startDateAndTime = DateTime.Parse(Console.ReadLine());
            

            var reminder = new Reminder();
			reminder.Id = nextAvailableId;
            reminder.StartDateAndTime = startDateAndTime;         

			_dictionary.Add(reminder.Id, reminder);

			return reminder;
		}

        //Challenge: Are you finding that you are writing this same code many times? Is there a better way? 
        //Could you use inheritance?
		public Reminder FindById(int id)
		{
            if (_dictionary.ContainsKey(id))
                return _dictionary[id];
            else
                return null;
		}

		public Reminder Update(Reminder item)
		{
			throw new NotImplementedException();
		}

		public void Delete(Reminder item)
		{
            _dictionary.Remove(item.Id);
            //throw new NotImplementedException();
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
