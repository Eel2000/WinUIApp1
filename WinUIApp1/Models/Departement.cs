using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinUIApp1.Models
{
    public class Departement
    {
        public Departement(string name, string description, int employeNumber, DateTime creationDate)
        {
            Name = name;
            Description = description;
            EmployeNumber = employeNumber;
            CreationDate = creationDate;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public int EmployeNumber { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
