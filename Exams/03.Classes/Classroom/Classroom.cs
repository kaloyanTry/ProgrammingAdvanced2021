using System;
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
            if (Capacity > Count)
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
                return "Student not found";
            }
            else
            {
                students.Remove(student);
                return $"Dismissed student {firstName} {lastName}";
            }
        }

        public string GetSubjectInfo(string subject)
        {
            List<Student> entrolledStudents = new List<Student>();

            foreach (var stu in students.Where(s => s.Subject == subject))
            {
                entrolledStudents.Add(stu);
            }

            if (entrolledStudents.Any())
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine($"Subject: {subject}");
                sb.AppendLine("Students:");

                foreach (var student in entrolledStudents)
                {
                    sb.AppendLine($"{student.FirstName} {student.LastName}");
                }

                return sb.ToString().Trim();

                
            }
            else
            {
                return "No students enrolled for the subject";
            }
        }

        public int GetStudentsCount()
        {
            return students.Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            Student student = students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);

            return student;
        }
    }
}
