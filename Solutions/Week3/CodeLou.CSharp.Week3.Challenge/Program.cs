using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeLou.CSharp.Week3.Challenge
{
	class Program
	{
		private const string AppointmentsJson = "Appointments.json";
		private const string MeetingJson = "Meetings.json";
		private const string ReminderJson = "Reminders.json";
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
			if (File.Exists(ReminderJson)) //Note: these files are created in the same folder as your .exe
				//Note: What happens when this file is improperly formatte? Can you handle this case?
				reminderRepository.LoadFromJson(File.ReadAllText(ReminderJson));
            
			var appointmentRepository = new AppointmentRepository();
			if (File.Exists(AppointmentsJson)) //Note: these files are created in the same folder as your .exe
				//Note: What happens when this file is improperly formatte? Can you handle this case?
				appointmentRepository.LoadFromJson(File.ReadAllText(AppointmentsJson));

			var meetingRepository = new MeetingRepository();
			if (File.Exists(MeetingJson)) //Note: these files are created in the same folder as your .exe
				//Note: What happens when this file is improperly formatte? Can you handle this case?
				meetingRepository.LoadFromJson(File.ReadAllText(MeetingJson));

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

				switch (char.ToLower(selectedOption))
				{
					case ('q'):
						//End the session when they select q
						sessionEnded = true;
						break;
					case ('a'):
						Console.WriteLine("What Type Do you want to Add?");
						Console.WriteLine("A: Appointment");
						Console.WriteLine("M: Meeting");
						Console.WriteLine("R: Reminder");
						Console.WriteLine();
						Console.Write("Select a type:");
						var addType = Console.ReadKey().KeyChar;
						Console.Clear();

						switch (char.ToLower(addType))
						{
							case ('a'):
								var newAppt = appointmentRepository.Create();

								PopulateAppointment(newAppt);
								break;
							case ('m'):
								var newMeeting = meetingRepository.Create();

								PopulateAppointment(newMeeting);

								newMeeting.Attendees = new List<string>();
								while (true)
								{
									Console.WriteLine("Would you like to add an attendee? (Y or N)");
									if (Console.ReadKey().KeyChar.ToString().ToLower() != "y")
										break;
									newMeeting.Attendees.Add(GetString("Attendee Name"));
								}

								break;
							case ('r'):
								var newReminder = reminderRepository.Create();
								
								newReminder.StartDateTime = GetDateTime("Start Date and Time");
								newReminder.Note = GetString("Note");

								break;
							default:
                                Console.WriteLine($"Invalid Type {addType}");
								break;
						}
						
						break;
					case ('f'):
						var date = GetDateTime("Date you would like to search for");
						var meetings = meetingRepository.FindByDate(date);
						var appointments = appointmentRepository.FindByDate(date);
						var reminders = reminderRepository.FindByDate(date);
						ShowData(meetings, reminders, appointments);
						break;
					case ('v'):
						ShowData(meetingRepository.GetAllItems(), reminderRepository.GetAllItems(), appointmentRepository.GetAllItems());
						break;
					case ('d'):
						Console.WriteLine("What type you want to delete?");
						Console.WriteLine("A: Appointment");
						Console.WriteLine("M: Meeting");
						Console.WriteLine("R: Reminder");
						Console.WriteLine();
						Console.Write("Select a type:");

						var deleteType = Console.ReadKey().KeyChar;
						Console.Clear();

						var sId = GetString("ID that you want to delete");
						int iId;
						if (int.TryParse(sId, out iId))
							switch (char.ToLower(deleteType))
							{
								case ('a'):
									DeleteItem(appointmentRepository, iId);
									Console.WriteLine("Item deleted.");

									break;
								case ('m'):
									DeleteItem(meetingRepository, iId);
									Console.WriteLine("Item deleted.");

									break;
								case ('r'):
									DeleteItem(reminderRepository, iId);
									Console.WriteLine("Item deleted.");

									break;
								default:
									Console.WriteLine("Item deleted.");
									break;
							}
						else
						{
							PrintInvalidId(iId);
						}
						break;
					default:
						Console.WriteLine($"Invalid Option {selectedOption}");
						break;
				}
				if (!sessionEnded)
				{
					Console.WriteLine("Press any key to continue.");
					Console.Read();
				}
				Console.Clear();
			}
			File.WriteAllText(ReminderJson, reminderRepository.ToJson());
			File.WriteAllText(MeetingJson, meetingRepository.ToJson());
			File.WriteAllText(AppointmentsJson, appointmentRepository.ToJson());
		}

		private static void DeleteItem(CalendarItemRepositoryBase reminderRepository, int iId)
		{
			var item = reminderRepository.FindById(iId);
			if (item == null)
				PrintInvalidId(iId);
			else
				reminderRepository.DeleteById(iId);
		}

		private static void PrintInvalidId(int iId)
		{
			PrintInvalidId(iId.ToString());
		}

		private static void PrintInvalidId(string sId)
		{
			Console.WriteLine($"Invalid ID {sId}, press any key to continue.");
			Console.Read();
		}

		private static void ShowData(IEnumerable<Meeting> meetings, IEnumerable<Reminder> reminders, IEnumerable<Appointment> appointments)
		{
			int count = 0;
			Console.WriteLine("Meetings:");
			foreach (var meeting in meetings)
			{
				count ++;
				Console.WriteLine(
					$"    {meeting.Id} {meeting.Note}, with {string.Join(",", meeting.Attendees)} at {meeting.StartDateTime.ToShortTimeString()} to {meeting.EndDateTime.ToShortTimeString()}");
			}
			if(count == 0) Console.WriteLine("    No meetings found");
			Console.WriteLine();
			Console.WriteLine("Reminders:");
			count = 0;
			foreach (var reminder in reminders)
			{
				count++;
				Console.WriteLine(
					$"    {reminder.Id} {reminder.Note} at {reminder.StartDateTime.ToShortTimeString()}");
			}
			if (count == 0) Console.WriteLine("    No reminders found");
			Console.WriteLine();
			Console.WriteLine("Appointments:");
			count = 0;
			foreach (var appt in appointments)
			{
				count++;
				Console.WriteLine(
					$"    {appt.Id} {appt.Note}, at {appt.StartDateTime.ToShortTimeString()} to {appt.EndDateTime.ToShortTimeString()}");
			}
			if (count == 0) Console.WriteLine("    No appointments found");
			Console.WriteLine();
		}

		private static void PopulateAppointment(Appointment newMeeting)
		{
			newMeeting.StartDateTime = GetDateTime("Start Date and Time");
			newMeeting.EndDateTime = GetDateTime("End Date and Time");
			newMeeting.Location = GetString("Location");
			newMeeting.Note = GetString("Note");
		}

		private static string GetString(string itemToGet)
		{
			Console.WriteLine($"What is the {itemToGet}?");
			var item = Console.ReadLine();
			return item;
		}

		private static DateTime GetDateTime(string itemToGet)
		{
			DateTime value;
			string item;
			do
			{
				item = GetString(itemToGet);
			} while (!DateTime.TryParse(item, out value));
			return value;
		}
	}
}
