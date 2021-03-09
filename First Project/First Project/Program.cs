using System;

namespace First_Project
{
    class Program
    {
        private const int MIN_SALARY = 250;
        private static Employee[] ArrayEmployee = new Employee[0];
        static void Main(string[] args)
        {
            HumanResourceManager humanResourceManager = new HumanResourceManager();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1.1 - Departameantlerin siyahisini gostermek");
                Console.WriteLine("1.2 - Departament yaratmaq");
                Console.WriteLine("1.3 - Departmanetde deyisiklik etmek");
                Console.WriteLine("2.1 - Iscilerin siyahisini gostermek");
                Console.WriteLine("2.2 - Departamentdeki iscilerin siyahisini gostermek");
                Console.WriteLine("2.3 - Isci elave etmek");
                Console.WriteLine("2.4 - Isci uzerinde deyisiklik etmek");
                Console.WriteLine("2.5 - Departamentden isci silinmesi");
                Console.WriteLine("5 - Programdan cixmaq");
                string menu = Console.ReadLine();
                switch (menu)
                {
                    
                    case "1.1":
                        ShowDepartaments(humanResourceManager); 
                        break;
                    case "1.2":
                        AddDepartment(ref humanResourceManager);  
                        break;
                    case "1.3":
                        EditDepartment(ref humanResourceManager); 
                        break;
                    case "2.1":
                        ShowInfoAllEmployees(ref humanResourceManager); 
                        break;
                    case "2.2":
                        GetEmployeeByDepartmentsName(ref humanResourceManager); 
                        break;
                    case "2.3":
                        AddEmployee(ref humanResourceManager); 
                        break;
                    case "2.4":
                        EditEmployee(ref humanResourceManager); 
                        break;
                    case "2.5":
                        DeleteEmployeeFromDepartment(ref humanResourceManager);  
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Zehmet olmasa movcud variantlardan birini daxil edin...");
                        PressEnterToContinue();
                        break;
                }
            }

        }
        public static void AddEmployee(ref HumanResourceManager humanResourceManager) 
        {
            Console.Clear();
            if (humanResourceManager.GetDepartments().Length > 0)
            {
                Console.WriteLine("Daxil ede bileceyinis movcud departmentler: ");
                ShowDepartaments(humanResourceManager);
            }
            else
            {
                Console.WriteLine("Bazamizda ishcini daxil ede bileceyiniz hec bir department tapilmadi, xaish edirik yeni department yaradasiz...:)");
                PressEnterToContinue();
                return;
            }

            string fullname;
            string position;
            int salary;
            string departmentsName;
            while(true)
            {
                Console.Write("Fullname: ");
                fullname = Console.ReadLine();
                if (!String.IsNullOrWhiteSpace(fullname))
                {
                   
                    break;
                }
                Console.WriteLine("Duz Fullname yazin!");
            }
            while (true)
            {
                Console.Write("Position: ");
                position = Console.ReadLine();
                if (  !String.IsNullOrWhiteSpace(position) && position.Length >= 2 )
                {
                    break;
                }
                Console.WriteLine("Duz Position yazin! (Position 2 herfden chox olmalidir.)");
            }
            while (true)
            {
                Console.Write("Salary: ");
                
                if ( Int32.TryParse(Console.ReadLine(), out salary) &&  salary >= MIN_SALARY)
                {
                    break;
                }
                Console.WriteLine($"Salary {MIN_SALARY}-den ashaqi ola bilmez");
            }
            
            
             Console.Write("Departament: ");
             departmentsName = Console.ReadLine();
             if (!(humanResourceManager.IsExistDepartmentByName(departmentsName)) || String.IsNullOrWhiteSpace(departmentsName))
             {
                Console.WriteLine("Bele bir ad altinda departament yoxdu!");
                PressEnterToContinue();
                return;
             }
             humanResourceManager.AddEmployee(fullname, position, salary, departmentsName);
             PressEnterToContinue();
        }
        
       

        public static void ShowInfoAllEmployees(ref HumanResourceManager humanResourceManager )
        {
            
            Employee[] employees = humanResourceManager.GetAllEmployees();
            if (employees.Length != 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                foreach (var item in employees)
                {
                    Console.WriteLine($"Fullname: {item.Fullname} || Position: {item.Position} || Salary: {item.Salary} || Department's name: {item.DepartmentsName} || No: {item.No}");
                }
                Console.ResetColor();
                PressEnterToContinue();
                return;
            }
            Console.WriteLine("Bazada hec bir ishci yoxdur...:(");
            PressEnterToContinue();
        }

        public static void AddDepartment(ref HumanResourceManager humanResourceManager)
        {
            string name;
            int workerlimit;
            int salarylimit;
            while (true)
            {
                Console.Write("Name: ");
                name = Console.ReadLine();
                if (!String.IsNullOrWhiteSpace(name) && name.Length >= 2)
                {

                    break;
                }
                Console.WriteLine("Name bosh ve ya xud da iki herifden az ola bilmez!");
            }
            while (true)
            {
                Console.Write("Workerlimit: ");
                if (Int32.TryParse(Console.ReadLine(), out workerlimit))
                {
                    break;
                }
                Console.WriteLine("Workerlimit- ancaq ededden ibaret oa biler");
            }
            while (true)
            {
                Console.Write("SalaryLimit: ");
                if (Int32.TryParse(Console.ReadLine(), out salarylimit))
                {
                    break;
                }
                Console.WriteLine("Salarylimit- ancaq ededden ibaret oa biler");
            }
            humanResourceManager.AddDepartament(name, workerlimit, salarylimit);
            PressEnterToContinue();
        }

