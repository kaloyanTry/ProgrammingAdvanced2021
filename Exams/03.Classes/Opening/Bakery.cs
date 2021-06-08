using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        private List<Employee> data;

        public Bakery(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Employee>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }

        public void Add(Employee employee)
        {
            if (data.Count < Capacity)
            {
                data.Add(employee);
            }
        }

        public bool Remove(string name)
        {
            Employee employee = data.Find(e => e.Name == name);

            if (data.Contains(employee))
            {
                data.Remove(employee);
                return true;
            }

            return false;
        }

        public Employee GetOldestEmployee()
        {
            Employee employee = data.OrderByDescending(e => e.Age).FirstOrDefault();

            return employee;
        }

        public Employee GetEmployee(string name)
        {
            Employee employee = data.FirstOrDefault(e => e.Name == name);

            return employee;
        }

        public int Count => data.Count;

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Employees working at Bakery {Name}:");

            foreach (var emp in data)
            {
                sb.AppendLine(emp.ToString());
            }

            return sb.ToString();
        }
    }
}
