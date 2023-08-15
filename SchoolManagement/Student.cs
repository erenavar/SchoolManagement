using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolManagement
{
	public class Student
	{
	
		public string name;
		public string surname;
        public int no;
        public string branch;
		public LessonNotes lessons;
		public DateTime date;
		public Adress adress;
		public string gender;
		public List<string> Books = new List<string>();
		public List<LessonNotes> LessonNotesList = new List<LessonNotes>();




        public Student(string name,string surname,int no,DateTime date,string gender,string branch)
		{
			this.name = name;
			this.surname = surname;
			this.no = no;
			this.date = date;
			this.gender = gender;
			this.branch = branch;
		}

		public double Average
		{
			get
			{
				double ave = this.LessonNotesList.Sum(a => a.note);
				if(ave == 0)
				{
					return 0;
				}
				else
				{
					return ave / this.LessonNotesList.Count();
				}
			
			}

		}

		
	}
}

