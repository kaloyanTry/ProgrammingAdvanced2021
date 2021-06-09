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

            if (Capacity <= Count)
            {
                return "No seats in the classroom";   
            }

            students.Add(student);
            return $"Added student {student.FirstName} {student.LastName}";
            
        }

        public string DismissStudent(string firstName, string lastName)
        {
            Student student = students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);

            if (student == null)
            {
                return "Student not found";
            }

            students.Remove(student);
            return $"Dismissed student {student.FirstName} {student.LastName}";
        }

        public string GetSubjectInfo(string subject)
        {
            StringBuilder sb = new StringBuilder();
            
            List<Student> studentsSubject = students.Where(s => s.Subject == subject).ToList();

            if (studentsSubject.Count != 0)
            {
                sb.AppendLine($"Subject: {subject}");
                sb.AppendLine("Students:");
                foreach (var stu in studentsSubject)
                {
                    sb.AppendLine($"{stu.FirstName} {stu.LastName}");
                }
            }
            else
            {
                sb.AppendLine("No students enrolled for the subject");
            }

            return sb.ToString().Trim();
        }

        public int GetStudentsCount() => students.Count;

        public Student GetStudent(string firstName, string lastName)
        {
            Student student = students.Find(s => s.FirstName == firstName && s.LastName == lastName);

            return student;
        }
    }
}
