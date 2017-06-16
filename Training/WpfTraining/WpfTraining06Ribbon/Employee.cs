using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace WpfTraining06Ribbon
{
    public class Employee
    {
        private int employeeid;
        public int EmployeeID
        {
            get { return employeeid; }
            set { employeeid = value; }
        }

        private string firstname;
        public string FirstName
        {
            get { return firstname; }
            set { firstname = value; }
        }

        private string lastname;
        public string LastName
        {
            get { return lastname; }
            set { lastname = value; }
        }

        private string title;
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private DateTime birthdate;
        public DateTime BirthDate
        {
            get { return birthdate; }
            set { birthdate = value; }
        }

        private Image photo;
        public Image Photo
        {
            get { return photo; }
            set { photo = value; }
        }
    }
}
