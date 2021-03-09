using System;
using System.Collections.Generic;
using System.Text;

namespace First_Project
{
    class Employee
    {
        public  string No;
        
        private static int _counter = 1000;
        private int _localCounter;
        public string Fullname;
        public string Birthdate;    
        private string _position;
        public string DepartmentsName;
        
        public string Position
        {
            get { return _position; }
            set
            {
                if (value.Length >= 2)
                {
                    _position = value;
                }
            }
        }

        private int _salary;
        public int Salary
        {
            get { return _salary; }
            set
            {
                if (value >= 250)
                {
                    _salary = value;
                }
            }
        }

        
        public Employee(string fullname, string position, int salary, string department) 
        {
            Fullname = fullname;
            Position = position;
            Salary = salary;
            DepartmentsName = department;
            
            _localCounter = ++_counter;
            No = DepartmentsName.Substring(0, 2).ToUpper() + Convert.ToString(_localCounter);
        }

    }
}
