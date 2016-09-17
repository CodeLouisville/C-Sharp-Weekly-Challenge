using System;
using System.IO;

namespace CodeLou.CSharp.Week3.Challenge
{
	class Program
	{

		static void Main(string[] args)
		{
			// Overview:
			// In this assignment, you will be creating a calendar application that will load and save data. An example of loading and saving data has been provided.
			// This calendar application will accept multiple event types which will be represented by their own class types. 
			// You will be dealing with Appointments, Meetings, and Reminders.

			// Task 1:
			// Create new classes that will represent the calendar items that you will be using. 
			// Each of your classes will inherit from the CalendarItemBase abstract class.
			// Reminders have already been created as an example.
			
			// Task 2:
			// Define Your Data
			// Appointments need to be assigned a start date and time, an end date and time, and a location.
			// Meetings need to be assigned a start date and time, an end date and time, a location, and attendees. You can decide what data you need for attendees.
			// Reminders need to be assigned a start date and time.
			// Hint: Use inheritance to make your life easier.

            // Task 3:
            // Add the missing code to the ReminderRepository. Hint: Look for instances of NotImplementedException.
            // Create repository classes for Appointments and Meetings. Use the ReminderRepository as an example.

			// Task 4:
			// We want our application to load data and to save data. The process for reminders has already been created. You will need to do the same thing
			// for the other data types.
			var reminderRepository = new ReminderRepository(); 
			if (File.Exists("Reminders.json")) //Note: these files are created in the same folder as your .exe
				//Note: What happens when this file is improperly formatte? Can you handle this case?
				reminderRepository.LoadFromJson(File.ReadAllText("Reminders.json"));

            var appointmentRepository = new AppointmentRepository();
            if (File.Exists("Appointments.json"))                                                   
                appointmentRepository.LoadFromJson(File.ReadAllText("Appointments.json"));

            var meetingRepository = new MeetingRepository();
            if (File.Exists("Meetings.json")) 
                meetingRepository.LoadFromJson(File.ReadAllText("Meetings.json"));


            // Task 5:
            // Fill in the missing options A, V, F, D for all classes
            var sessionEnded = false;
			while (!sessionEnded)
			{
				Console.WriteLine("Q: save and quit");
				Console.WriteLine("A: add item");
				Console.WriteLine("V: view all");
				Console.WriteLine("F: find by date");
				Console.WriteLine("D: delete an item");
				Console.WriteLine();

				Console.Write("Select an action: ");
				var selectedOption = Console.ReadKey().KeyChar;
				Console.Clear();

				switch (Char.ToUpper(selectedOption))
				{
					case ('Q'):
						//End the session when they select q
						sessionEnded = true;
						break;
					case ('A'):
                        AddItemMenu(appointmentRepository, meetingRepository, reminderRepository);						
						break;
					case ('V'):
                        ViewItemMenu(appointmentRepository, meetingRepository, reminderRepository);
                        break;
					case ('F'):
                        FindItemMenu(appointmentRepository, meetingRepository, reminderRepository);
                        break;
					case ('D'):
                        DeleteItemMenu(appointmentRepository, meetingRepository, reminderRepository);
                        break;
					default:
						Console.WriteLine($"Invalid Option {selectedOption}, press any key to continue.");
						Console.Read();
						break;
				}
			}
			File.WriteAllText("Appointments.json", appointmentRepository.ToJson());
            File.WriteAllText("Meetings.json", meetingRepository.ToJson());
            File.WriteAllText("Reminders.json", reminderRepository.ToJson());

        }

        

