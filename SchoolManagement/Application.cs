using System;
using System.Collections.Generic;
using System.Linq;


namespace SchoolManagement
{
	public class Application
	{
		
		static School MySchool = new School();
		public static void Operate()
		{
			FakeData();

			//Menu();
		
			App();
		//	AddAdress();
		
		}


		static void Menu()
		{
			Console.WriteLine("------  School Management Application  -----");
			Console.WriteLine();
			Console.WriteLine("1 - List All Students");
			Console.WriteLine("2 - List All Students by Branch");
			Console.WriteLine("3 - List All Students by Gender");
			Console.WriteLine("4 - List Born After This Date");
			Console.WriteLine("5 - List All Students by City");
			Console.WriteLine("6 - List All Notes of the Student");
			Console.WriteLine("7 - List All Books of the Student");
			Console.WriteLine("8 - List 5 Students Who Have a Highest Note in the School");
			Console.WriteLine("9 - List 3 Students Who Have a Lowest Note in the School");
			Console.WriteLine("10 - List 5 Students Who Have a Highest Note in the Branch");
			Console.WriteLine("11 - List 3 Students Who Have a Lowest Note in the Branch");
			Console.WriteLine("12 - Show Average of the Student");
			Console.WriteLine("13 - Show Average of Branch");
			Console.WriteLine("14 - Show the Last Book the Student Read");
			Console.WriteLine("15 - Add Student");
			Console.WriteLine("16 - Update Student");
			Console.WriteLine("17 - Enter Student's Adress");
			Console.WriteLine("18 - Enter Student's Note");
			Console.WriteLine();
			Console.WriteLine("For Exit write 'Exit' and Press Enter.");
		}
		static void FakeData()
		{
			
			MySchool.AddStudent("Eren", "AVAR", 1, new DateTime(2009, 05, 29), "M", "A");
			MySchool.AddStudent("Nehir", "AVAR", 2, new DateTime(2001,05, 29), "F", "B");
			MySchool.AddStudent("Yeşim", "AVAR", 3, new DateTime(1989,05, 29), "F", "B");
			MySchool.AddStudent("Eda", "AVAR", 4, new DateTime(1989,05, 29), "F", "B");
			MySchool.AddStudent("Gökçe", "Kılıç", 5, new DateTime(1989,05, 29), "F", "A");
			MySchool.AddStudent("Gonca", "Dede", 6, new DateTime(1980, 05, 29), "F", "A");

			MySchool.AddAdress(1, "Istanbul", "Kadıkoy");
			MySchool.AddAdress(2, "Izmir", "Karsiyaka");
			MySchool.AddAdress(3, "Ankara", "Kizilay");
			MySchool.AddAdress(4, "Izmir", "Karsiyaka");
			MySchool.AddAdress(5, "Istanbul", "Besiktas");
			MySchool.AddAdress(6, "Ankara", "Yenimahalle");

			MySchool.AddFakeNotes(1,"Math", 90);
			MySchool.AddFakeNotes(1,"History", 80);
			MySchool.AddFakeNotes(2,"Math", 75);
			MySchool.AddFakeNotes(3,"Math", 83);
			MySchool.AddFakeNotes(4,"Math", 41);
			MySchool.AddFakeNotes(5,"Math", 60);
			MySchool.AddFakeNotes(6,"Math", 73);
		

			string[]  FakeBook = new string[6];
			FakeBook[0] = "Ince Memed";
			FakeBook[1] = "World History";
			FakeBook[2] = "Placebo Affect";
			FakeBook[3] = "Car Magazine";
			FakeBook[4] = "Javascript";
			FakeBook[5] = "C#";

			MySchool.AddBooks(FakeBook, MySchool.Students);




		                               
		}
		static void App()
		{
			while (true)
			{
				Console.Write("Your Selection: ");
				string selection = Console.ReadLine();
				switch (selection)
				{
					case "1":
						AllStudents();
						break;

					case "2":
						StudentsByBranch();
						break;

					case "3":
						StudentsByGender();
						break;
					case "4":
                        ListByDate();
						break;
					case "5":
						ListByCity();
						break;

					case "6":
						ShowStudentNotes();
						break;

					case "7":
						BooksOfTheStudent();
						break;

					case "8":
						MostSucc5();
						break;

					case "9":
						UnSucc3();
						break;

					case "10":
						SuccInBranch();
						break;

					case "11":
						UnSuccInBranch();
						break;

					case "12":
						StudentsAve();
						break;
					case "13":
						AverageOfBranch();
						break;
					case "14":
						LastBook();
						break;




                    case "15":
						AddStudent();
						break;
					case "18":
						AddAdress();
						break;

					case "20":
						AddNotes();
						break;



				}
			}
		}
		static void AllStudents()
		{
			Tools.ListByNumber(MySchool.Students);
		}
		static void StudentsByBranch()
		{
			Tools.ListByBranch(MySchool.Students);
		}
		static void StudentsByGender()
		{
			Tools.ListByGender(MySchool.Students);
		}
		static void ListByDate()
		{
            DateTime parsedDate;
            while (true)
			{
                Console.WriteLine();
				Console.Write("After which date would you like to list students: ");
				string date = Console.ReadLine();
			
				if (DateTime.TryParse(date, out parsedDate))
				{
					break;
				
				} else
				{
					Console.WriteLine("Something is wrong.Please, try again...");
				}
				Console.WriteLine(parsedDate);
			}
			Tools.ListTitle();
            List<Student> OrderedList = MySchool.Students.Where(a => a.date > parsedDate).ToList();
			Tools.ListItem(OrderedList);
		}
		static void ListByCity()
		{
			Console.WriteLine("5-List Students by City --------------------------------------------");
			Tools.ListTitle();
			List<Student> OrderedList = new List<Student>();

			OrderedList = MySchool.Students.OrderBy(a => a.adress.city).ToList();

			Tools.ListItem(OrderedList);

		}
		static void ShowStudentNotes()
		{
			int number = Tools.TakeStudentNumber("Öğrencinin numarası: ", MySchool.Students);
			Console.WriteLine("Lesson Name".PadRight(25) + "Note");
			Console.WriteLine("-----------------------------");
			Student std = MySchool.Students.Where(a => a.no == number).FirstOrDefault();
			foreach (LessonNotes item in std.LessonNotesList)
			{
                Console.WriteLine(item.lessonName.PadRight(25) + item.note);	
            }
		}
        static void MostSucc5()
        {
            Console.WriteLine("8-Most Succesfull 5 Students -----------------------------------");
            Console.WriteLine();
            List<Student> OrderedList = MySchool.Students.OrderByDescending(x => x.LessonNotesList.FirstOrDefault().note).Take(5).ToList();

            Console.WriteLine("Branch".PadRight(15) + "No".PadRight(5) + "Name Surname".PadRight(25) + "Note".PadRight(10) + "Number of Books".PadRight(25));
            Console.WriteLine("---------------------------------------------------------------------------");

            foreach (Student item in OrderedList)
            {
                Console.WriteLine(item.branch.PadRight(15) + Convert.ToString(item.no).PadRight(5) + (item.name + " " + item.surname).PadRight(25) +
                                  Convert.ToString(item.LessonNotesList.FirstOrDefault().note).PadRight(10) + Convert.ToString(item.Books.Count()).PadRight(25).PadLeft(30));
            }
            Console.WriteLine();
        }
		static void StudentsAve()
		{
			Console.WriteLine("12-Show Average of Students Average----------------------------------");
			int number = Tools.TakeNumber("Student's Number: ");
			Console.WriteLine();
			bool a = true;

			while (a)
			{
                foreach (var item in MySchool.Students)
                {
                    if (item.no == number)
                    {
                        Console.WriteLine("Student's Name & Surname: " + item.name + " " + item.surname);
                        Console.WriteLine("Student's Branch: " + item.branch);
                        Console.WriteLine();
						Console.WriteLine();
						MySchool.GetAverage(number);
						a = false;
					}
                }
            }
			


		}
		static void AverageOfBranch()
		{
            Console.WriteLine("13 - List Average of Branch-------------------------------------");
            string selection = Tools.TakeBranch("Select a Branch (A/B): ");
            double ave = MySchool.Students.Where(a => a.branch.ToUpper() == selection).Average(a => a.Average);
			Console.WriteLine();
			Console.WriteLine($"Average of {selection} branch: " + ave);
			Console.WriteLine();
		}
		static void LastBook()
		{

			Console.WriteLine("14 - The Last Book Readen by Student ----------------------------");
			int number = Tools.TakeNumber("Student's Number: ");
			string lastBook = MySchool.Students.Where(a => a.no == number).FirstOrDefault().Books.Last();
			Console.WriteLine(lastBook);



		}



