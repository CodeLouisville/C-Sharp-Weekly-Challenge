using System;
using System.Collections.Generic;
using Newtonsoft.Json; //Build the project to cause Visual Studio to load this external NuGet package.

namespace CodeLou.CSharp.Week3.Challenge
{
    public class AppointmentRepository : ICalendarItemRepository<Appointment>
    {
        //Info: This is a neat type that allows you to lookup items by ID, be careful not to ask for an item that isn't there.
        private readonly Dictionary<int, Appointment> _dictionary;

        public AppointmentRepository()
        {
            _dictionary = new Dictionary<int, Appointment>();
        }

        public Appointment Create()
        {

            var nextAvailableId = _dictionary.Keys.Count + 1;
            Console.WriteLine("Enter Start date and time (Ex: 01/01/2016 12:00): ");
            var startDateAndTime = DateTime.Parse(Console.ReadLine());


            var appointment = new Appointment();
            appointment.Id = nextAvailableId;
            appointment.StartDateAndTime = startDateAndTime;

            _dictionary.Add(appointment.Id, appointment);

            return appointment;
        }

        //Challenge: Are you finding that you are writing this same code many times? Is there a better way? 
        //Could you use inheritance?
        public Appointment FindById(int id)
        {
            if (_dictionary.ContainsKey(id))
                return _dictionary[id];
            else
                return null;
        }

        public Appointment Update(Appointment item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Appointment item)
        {
            _dictionary.Remove(item.Id);
            //throw new NotImplementedException();
        }

        public IEnumerable<Appointment> FindByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Appointment> GetAllItems()
        {
            throw new NotImplementedException();
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(_dictionary, Formatting.Indented);
        }

        public void LoadFromJson(string json)
        {
            var dictionary = JsonConvert.DeserializeObject<Dictionary<int, Appointment>>(json);
            foreach (var item in dictionary)
            {
                //This will add or update an item
                _dictionary[item.Key] = item.Value;
            }
        }
    }
}
