    using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolManagement
{
	public class Tools
	{
		public Tools()
		{
		}

		public static string UpperFirstLetter(string text)
		{
			return text.Substring(0, 1).ToUpper() + text.Substring(1).ToLower();
		}

		public static int TakeNumber(string message)
		{
			int number;
			while (true)
			{
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out number)){
                    return number;
                }
				else
				{
					Console.WriteLine("Please try again...");
				}

            }
		}

        public static string TakeString(string message)
		{
            int number;
            while (true)
			{
				
				Console.Write(message);
				string text = Console.ReadLine();
				if(int.TryParse(text, out number))
				{
					Console.WriteLine("Something is wrong.Please, try again...");
				} else 
				{
					return text;
				}
			}
		}

        public static DateTime TakeBirthday(string message)
        {
            DateTime date;
            while (true)
            {
                Console.Write(message);
                bool a = DateTime.TryParse(Console.ReadLine(), out date);
                if (!a)
                {
                    Console.WriteLine("Something is wrong.Please try again...");
                }
                else
                {
                    return date;
                }
            }
       
        }

        public static string TakeGender(string message)
        {
            bool a;
            string gender;
            while (true)
            { 
                    Console.Write(message);
                    gender = Convert.ToString(Console.ReadLine());
                    if(gender.ToUpper() == "M" || gender.ToUpper() == "F")
                {
                    return gender;
                     
                } else
                {
                    Console.WriteLine("Something is wrong.Please try again...");
                }
            }
        }

        public static string TakeBranch(string message)
        {
            string branch;
            while (true)
            {
                Console.Write(message);
                branch = Convert.ToString(Console.ReadLine());
                if(branch.ToUpper() =="A" || branch.ToUpper() == "B")
                {
                    return branch.ToUpper();

                } else
                {
                    Console.WriteLine("Something is wrong.Please try again...");
                    Console.WriteLine();
                }
            }
        }

		public static void ListByNumber(List<Student> List )
		{
			Console.WriteLine("Branch".PadRight(15) + "No".PadRight(10)+"Name".PadRight(10)+ "Surname".PadRight(10) +"Average".PadRight(15) + "Read Book".PadRight(10));
			Console.WriteLine("--------------------------------------------------------------------");

			List<Student> OrderedList = new List<Student>();
			OrderedList = List.OrderBy(a => a.no).ToList();			

           if(List.Count > 0)
			{
				foreach (Student item in OrderedList)
                {
                    Console.WriteLine(item.branch.PadRight(15) + item.no.ToString().PadRight(10) + item.name.PadRight(10) + item.surname.PadRight(10)+ item.Books.Count.ToString());
                }
            }else
				Console.WriteLine("**********There is no student**********");
				Console.WriteLine();
			}

        public static void ListByBranch(List<Student> List)
        {
            bool a = true;
            List<Student> OrderedList = new List<Student>();
            while (a)
			{
                Console.WriteLine();
                //Console.Write("Type the branch you want to list: ");
                //string selection = Convert.ToString(Console.ReadLine());
                string selection = TakeBranch("Type the branch you want to list: ");

                if (List.Count > 0 && selection.ToUpper() == "A")
                {
                    OrderedList = List.Where(a => a.branch.ToString().ToUpper() == "A").ToList();
                    Tools.ListTitle();
                    Tools.ListItem(OrderedList);
                    a = false;
                    
                }
                else if (List.Count > 0 && selection.ToUpper() == "B")
                {
                    OrderedList = List.Where(a => a.branch.ToString().ToUpper() == "B").OrderBy(a=>a.no).ToList();
                    Tools.ListTitle();
                    Tools.ListItem(OrderedList);
                    a = false;      
                }else if (List.Count == 0) 
                {
                    Console.WriteLine();
                    Console.WriteLine("There is no student");
                    a = false;
                }
                else
                {
                    Console.WriteLine("Something is wrong.Please, try again.");
                }
               }         
        }

        public static void ListByGender(List<Student> List)
        {
            while (true)
            {
                Console.WriteLine();
                Tools.ListTitle();
                Console.WriteLine("--------------------------------------------------------------------");

                List<Student> OrderedList = new List<Student>();


                Console.Write("Which Gender Do You Want to List (F/M): ");
                string selection = Convert.ToString(Console.ReadLine());

                if (List.Count() > 0 && selection.ToUpper() == "F")
                {
                    OrderedList = List.Where(a => a.gender.ToUpper() == "F").ToList();
                    ListItem(OrderedList);
                    break;

                } else if(List.Count > 0 && selection.ToUpper() == "M")
                {
                    OrderedList = List.Where(a => a.gender.ToUpper() == "M").ToList();
                    ListItem(OrderedList);
                    break;
                }else if( List.Count == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("There is no student");
                } else
                {
                    Console.WriteLine();
                    Console.WriteLine("Something is wrong.Please try again...");
                }
            }
            
        }

        public static void ListTitle()
        {
       
            Console.WriteLine("Branch".PadRight(15) + "No".PadRight(10) + "Name".PadRight(10) + "Surname".PadRight(10) +"City".PadRight(15) +"Average".PadRight(15) + "Read Book".PadRight(10));

        }

        public static void ListItem(List<Student> List)
        {
            
            foreach (Student item in List)
            {
                Console.WriteLine(item.branch.PadRight(15) + item.no.ToString().PadRight(10) + item.name.PadRight(10) + item.surname.PadRight(10)+item.adress.city.PadRight(15) + item.Books.Count.ToString());
            }
            Console.WriteLine();

        }

        public static double Average(int numberNotes)
        {
            int note;
            double total = 0;
            for (int i = 0; i < numberNotes; i++)
            {
             
                Console.Write($"{i + 1}. note: ");
                if(int.TryParse(Console.ReadLine(),out note) && note <= 100 && note >= 0){
                    total = (total + note);
                } else
                {
                    Console.WriteLine("Please,Text number.");
                    i--;
                }
            }
            return total / numberNotes;
        }

        public static int TakeStudentNumber(string message,List<Student> list)
        {
            bool a = true;
    

            while (a)
            {
                int number = TakeNumber(message);
                foreach (Student item in list)
                {
                    if (item.no == number)
                    {
                        a = false;
                        return number;              
                    }                  
                }
                if (a)
                {
                    Console.WriteLine("There is no student with this number. Please control your number...");
                }
            }
            
            


            return 1;
        }

        public static string TakeSelection()
        {
            bool a = true;
            string selection = "";
            while (a)
            {
                Console.Write("Your Selection: ");
                selection = Console.ReadLine();

                try
                {
                    if (Convert.ToInt32(selection) < 21 && Convert.ToInt32(selection) > 0 || selection.ToLower() == "exit")
                    {
                        selection = selection is string ? selection : Convert.ToString(selection);
                        a = false;
                    }
                 
                }
                catch (Exception ex)
                {
                    Console.WriteLine("There is something wrong about your selection.Please control it and try again...");

                }
            }
            
          return selection;
        }
    }
}

    






	