		static void UnSucc3()
		{
            Console.WriteLine("9-Most Unsuccesfull 3 Students -----------------------------------");
            Console.WriteLine();
            Console.WriteLine("Branch".PadRight(15) + "No".PadRight(5) + "Name Surname".PadRight(25) + "Note".PadRight(10) + "Number of Books".PadRight(25));
            Console.WriteLine("---------------------------------------------------------------------------");

            List<Student> OrderedList = MySchool.Students.OrderBy(a => a.LessonNotesList.FirstOrDefault().note).Take(3).ToList();
			foreach (var item in OrderedList)
			{
				Console.WriteLine(item.branch.PadRight(15)+ Convert.ToString(item.no).PadRight(5)+(item.name + " " + item.surname).PadRight(25)
					+ Convert.ToString(item.LessonNotesList.FirstOrDefault().note).PadRight(10)  + Convert.ToString(item.Books.Count()).PadRight(25));
			}
			Console.WriteLine();	
		}
		static void SuccInBranch()
		{
            Console.WriteLine("9-Most Succesfull Student in Branch -----------------------------------");
            Console.WriteLine();
			string selection = Tools.TakeString("Which Branch Do You Want to List (A/B): ");
			Console.WriteLine();

			List<Student> OrderedList = new List<Student>();
			if(selection.ToUpper() == "A")
			{
                OrderedList = MySchool.Students.Where(a => a.branch.ToUpper() == "A").OrderByDescending(a => a.LessonNotesList.FirstOrDefault().note).Take(1).ToList();
            } else if(selection.ToUpper() == "B")
			{
                OrderedList = MySchool.Students.Where(a => a.branch.ToUpper() == "B").OrderByDescending(a => a.LessonNotesList.FirstOrDefault().note).Take(1).ToList();
            } 

            Console.WriteLine("Branch".PadRight(15) + "No".PadRight(5) + "Name Surname".PadRight(25) + "Note".PadRight(10) + "Number of Books".PadRight(25));
            Console.WriteLine("---------------------------------------------------------------------------");

			foreach (var item in OrderedList)
			{
				Console.WriteLine(item.branch.PadRight(15) +item.no.ToString().PadRight(5) + (item.name + " "+ item.surname).PadRight(25)
				+ Convert.ToString(item.LessonNotesList.FirstOrDefault().note).PadRight(10) + Convert.ToString(item.Books.Count()).PadRight(25));
			}
			Console.WriteLine();
		}
		static void UnSuccInBranch()
		{
			Console.WriteLine("11 - Most Succesfull Students in a Branch: ");
			string selection = Tools.TakeBranch("Branch You Want to List (A/B):");
			List<Student> OrderedList = new List<Student>();

			if(selection.ToUpper() == "A")
			{
			OrderedList = MySchool.Students.Where(a => a.branch.ToUpper() == "A").OrderBy(a => a.LessonNotesList.FirstOrDefault().note).Take(3).ToList();
			} else
			{
				OrderedList = MySchool.Students.Where(a => a.branch.ToUpper() == "B").OrderBy(a => a.LessonNotesList.FirstOrDefault().note).Take(3).ToList();
			}
			Console.WriteLine();

			Console.WriteLine("Branch".PadRight(15) + "No".PadRight(5) + "Name Surname".PadRight(25) + "Note".PadRight(10) + "Number of Books".PadRight(25));
            Console.WriteLine("---------------------------------------------------------------------------");
			foreach (var item in OrderedList)
			{
				Console.WriteLine(item.branch.PadRight(15) + item.no.ToString().PadRight(5) + (item.name + " " + item.surname).PadRight(25) +
                item.LessonNotesList.FirstOrDefault().note.ToString().PadRight(10) + item.Books.Count().ToString().PadRight(10));	
			}
			Console.WriteLine();	






		}
        static void AddStudent()
		{
            int number;

            Console.WriteLine("15-Add Student -----------------------------------------------------");

            while (true)
            {
				number = Tools.TakeNumber("Number of Student: ");
				string name = Tools.TakeString("Student's Name: ");
				string surname = Tools.TakeString("Student's Surname: ");
				DateTime date = Tools.TakeBirthday("Birthday of Student: ");
				string gender = Tools.TakeGender("Gender of Student (F/M): ");
				string branch = Tools.TakeBranch("Branch of Student (A/B): ");
				Student o = new Student(name, surname, number, date, gender, branch);
		
			}
        }
		static void AddAdress()
		{

			Console.WriteLine("18-Add Student's Adress ------------------------------------------");
			int number = Tools.TakeNumber("Student's No: ");
			Student student = MySchool.Students.Where(a => a.no == number).FirstOrDefault();
			Console.WriteLine("");
			Console.WriteLine("Student Name Surname: " + student.name+ " " + student.surname);
			Console.WriteLine("Student Branch: " + student.branch);
			Console.WriteLine();
			Console.Write("City: ");
			string city = Console.ReadLine();
            Console.Write("District: ");
			string district = Console.ReadLine();



			Adress adr = new Adress(city,district);

			student.adress = adr;


	


            Console.WriteLine("Adress was added/updated");
		}
		static void BooksOfTheStudent()
		{
			while (true)
			{
				Console.WriteLine("7-List All Books Readen by Student");
				Console.WriteLine("---------------------------------------");
				int number = Tools.TakeNumber("Student's number: ");
				Console.WriteLine();

                Console.WriteLine("Books Student Read");
                Console.WriteLine("--------------------");
                foreach (string item in MySchool.ListBooks(number))
				{
					if (MySchool.ListBooks(number).Count() > 0)
					{
						Console.WriteLine(item);				
					}
					else
					{
						Console.WriteLine("There is no book in this list...");
					}
				}
				Console.WriteLine();
				break;
			}
		}
		static void AddNotes()
		{
			Console.WriteLine("20-Add Notes ----------------------------------------------------------");
			int number = Tools.TakeNumber("Student's Number: ");
			Student std = MySchool.Students.Where(a => a.no == number).FirstOrDefault();
			Console.WriteLine("Name: " + std.name);
			Console.WriteLine("Branch: " + std.branch);
			Console.WriteLine();

            string lessonName = Tools.TakeString("Name of Lesson : ");

            int noteNumber = Tools.TakeNumber("How Many Notes Do You Want to Add: ");
			double notesAverage = Tools.Average(noteNumber);
			LessonNotes note = new LessonNotes(lessonName,notesAverage );
			std.LessonNotesList.Add(note);
			Console.WriteLine();			
			Console.WriteLine("Notes Were Added");






		}
	
	}
}


