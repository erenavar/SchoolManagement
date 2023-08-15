using System;
namespace SchoolManagement
{
	public class LessonNotes
	{

		public string lessonName;
        public double note;

		public LessonNotes(string lessonName,double note)
		{

			this.lessonName = lessonName;
			this.note = note;
		}
	}

	public enum Lesson {Math = 1,English = 2, History = 3 }
}

