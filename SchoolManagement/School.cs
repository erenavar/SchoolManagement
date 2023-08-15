using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolManagement
{
    public class School
    {
        public List<Student> Students = new List<Student>();
        //public School()
        //{
        //}

        public void AddStudent(string name, string surname, int no, DateTime date, string gender, string branch)
        {
            Students.Add(new Student(name, surname, no, date, gender, branch));
        }

        public void AddAdress(int no, string city, string district)
        {
            Student studentAdr = Students.Where(a => a.no == no).FirstOrDefault();
            Adress adr = new Adress(city, district);
            studentAdr.adress = adr;

        }

        public List<string> ListBooks(int number)
            {
                List<string> books;
                Student s = this.Students.Where(a => a.no == number).FirstOrDefault();
                if (s != null && s.Books != null)
                {
                    books = s.Books.ToList();
                    return books;
                }

                return null;

            
   
        }

        public void AddFakeNotes(int number,string lessonName,int note)
        {
            Student std = Students.Where(a => a.no == number).FirstOrDefault();                         
             LessonNotes lesson = new LessonNotes(lessonName, note);
             std.LessonNotesList.Add(lesson);           
        }

        public void AddBooks(string[] arr,List<Student> list)
        {
            Random rnd = new Random();
            

            for (int i = 0; i < list.Count; i++)
            {
                int number = rnd.Next(0, arr.Length);
                int number2 = rnd.Next(0, arr.Length);
                list[i].Books.Add(arr[number]);
                list[i].Books.Add(arr[number2]);

            }
        }

        public void GetAverage(int no)
        {
            double sum = 0, average = 0;

            Student std = this.Students.Where(a => a.no == no).FirstOrDefault();
            foreach (var item in std.LessonNotesList)
            {
                sum += item.note;
            }
            average = sum / std.LessonNotesList.Count();
            Console.WriteLine("Average of Student: " + average);
        }

      
    }
}

