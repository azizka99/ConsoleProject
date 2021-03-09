using System;
using System.Collections.Generic;
using System.Text;

namespace First_Project
{
    interface IHumanResourceManager
    {
        public Department[] Departments { get; }

        public void AddDepartament(string name, int workerlimit, int salarylimit);

        public Department[] GetDepartments();

        public bool IsExistDepartmentByName(string name);

        public Employee[] GetEmployeeByDepartmentsName(string name);

        public void AddEmployee(string fullname, string position, int salary, string departmentsname);
        public void EditDepartment(string departmentsname, string departmentsnewname, int newworkerlimit, int newsalarylimit);

        public void EditEmployee(string employeesno, int employeesnewsalary, string employeesnewposition);
        public bool IsExistEmployeeByNO(string employeesno);
        public Employee FindEmployeeByNo(string employeesno);
        public Employee[] GetAllEmployees();
        public void DeleteEmployeesFromDepartmentByNo(string departmentsname, string employeesno);
    }
}
