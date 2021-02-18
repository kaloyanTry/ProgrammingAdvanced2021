using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;

        public Classroom(int capacity)
        {
            Capacity = capacity;
            students = new List<Student>();             
        }
        public int Capacity { get; set; }
        public int Count => students.Count;

        public string RegisterStudent(Student student)
        {          
            if (Capacity > 0 && Capacity > students.Count)
            {
                students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            else
            {
                return "No seats in the classroom";
            }
        }

        public string DismissStudent(string firstName, string lastName)
        {
            Student student = students.Where(s => s.FirstName == firstName && s.LastName == lastName).FirstOrDefault();
            if (student != null)
            {
                students.Remove(student);
                return $"Dismissed student {student.FirstName} {student.LastName}";
            }
            else
            {
                return "Student not found";
            }
        }

        public string GetSubjectInfo(string subject)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Subject: {subject}");

            if (students.Any(s => s.Subject == subject))
            {
                sb.AppendLine("Students:");
                foreach (var stu in students.Where(s => s.Subject == subject))
                {
                     sb.AppendLine($"{stu.FirstName} {stu.LastName}");
                }
            }
            else
            {
                sb.Append("No students enrolled for the subject");
            }

            return sb.ToString().TrimEnd();
        }

        public int GetStudentsCount()
        {
            return students.Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            return students.Where(s => s.FirstName == firstName && s.LastName == lastName).FirstOrDefault();
        }
    }
}
