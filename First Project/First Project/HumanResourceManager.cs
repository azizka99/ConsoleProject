using System;
using System.Collections.Generic;
using System.Text;

namespace First_Project
{
    class HumanResourceManager : IHumanResourceManager
    {
        public Department[] Departments { get => this._departments; }
        private Department[] _departments;

        public HumanResourceManager()
        {
            this._departments = new Department[0];
        }
        public  void AddDepartament(string name, int workerlimit, int salarylimit)
        {
            Department department = new Department(name, workerlimit, salarylimit);
            Array.Resize(ref _departments, _departments.Length + 1);
            this._departments[_departments.Length - 1] = department;
        }

        public Department[] GetDepartments()
        {
            return _departments;
        }

        public bool IsExistDepartmentByName(string name)
        {
            foreach (var item in _departments)
            {
                if (item.Name == name)
                {
                    return true;
                }
            }
            return false;
        }

        public Department FindDepartmentByName(string name) 
        {
            foreach (var item in this._departments)
            {
                if (item.Name == name)
                {
                    return item;
                }
            }
            return null;
        }

        public Employee[] GetEmployeeByDepartmentsName(string name)
        {
            Department department = FindDepartmentByName(name);
            if(department != null)
            {
                return department.Employees;
            }
            return null;
        }

        public void AddEmployee(string fullname, string position, int salary, string departmentsname)
        {
            Department department = FindDepartmentByName(departmentsname);
            if (department  != null &&  department.SalaryLimit >= salary && department.WorkerLimit >= department.Employees.Length)
            {
                Employee employee = new Employee(fullname, position, salary, departmentsname);
                Array.Resize(ref department.Employees, department.Employees.Length + 1);
                department.Employees[department.Employees.Length - 1] = employee;
            }
        }

        public void EditDepartment(string departmentsname, string departmentsnewname, int newworkerlimit, int newsalarylimit)
        {
            if (!IsExistDepartmentByName(departmentsnewname))
            {
                foreach (var item in this._departments)
                {
                    if (item.Name == departmentsname)
                    {
                        item.Name = departmentsnewname;
                        item.WorkerLimit = newworkerlimit;
                        item.SalaryLimit = newsalarylimit;
                    }
                }
            }
        }

        public Employee[] GetAllEmployees()
        {
            Employee[] allemployees = new Employee[0];
            foreach (var department in this._departments)
            {
                foreach (var employee in department.Employees)
                {
                    Array.Resize(ref allemployees, allemployees.Length + 1);
                    allemployees[allemployees.Length - 1] = employee;
                }
            }
            return allemployees;
        }

        public void EditEmployee(string employeesno, int employeesnewsalary, string employeesnewposition)
        {
            FindEmployeeByNo(employeesno).Salary = employeesnewsalary;
            FindEmployeeByNo(employeesno).Position = employeesnewposition;
        }

        public bool IsExistEmployeeByNO(string employeesno)
        {
            foreach (var item1 in _departments)
            {
                foreach (var item2 in item1.Employees)
                {
                    if (item2.No == employeesno)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public Employee FindEmployeeByNo(string employeesno)
        {
            foreach (var items in _departments)
            {
                foreach (var item1 in items.Employees)
                {
                    if(item1.No == employeesno)
                    {
                        return item1;
                    }
                }
            }
            return null;
        }

        public void DeleteEmployeesFromDepartmentByNo(string departmentsname, string employeesno)
        {
            Employee[] employees = FindDepartmentByName(departmentsname).Employees;
            int indexofemployees = Array.IndexOf(employees, FindEmployeeByNo(employeesno));

            for (int i = indexofemployees; i + 1 < employees.Length; i++)
            {
                
                employees[i] = employees[i + 1];
            }
            Array.Resize(ref employees, employees.Length - 1);
            FindDepartmentByName(departmentsname).Employees = employees;
        }
    }
}
