using System;
using System.Collections.Generic;
using System.IO;

namespace finalproj
{
	public class LogBookEntry
	{
		//				private DateTime date;
		//				private string title;
		//				private string entry;
		// creating a method which returns values. i didn't end up needing this.
		public LogBookEntry (int index, string date, string title, string entry)
		{
			this.entryIndex = index;
			this.Date = date;
			this.Title = title;
			this.Entry = entry;
			//I struggled with this for a while. Basically, what I'm trying to convey with the this. keyword was wrong.
			//I put this.date instead of this.Date.
			//not becuase I made a typing error, but because I misunderstood the this. keyword
			// this. basically says "This instance of the method in which you have used this constructor to call will have ITS properties set to the arguments that you have provided.
		}
		public string Date {
			get;
			set;
		}
		public string Title {
			get;
			set;
		}
		public string Entry {
			get;
			set;
		}
		public int entryIndex {
			get;
			set;
		}

	}
	class MainClass1
	{
		public static void Main (string[] args)
		{
			int choice;
			int ind = 0;
			bool isRunning = true;
			List<string> myLogBook = new List<string> (); //using a list for this
			List<LogBookEntry> myOtherLogBook = new List<LogBookEntry> ();
			Console.WriteLine ("Welcome to your logbook.");
			do {
				Console.WriteLine ("What would you like to do?");
				Console.WriteLine ("\t[1]. Add entry");
				Console.WriteLine ("\t[2]. Search entries");
				Console.WriteLine ("\t[3]. Print all entries");
				Console.WriteLine ("\t[4]. Save all entries to text file");
				Console.WriteLine ("\t[5]. Exit program");
				Int32.TryParse (Console.ReadLine (), out choice);
								// This is the if-statement that decides whether or not the program will return an error message.
								// However, it crashes with the input of an integer. I've yet to figure that out.
				if (choice == 1 || choice == 2 || choice == 3 || choice == 4 || choice == 5) {

					ind += 1;
					switch (choice) {
					case 1:
								//add item to backpack and add it on new line
						Console.WriteLine ("What would you like to title your entry?");
						string title = Console.ReadLine ();
						Console.WriteLine ("What would you write in your entry?");
						string entry = Console.ReadLine ();
						DateTime current = DateTime.Now;
						string currentShort = current.ToShortDateString ();
								// set new STRING variable where I convert the DateTime variable type to STRING
								// it seems as if I don't have to convert to string, it does so automatically
								// probably in the same way that int converts implicitly to string
								// but then that begs the question what determines what data type can be converted implicitly to what data type
								// maybe the datetime was constructed that way
						myOtherLogBook.Add (new LogBookEntry (ind, currentShort, title, entry));
						myLogBook.Add (currentShort);
//						string formatted = string.Format ("Date: {0}\nTitle: {1}\n{2}", currentShort, title, entry);
								//use this code later
						break;
					case 2:
//						Console.WriteLine ("What would you like to search for? Try the date or any keyword.");
//						string keyword = Console.ReadLine ();
//
//						for (int i = 0; i < myOtherLogBook.Count; i++) {
//							if (myOtherLogBook.entryIndex [i] == keyword) {
//								Console.WriteLine (myOtherLogBook [i]);
//
//							} else {
//								Console.WriteLine ("Your search returned no results");
//							}
//						}
						Console.WriteLine ("Press any key to continue...");
						Console.ReadLine ();
						break;
							// jag lyckades inte med det har. det blev for krangligt att skapa ett soksystem for en string att jag antog att jag holl pa gora natt fel.
							// jag vantar pa din feedback ang. detta, for att nu vill ja ge tillbaks och verkligen satta in sokfunktione
							// om jag gjorde det med List<> skulle det ha gatt latt men det blev en aning kranglgiare har, och min research hjalpte inte sa mycket
					case 3:
						foreach (LogBookEntry anyentry in myOtherLogBook) {
							string formatted = string.Format ("\nDate: {0}\nTitle: {1}\n{2}\n", anyentry.Date, anyentry.Title, anyentry.Entry);
									// some problems getting this to work. remember to refer to the ANYENTRY variable when using a foreach statement.
							Console.WriteLine (formatted);
						}
						break;
					case 4:
						string path = Environment.GetFolderPath (Environment.SpecialFolder.Desktop);
						try {
							foreach (LogBookEntry anyentry in myOtherLogBook) {
								string formatted = string.Format ("\nDate: {0}\nTitle: {1}\n{2}\n", anyentry.Date, anyentry.Title, anyentry.Entry);
								File.AppendAllText (path, formatted);
							}
									//this won't work because the application gives me an excepton, try below
									//however when I set the path manually it worked
							Console.WriteLine ("Your entries have been successfully saved to your desktop.");
						} catch (System.UnauthorizedAccessException e) {
							Console.WriteLine ("Looks like I don't have access to your files!\n");
							Console.WriteLine ("Press Y if you would like to see the error message");
							string x = Console.ReadLine ();
							if (x.ToUpper () == "Y")
								Console.WriteLine (e);
						}
									//here I am messing around with try catch, I think it's beyond my scope at this moment to look into permissions and whatnot but I will get back into it
						Console.WriteLine ("Press any key to continue...");
						Console.ReadLine ();
						break;
					case 5:
						isRunning = false;
						break;
					default:
									// menu choice. default state after a choice or error is made
						break;
					}
				} else {
					Console.WriteLine ("Invalid option. Please try again.");
					continue;
									// error message
				}	
			} while (isRunning);
		}
	}
}
