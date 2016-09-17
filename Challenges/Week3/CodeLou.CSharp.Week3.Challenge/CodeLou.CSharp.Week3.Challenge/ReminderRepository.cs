using System;
using System.Collections.Generic;
using Newtonsoft.Json; //Build the project to cause Visual Studio to load this external NuGet package.
using System.Linq;

namespace CodeLou.CSharp.Week3.Challenge
{
	public class ReminderRepository: ICalendarItemRepository<ReminderItem>
	{
		//Info: This is a neat type that allows you to lookup items by ID, be careful not to ask for an item that isn't there.
		private readonly Dictionary<int, ReminderItem> _dictionary; 

		public ReminderRepository()
		{
			_dictionary = new Dictionary<int, ReminderItem>();
		}

		public ReminderItem Create()
		{
            #region OLD WAY OF CREATING
            //Challenge: Can you find a more efficient way to do this?
            
            //var nextAvailableId = 0;
            //foreach (var currentId in _dictionary.Keys)
            //{
            //	if (nextAvailableId > currentId)
            //		continue;
            //	if (nextAvailableId < currentId)
            //		break;

            //	nextAvailableId++;
            //}
            #endregion

            var nextAvailableId = _dictionary.Keys.Count+1;
            Console.WriteLine("Enter Start date and time (Ex: 01/01/2016 12:00): ");
            var startDateAndTime = DateTime.Parse(Console.ReadLine());
            

            var reminder = new ReminderItem();
			reminder.Id = nextAvailableId;
            reminder.StartDateAndTime = startDateAndTime;         

			_dictionary.Add(reminder.Id, reminder);

			return reminder;
		}

        //Challenge: Are you finding that you are writing this same code many times? Is there a better way? 
        //Could you use inheritance?
		public ReminderItem FindById(int id)
		{
            if (_dictionary.ContainsKey(id))
                return _dictionary[id];
            else
                return null;
		}

		public ReminderItem Update(ReminderItem item)
		{
			throw new NotImplementedException();
		}

		public void Delete(ReminderItem item)
		{
            _dictionary.Remove(item.Id);
        }

		public IEnumerable<ReminderItem> FindByDate(DateTime date)
		{

            throw new NotImplementedException();
        }

		public IEnumerable<ReminderItem> GetAllItems()
		{
            return _dictionary.Values.ToList();
        }

		public string ToJson()
		{
			return JsonConvert.SerializeObject(_dictionary, Formatting.Indented);
		}

		public void LoadFromJson(string json)
		{
			var dictionary = JsonConvert.DeserializeObject<Dictionary<int, ReminderItem>>(json);
			foreach (var item in dictionary)
			{
				//This will add or update an item
				_dictionary[item.Key] = item.Value;
			}
		}
	}
}
