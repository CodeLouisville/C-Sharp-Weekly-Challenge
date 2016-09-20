﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json; //Build the project to cause Visual Studio to load this external NuGet package.
using System.Linq;

namespace CodeLou.CSharp.Week3.Challenge
{
    public class AppointmentRepository : ICalendarItemRepository<AppointmentItem>
    {
        //Info: This is a neat type that allows you to lookup items by ID, be careful not to ask for an item that isn't there.
        private readonly Dictionary<int, AppointmentItem> _dictionary;

        public AppointmentRepository()
        {
            _dictionary = new Dictionary<int, AppointmentItem>();
        }

        public AppointmentItem Create()
        {
            try
            {
                var nextAvailableId = _dictionary.Keys.Count;
                Console.WriteLine("Enter Start date and time (Ex: 01/01/2016 12:00): ");
                var startDateAndTime = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Enter End date and time (Ex: 01/01/2016 12:00): ");
                var endDateAndTime = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Enter location of appointment: ");
                var location = Console.ReadLine();

                var appointment = new AppointmentItem();
                appointment.Id = nextAvailableId;
                appointment.StartDateAndTime = startDateAndTime;
                appointment.EndDateAndTime = endDateAndTime;
                appointment.Location = location;

                _dictionary.Add(appointment.Id, appointment);

                return appointment;
            }
            catch (Exception)
            {
                Console.WriteLine("Enable to create reminder");
                return null;
            }
        }

        //Challenge: Are you finding that you are writing this same code many times? Is there a better way? 
        //Could you use inheritance?
        public AppointmentItem FindById(int id)
        {
            //TODO: move this to CalendarItemBase? So all can inherit and use?
            if (_dictionary.ContainsKey(id))
                return _dictionary[id];
            else
                return null;
        }

        public void Update(AppointmentItem item)
        {
            Console.WriteLine("Enter Start date and time (Ex: 01/01/2016 12:00): ");
            var startDateAndTime = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter End date and time (Ex: 01/01/2016 12:00): ");
            var endDateAndTime = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter location of appointment: ");
            var location = Console.ReadLine();

            _dictionary[item.Id].StartDateAndTime = startDateAndTime;
            _dictionary[item.Id].EndDateAndTime = endDateAndTime;
            _dictionary[item.Id].Location = location;                       
        }

        public void Delete(AppointmentItem item)
        {
            _dictionary.Remove(item.Id);           
        }

        public IEnumerable<AppointmentItem> FindByDate(DateTime date)
        {
            List<AppointmentItem> listOfMatchingDates = new List<AppointmentItem>();
            foreach (var item in _dictionary)
            {
                if (item.Value.StartDateAndTime.Date == date.Date)
                    listOfMatchingDates.Add(item.Value);
            }
            return listOfMatchingDates;
        }

        public IEnumerable<AppointmentItem> GetAllItems()
        {
            return _dictionary.Values.ToList();
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(_dictionary, Formatting.Indented);
        }

        public void LoadFromJson(string json)
        {
            try
            { 
                var dictionary = JsonConvert.DeserializeObject<Dictionary<int, AppointmentItem>>(json);
                foreach (var item in dictionary)
                {
                    //This will add or update an item
                    _dictionary[item.Key] = item.Value;
                }
            }catch(JsonReaderException e)
            {
                Console.WriteLine($"Error reading {json} file: {e.Message}\n");
            }
}
    }
}