        private static void AddItemMenu(AppointmentRepository appointmentRepository, MeetingRepository meetingRepository, ReminderRepository reminderRepository)
        {
            var selectedType = DisplayTypeMenu();
            switch (Char.ToUpper(selectedType))
            {//switch statements require a "break;", be careful not to experience this error
                case ('A'):
                    var newAppointment = appointmentRepository.Create();
                    break;
                case ('M'):
                    var newMeeting = meetingRepository.Create();
                    break;
                case ('R'):
                    var newReminder = reminderRepository.Create();
                    break;
                default:
                    //Note: The $"abc {variable} def" syntax below is new syntactic sugar in C# 6.0 that can be used 
                    //in place of string.Format() in previous versions of C#.
                    Console.WriteLine($"Invalid Type {selectedType}, press any key to continue.");
                    Console.Read();
                    break;
            }


        }
        private static void ViewItemMenu(AppointmentRepository appointmentRepository, MeetingRepository meetingRepository, ReminderRepository reminderRepository)
        {
            var selectedType = DisplayTypeMenu();
            switch (Char.ToUpper(selectedType))
            {//switch statements require a "break;", be careful not to experience this error
                case ('A'):
                    var ListOfAppointments = appointmentRepository.GetAllItems();
                    Console.WriteLine("Id\tStart date and time\tEnd date and time\tLocation");
                    foreach (var appointment in ListOfAppointments)
                        Console.WriteLine($"{appointment.Id}\t{appointment.StartDateAndTime}\t{appointment.EndDateAndTime}\t{appointment.Location}");
                    Console.WriteLine("\nEnd of Appointments\n\n");
                    break;
                case ('M'):
                    var ListOfMeetings = meetingRepository.GetAllItems();
                    Console.WriteLine("Id\tStart date and time\tLocation\t# of attendees");
                    foreach (var meeting in ListOfMeetings)
                        Console.WriteLine($"{meeting.Id} {meeting.StartDateAndTime} {meeting.Location} {meeting.Attendees}");
                    Console.WriteLine("\nEnd of Meetings\n\n");
                    break;
                case ('R'):
                    var ListOfReminders = reminderRepository.GetAllItems();
                    Console.WriteLine("Id\tStart date and time");
                    foreach (var reminder in ListOfReminders)
                        Console.WriteLine($"{reminder.Id} {reminder.StartDateAndTime}");
                    Console.WriteLine("\nEnd of Reminders\n\n");
                    break;
                default:
                    //Note: The $"abc {variable} def" syntax below is new syntactic sugar in C# 6.0 that can be used 
                    //in place of string.Format() in previous versions of C#.
                    Console.WriteLine($"Invalid Type {selectedType}, press any key to continue.");
                    Console.Read();
                    break;
            }
        }
        private static void FindItemMenu(AppointmentRepository appointmentRepository, MeetingRepository meetingRepository, ReminderRepository reminderRepository)
        {
            var selectedType = DisplayTypeMenu();
            switch (Char.ToUpper(selectedType))
            {//switch statements require a "break;", be careful not to experience this error
                case ('A'):

                    Console.Write("Enter the appointment ID: ");
                    int appointmentId;
                    int.TryParse(Console.ReadLine(), out appointmentId);
                    var appointmentToFind = appointmentRepository.FindById(appointmentId);
                    if (appointmentToFind != null)
                    {
                        Console.WriteLine($"{appointmentToFind.Id}\t{appointmentToFind.StartDateAndTime}\t{appointmentToFind.EndDateAndTime}\t{appointmentToFind.Location}\n");                        
                    }
                    else
                    {
                        Console.WriteLine("Appointment not found");
                    }
                    break;

                case ('M'):
                    var ListOfMeetings = meetingRepository.GetAllItems();
                    foreach (var meeting in ListOfMeetings)
                        Console.WriteLine($"{meeting.Id} {meeting.StartDateAndTime} {meeting.Location} {meeting.Attendees}");
                    break;
                case ('R'):
                    var ListOfReminders = reminderRepository.GetAllItems();
                    foreach (var reminder in ListOfReminders)
                        Console.WriteLine($"{reminder.Id} {reminder.StartDateAndTime}");
                    break;
                default:
                    //Note: The $"abc {variable} def" syntax below is new syntactic sugar in C# 6.0 that can be used 
                    //in place of string.Format() in previous versions of C#.
                    Console.WriteLine($"Invalid Type {selectedType}, press any key to continue.");
                    Console.Read();
                    break;
            }
        }
        private static void DeleteItemMenu(AppointmentRepository appointmentRepository, MeetingRepository meetingRepository, ReminderRepository reminderRepository)
        {
            //TODO: Replace Create with Delete options
            var selectedType = DisplayTypeMenu();
            switch (Char.ToUpper(selectedType))
            {//switch statements require a "break;", be careful not to experience this error
                case ('A'):
                    var newAppointment = appointmentRepository.Create();
                    break;
                case ('M'):
                    var newMeeting = meetingRepository.Create();
                    break;
                case ('R'):
                    var newReminder = reminderRepository.Create();
                    break;
                default:
                    //Note: The $"abc {variable} def" syntax below is new syntactic sugar in C# 6.0 that can be used 
                    //in place of string.Format() in previous versions of C#.
                    Console.WriteLine($"Invalid Type {selectedType}, press any key to continue.");
                    Console.Read();
                    break;
            }
        }
      
        
        public static char DisplayTypeMenu()
        {
            Console.WriteLine("A: Appointment");
            Console.WriteLine("M: Meeting");
            Console.WriteLine("R: Reminder");
            Console.WriteLine();
            Console.Write("Select a type:");
            var selectedType = Console.ReadKey().KeyChar;
            Console.Clear();
            return selectedType;
        }

    }
}
