using System;
using System.Collections.Generic;
using Newtonsoft.Json; //Build the project to cause Visual Studio to load this external NuGet package.
using System.Linq;

namespace CodeLou.CSharp.Week3.Challenge
{
    public class MeetingRepository : ICalendarItemRepository<MeetingItem>
    {
        //Info: This is a neat type that allows you to lookup items by ID, be careful not to ask for an item that isn't there.
        private readonly Dictionary<int, MeetingItem> _dictionary;

        public MeetingRepository()
        {
            _dictionary = new Dictionary<int, MeetingItem>();
        }

        public MeetingItem Create()
        {
            
            var nextAvailableId = _dictionary.Keys.Count + 1;
            Console.WriteLine("Enter Start date and time (Ex: 01/01/2016 12:00): ");
            var startDateAndTime = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter End date and time (Ex: 01/01/2016 12:00): ");
            var endDateAndTime = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter location of meeting: ");
            var location = Console.ReadLine();

            Console.WriteLine("Enter number of attendees: ");
            var attendees = int.Parse(Console.ReadLine());

            var meeting = new MeetingItem();
            meeting.Id = nextAvailableId;
            meeting.StartDateAndTime = startDateAndTime;
            meeting.EndDateAndTime = endDateAndTime;
            meeting.Location = location;
            meeting.Attendees = attendees;

            _dictionary.Add(meeting.Id, meeting);

            return meeting;
        }

        //Challenge: Are you finding that you are writing this same code many times? Is there a better way? 
        //Could you use inheritance?
        public MeetingItem FindById(int id)
        {
            if (_dictionary.ContainsKey(id))
                return _dictionary[id];
            else
                return null;
        }

        public MeetingItem Update(MeetingItem item)
        {
            throw new NotImplementedException();
        }

        public void Delete(MeetingItem item)
        {
            _dictionary.Remove(item.Id);            
        }

        public IEnumerable<MeetingItem> FindByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MeetingItem> GetAllItems()
        {
            return _dictionary.Values.ToList();
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(_dictionary, Formatting.Indented);
        }

        public void LoadFromJson(string json)
        {
            var dictionary = JsonConvert.DeserializeObject<Dictionary<int, MeetingItem>>(json);
            foreach (var item in dictionary)
            {
                //This will add or update an item
                _dictionary[item.Key] = item.Value;
            }
        }
    }
}
