using System;
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

        public Employee(long iD, string firstName, string lastName, string dep, bool isDepChef, DateTime birthDay, string picture)
        {
            ID = iD;
            FirstName = firstName;
            LastName = lastName;
            Dep = dep;
            IsDepChef = isDepChef;
            BirthDay = birthDay;
            Picture = picture;
        }

        public long ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Dep { get; set; }
        public bool IsDepChef { get; set; }
        public DateTime BirthDay { get; set; }
        public string Picture { get; set; }
        public string Telephone
        {
            get
            {
                var codeNet = new string[] { "89", "99", "97", "91", "82", "81", "85", "84" };
                var rnd = new Random();
                var code = rnd.Next(0, 7);
                return $"243{codeNet[code]}{rnd.Next(1000000, 9999999)}";
            }
        }
        public string EmailAdresse
        {
            get
            {
                return $"{FirstName}.{LastName}@gmail.com".ToLower();
            }
        }
        public string City { get; set; }
        public string Adresse { get; set; }
        public string Social { get; set; }
        public string HighSchool { get; set; }
        public DateTime HighSchoolStartDate { get; set; }
        public DateTime HighSchoolEndDate
        {
            get
            {
                var rnd = new Random();
                return HighSchoolStartDate.AddYears(rnd.Next(1, 6));
            }
        }
        public string UniversityStudies { get; set; }
        public DateTime UniversityStudiesStart { get; set; }
        public DateTime UniversityStudiesEnd
        {
            get
            {
                var rnd = new Random();
                return UniversityStudiesStart.AddYears(rnd.Next(1, 6));
            }
        }


        public string Skills { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
