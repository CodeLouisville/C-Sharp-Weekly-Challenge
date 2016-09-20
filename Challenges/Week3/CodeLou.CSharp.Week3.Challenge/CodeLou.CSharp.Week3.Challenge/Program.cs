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
                Console.WriteLine("U: update item");
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
                    case ('U'):
                        UpdateItemMenu(appointmentRepository, meetingRepository, reminderRepository);
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

        private static void UpdateItemMenu(AppointmentRepository appointmentRepository, MeetingRepository meetingRepository, ReminderRepository reminderRepository)
        {
            var selectedType = DisplayTypeMenu();
            switch (Char.ToUpper(selectedType))
            {//switch statements require a "break;", be careful not to experience this error
                case ('A'):
                    RetrieveAndDisplayAllAppointments(appointmentRepository);
                    Console.WriteLine("Enter the Id of appointment to update: ");
                    int idOfAppointmentItemToUpdate = int.Parse(Console.ReadLine());
                    appointmentRepository.Update(appointmentRepository.FindById(idOfAppointmentItemToUpdate));
                    break;

                case ('M'):
                    RetrieveAndDisplayAllMeetings(meetingRepository);
                    Console.WriteLine("Enter the Id of meeting to update: ");
                    int idOfMeetingItemToUpdate = int.Parse(Console.ReadLine());
                    meetingRepository.Update(meetingRepository.FindById(idOfMeetingItemToUpdate));
                    break;

                case ('R'):
                    RetrieveAndDisplayAllReminders(reminderRepository);
                    Console.WriteLine("Enter the Id of reminder to update: ");
                    int idOfReminderItemToUpdate = int.Parse(Console.ReadLine());
                    reminderRepository.Update(reminderRepository.FindById(idOfReminderItemToUpdate));   
                    break;

                default:
                    //Note: The $"abc {variable} def" syntax below is new syntactic sugar in C# 6.0 that can be used 
                    //in place of string.Format() in previous versions of C#.
                    Console.WriteLine($"Invalid Type {selectedType}, press any key to continue.");
                    Console.Read();
                    break;
            }
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
                    RetrieveAndDisplayAllAppointments(appointmentRepository);
                    break;
                case ('M'):
                    RetrieveAndDisplayAllMeetings(meetingRepository);
                    break;
                case ('R'):
                    RetrieveAndDisplayAllReminders(reminderRepository);
                    break;
                default:
                    //Note: The $"abc {variable} def" syntax below is new syntactic sugar in C# 6.0 that can be used 
                    //in place of string.Format() in previous versions of C#.
                    Console.WriteLine($"Invalid Type {selectedType}, press any key to continue.");
                    Console.Read();
                    break;
            }
        }

        private static void RetrieveAndDisplayAllReminders(ReminderRepository reminderRepository)
        {
            var ListOfReminders = reminderRepository.GetAllItems();
            Console.WriteLine("Id\tStart date and time");
            foreach (var reminder in ListOfReminders)
                Console.WriteLine($"{reminder.Id}\t{reminder.StartDateAndTime}");
            Console.WriteLine("\nEnd of Reminders\n\n");
        }
        private static void RetrieveAndDisplayAllMeetings(MeetingRepository meetingRepository)
        {
            var ListOfMeetings = meetingRepository.GetAllItems();
            Console.WriteLine("Id\tStart date and time\tEnd date and time\tLocation\t# of attendees");
            foreach (var meeting in ListOfMeetings)
                Console.WriteLine($"{meeting.Id}\t{meeting.StartDateAndTime}\t{meeting.EndDateAndTime}\t{meeting.Location}\t{meeting.Attendees}");
            Console.WriteLine("\nEnd of Meetings\n\n");
        }
        private static void RetrieveAndDisplayAllAppointments(AppointmentRepository appointmentRepository)
        {
            var ListOfAppointments = appointmentRepository.GetAllItems();
            Console.WriteLine("Id\tStart date and time\tEnd date and time\tLocation");
            foreach (var appointment in ListOfAppointments)
                Console.WriteLine($"{appointment.Id}\t{appointment.StartDateAndTime}\t{appointment.EndDateAndTime}\t{appointment.Location}");
            Console.WriteLine("\nEnd of Appointments\n\n");
        }

        private static void FindItemMenu(AppointmentRepository appointmentRepository, MeetingRepository meetingRepository, ReminderRepository reminderRepository)
        {
            
            var selectedType = DisplayTypeMenu();
            DateTime dateToFind;
            switch (Char.ToUpper(selectedType))
            {//switch statements require a "break;", be careful not to experience this error
                case ('A'):

                    Console.Write("Enter the date of the appointment to find: ");
                    dateToFind = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Results");
                    foreach (var item in appointmentRepository.FindByDate(dateToFind))
                        Console.WriteLine($"{item.Id}\t{item.StartDateAndTime}\t{item.EndDateAndTime}\t{item.Location}");
                    Console.WriteLine($"End of search results\n");
                    break;

                case ('M'):
                    Console.Write("Enter the date of the meeting to find: ");
                    dateToFind = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Results");
                    foreach (var item in meetingRepository.FindByDate(dateToFind))
                        Console.WriteLine($"{item.Id}\t{item.StartDateAndTime}\t{item.EndDateAndTime}\t{item.Location}\t{item.Attendees}");
                    Console.WriteLine($"End of search results\n");
                    break;

                case ('R'):
                    Console.Write("Enter the date of the reminder to find: ");
                    dateToFind = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Results");
                    foreach (var item in reminderRepository.FindByDate(dateToFind))
                        Console.WriteLine($"{item.Id}\t{item.StartDateAndTime}");
                    Console.WriteLine($"End of search results\n");                    
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
            var selectedType = DisplayTypeMenu();            
            switch (Char.ToUpper(selectedType))
            {//switch statements require a "break;", be careful not to experience this error
                case ('A'):
                    RetrieveAndDisplayAllAppointments(appointmentRepository);
                    Console.Write("Enter the id of appointment to delete: ");
                    var idOfAppointmentToDelete = 0;
                    int.TryParse(Console.ReadLine(), out idOfAppointmentToDelete);
                    AppointmentItem appointmentToDelete = appointmentRepository.FindById(idOfAppointmentToDelete);
                    if (appointmentToDelete != null)
                    {
                        appointmentRepository.Delete(appointmentToDelete);
                        Console.WriteLine("Appointment deleted\n");
                    }
                    else
                        Console.WriteLine($"Unable to find appointment with id: {idOfAppointmentToDelete}");                   
                    break;
                case ('M'):
                    RetrieveAndDisplayAllMeetings(meetingRepository);
                    Console.Write("Enter the id of meeting to delete: ");
                    var idOfMeetingToDelete = 0;
                    int.TryParse(Console.ReadLine(), out idOfMeetingToDelete);
                    MeetingItem meetingToDelete = meetingRepository.FindById(idOfMeetingToDelete);
                    if (meetingToDelete != null)
                    {
                        meetingRepository.Delete(meetingToDelete);
                        Console.WriteLine("Meeting deleted\n");
                    }
                    else
                        Console.WriteLine($"Unable to find meeting with id: {idOfMeetingToDelete}");
                    break;
                case ('R'):
                    RetrieveAndDisplayAllReminders(reminderRepository);
                    Console.Write("Enter the id of reminder to delete: ");
                    var idOfReminderToDelete = 0;
                    int.TryParse(Console.ReadLine(), out idOfReminderToDelete);
                    ReminderItem reminderToDelete = reminderRepository.FindById(idOfReminderToDelete);
                    if (reminderToDelete != null)
                    {
                        reminderRepository.Delete(reminderToDelete);
                        Console.WriteLine("Reminder deleted\n");
                    }
                    else
                        Console.WriteLine($"Unable to find reminder with id: {idOfReminderToDelete}");
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