        public static void ShowDepartaments( HumanResourceManager humanResourceManager)
        {
            Department[] departments = humanResourceManager.GetDepartments();
            if (departments.Length > 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                foreach (var item in humanResourceManager.GetDepartments())
                {
                    Console.WriteLine($"Departament's name: {item.Name} || Workerlimit: {item.WorkerLimit} || Salarylimit: {item.SalaryLimit}");
                }
                Console.ResetColor();
                PressEnterToContinue();
                return;

            }
            Console.WriteLine("Hele hec bir departament yoxdur...:(");
            PressEnterToContinue();
        }

        

        public static void GetEmployeeByDepartmentsName(ref HumanResourceManager humanResourceManager) 
        {
            Console.Write("Departmentin adini daxil edin: ");
            string nameofdp = Console.ReadLine();
            if (!humanResourceManager.IsExistDepartmentByName(nameofdp))
            {
                Console.WriteLine("Bele Department yoxdu...:(");
                PressEnterToContinue();
                return;
            }
            if (humanResourceManager.GetEmployeeByDepartmentsName(nameofdp).Length == 0)
            {
                Console.WriteLine("Departamentde ishciler yoxdur...:(");
            }
            Console.ForegroundColor = ConsoleColor.DarkRed;
            foreach (var item in humanResourceManager.GetEmployeeByDepartmentsName(nameofdp))
            {
                Console.WriteLine($"Fullname: {item.Fullname} || Position: {item.Position} || Salary: {item.Salary} || {item.No}");
            }
            Console.ResetColor();
            PressEnterToContinue();
        }

       

        public static void EditDepartment(ref HumanResourceManager humanResourceManager)
        {
            Console.Write("Departmentin adini daxil edin: ");
            string dpname = Console.ReadLine();

            if (!humanResourceManager.IsExistDepartmentByName(dpname))
            {
                Console.WriteLine($"{dpname} -adli department movcud deyil.");
                PressEnterToContinue();
                return;
                
            }
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"Name: {humanResourceManager.FindDepartmentByName(dpname).Name}  Workerlimit: {humanResourceManager.FindDepartmentByName(dpname).WorkerLimit}  Salarylimit: {humanResourceManager.FindDepartmentByName(dpname).SalaryLimit}");
            Console.ResetColor();

            Console.WriteLine("Yeni departmentin melumatlarini daxil edin.");
            Console.Write("Name: ");
            string newdpname = Console.ReadLine();
            if (humanResourceManager.IsExistDepartmentByName(newdpname))
            {
                Console.WriteLine($"{newdpname} -adli department artiq movcuddur.");
                PressEnterToContinue();
                return;
            }
            int newWorkerlimit;
            Console.Write("Workerlimit: ");
            if(!Int32.TryParse(Console.ReadLine(), out newWorkerlimit))
            {
                Console.WriteLine("Workerlimit ancaq eded olmalidir;");
                PressEnterToContinue();
                return;
            }
            int newSalarylimit;
            Console.Write("Salarylimit: ");
            if (!Int32.TryParse(Console.ReadLine(), out newSalarylimit))
            {
                Console.WriteLine("Salarylimit ancaq eded olmalidir;");
                PressEnterToContinue();
                return;
            }

            humanResourceManager.EditDepartment(dpname, newdpname, newWorkerlimit, newSalarylimit);
            PressEnterToContinue();
        }

       
        public static void EditEmployee(ref HumanResourceManager humanResourceManager)
        {
            Console.Write("Uzerinde emeliyyat aparmaq istediyiviz ishcinin normesi: ");
            string employeeNo = Console.ReadLine();
            if (humanResourceManager.IsExistEmployeeByNO(employeeNo))
            {
                
                Console.Write($"{employeeNo}-li ishcinin yeni pozisiyasi:  ");
                string employees_new_position = Console.ReadLine();
                int employees_new_salary;
                
                Console.Write($"{employeeNo}-li ishcinin yeni salarysi:  ");
                while (!Int32.TryParse(Console.ReadLine(), out employees_new_salary))
                {
                    Console.WriteLine("Salary ancaq reqemden ibaret olmalidir...:(");
                    Console.Write($"{employeeNo}-li ishcinin yeni salarysi:  ");
                }
                humanResourceManager.EditEmployee(employeeNo, employees_new_salary, employees_new_position);
                PressEnterToContinue();
                return;
            }
            Console.WriteLine("Bele bir nomreli ishchi yoxdur...:(");
            PressEnterToContinue();
        }

        public static void DeleteEmployeeFromDepartment(ref HumanResourceManager humanResourceManager)
        {
            Console.Write("Silmek istediyiviz ishicinin department adi: ");
            string departmentsname = Console.ReadLine();
            if (humanResourceManager.IsExistDepartmentByName(departmentsname))
            {
                Console.Write("Silmek istediyiniz ishcinin nomresi: ");
                string employeesgroupno = Console.ReadLine();
                if (humanResourceManager.IsExistEmployeeByNO(employeesgroupno))
                {
                    humanResourceManager.DeleteEmployeesFromDepartmentByNo(departmentsname, employeesgroupno);
                    Console.WriteLine("Silindi...");
                    PressEnterToContinue();
                    return;
                }
                Console.WriteLine($"{employeesgroupno} -nomresinde ishci movcud deyil...:(");
                Console.WriteLine("Movcud ishcilerin grup normesine ana menyuda 2.1 yazaraq baxa bilersiz...:)");
                PressEnterToContinue();
                return;
            }
            Console.WriteLine($"{departmentsname} -adli department movcud deyil...:(");
            Console.WriteLine("Movcud departmentlere ana menyuda 1.1 yazaraq baxa bilersiz...:)");
            PressEnterToContinue();
        }

        public static void PressEnterToContinue()
        {
            Console.Write("Press enter to continue...");
            Console.ReadLine();
        }
        
        
    }

}
