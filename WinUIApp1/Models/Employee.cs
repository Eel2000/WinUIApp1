﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinUIApp1.Models
{
    public class Employee
    {
        public Employee(string firstName, string lastName, string dep, bool isDepChef, DateTime birthDay, long iD)
        {
            FirstName = firstName;
            LastName = lastName;
            Dep = dep;
            IsDepChef = isDepChef;
            BirthDay = birthDay;
            ID = iD;
        }

        public long ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Dep { get; set; }
        public bool IsDepChef { get; set; }
        public DateTime BirthDay { get; set; }
        public string Picture { get; set; }
    }
}
