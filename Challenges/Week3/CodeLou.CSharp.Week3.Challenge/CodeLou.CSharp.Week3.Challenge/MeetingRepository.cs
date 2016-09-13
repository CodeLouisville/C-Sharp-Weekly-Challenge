using System;
using System.Collections.Generic;
using Newtonsoft.Json; //Build the project to cause Visual Studio to load this external NuGet package.

namespace CodeLou.CSharp.Week3.Challenge
{
    public class MeetingRepository : ICalendarItemRepository<Meeting>
    {
        //Info: This is a neat type that allows you to lookup items by ID, be careful not to ask for an item that isn't there.
        private readonly Dictionary<int, Meeting> _dictionary;

        public MeetingRepository()
        {
            _dictionary = new Dictionary<int, Meeting>();
        }

        public Meeting Create()
        {
            
            var nextAvailableId = _dictionary.Keys.Count + 1;
            Console.WriteLine("Enter Start date and time (Ex: 01/01/2016 12:00): ");
            var startDateAndTime = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter End date and time (Ex: 01/01/2016 12:00): ");
            var endDateAndTime = DateTime.Parse(Console.ReadLine());

            var meeting = new Meeting();
            meeting.Id = nextAvailableId;
            meeting.StartDateAndTime = startDateAndTime;
            meeting.EndDateAndTime = endDateAndTime;

            _dictionary.Add(meeting.Id, meeting);

            return meeting;
        }

        //Challenge: Are you finding that you are writing this same code many times? Is there a better way? 
        //Could you use inheritance?
        public Meeting FindById(int id)
        {
            if (_dictionary.ContainsKey(id))
                return _dictionary[id];
            else
                return null;
        }

        public Meeting Update(Meeting item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Meeting item)
        {
            _dictionary.Remove(item.Id);
            //throw new NotImplementedException();
        }

        public IEnumerable<Meeting> FindByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Meeting> GetAllItems()
        {
            throw new NotImplementedException();
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(_dictionary, Formatting.Indented);
        }

        public void LoadFromJson(string json)
        {
            var dictionary = JsonConvert.DeserializeObject<Dictionary<int, Meeting>>(json);
            foreach (var item in dictionary)
            {
                //This will add or update an item
                _dictionary[item.Key] = item.Value;
            }
        }
    }
}
