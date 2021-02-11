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

        public int Count => data.Count;

        public void Add(Employee employee)
        {
            data.Add(employee);
        }

        public bool Remove(string name)
        {
            Employee employee = data.FirstOrDefault(e => e.Name == name);
            
            if (employee == null)
            {
                return false;
            }
            else
            {
                data.Remove(employee);
                return true;
            }
        }
        public Employee GetOldestEmployee()
        {
            return data.OrderByDescending(e => e.Age).FirstOrDefault();
        }

        public Employee GetEmployee(string name) => data.FirstOrDefault(e => e.Name == name);

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"employees working at bakery {Name}:");
            foreach (Employee employee in data)
            {
                sb.AppendLine(string.Join(Environment.NewLine, employee));
            }

            return sb.ToString().Trim();
        }
    }
}
