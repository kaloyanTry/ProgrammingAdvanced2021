using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            if (Capacity > students.Count)
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
            Student student = students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);

            if (student == null)
            {
                return $"Student not found";
            }
            else
            {
                students.Remove(student);
                return $"Dismissed student {firstName} {lastName}";          
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
                    sb.AppendLine(stu.FirstName + " " + stu.LastName);
                }        
            }
            else
            {
                sb.AppendLine("No students enrolled for the subject");
            }

            return sb.ToString().Trim();
        }

        public int GetStudentsCount()
        {
            return students.Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            return students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);
        }
    }
}
