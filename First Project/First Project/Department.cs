using System;
using System.Collections.Generic;
using System.Text;

namespace First_Project
{
    class Department
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (value.Length >= 2)
                {
                    _name = value;
                }
            }
        }
        public int WorkerLimit;
        public int SalaryLimit;
        public Employee[] Employees; 

        public Department(string name, int workerlimit, int salarylimit)
        {
            this.Name = name;
            this.WorkerLimit = workerlimit;
            this.SalaryLimit = salarylimit;
            this.Employees = new Employee[0];
           
        }

        


    }
}
