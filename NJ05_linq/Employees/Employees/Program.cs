using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{


    class Program
    {
        static void Main(string[] args)
        {
            var employees = new[] {
                              new { Name="Andras", Salary=420},
                              new { Name="Bela", Salary=400},
                              new { Name="Csaba", Salary=250},
                              new { Name="David", Salary=300},
                              new { Name="Endre", Salary=620},
                              new { Name="Ferenc", Salary=350},
                              new { Name="Gabor", Salary=410},
                              new { Name="Hunor", Salary=500},
                              new { Name="Imre", Salary=900},
                              new { Name="Janos", Salary=600},
                              new { Name="Karoly", Salary=700},
                              new { Name="Laszlo", Salary=400},
                              new { Name="Marton", Salary=500}
                                };


            //Display the name of the employee who earn the most
            var richestEmployee = employees.OrderByDescending(e => e.Salary)
                                            .Select(e => e.Name)
                                            .FirstOrDefault();
            Console.WriteLine(richestEmployee);
            Console.WriteLine("***");

            //Display the name of the employees who earn less than the company average.
            var poorEmployees = employees.Where(e => e.Salary < employees.Average(es => es.Salary));
            poorEmployees.ToList().ForEach(e => Console.WriteLine(e.Name));
            Console.WriteLine("***");


            //Sort the employees by their salaries in an ascending order
            var employeesSortedBySalary = employees.OrderBy(e => e.Salary);

            //Display the name of employees who earn the same amount and sort the result by salaries then names in an ascending order
            var sameSalaryEmployees = employees.GroupBy(e=> e.Salary)
                                               .Where(g => g.Count() > 1)
                                               .OrderBy(g => g.Key)
                                               .Select(g => g.OrderBy(e => e.Name))
                                               .Select(g => g.Select(e => e.Name));

            sameSalaryEmployees.ToList().ForEach(l => l.ToList().ForEach(n => Console.WriteLine(n)));
            Console.WriteLine("*****");

            //Group the employees in the following salary ranges: 200-399, 400-599, 600-799, 800-999
            var ranges = new[] { 999, 799, 599, 399, 199 };
            var groupedSalaryEmployees = employees.GroupBy(e => ranges.FirstOrDefault(r => r <= e.Salary))
                                                    .OrderBy(g => g.Key);
            groupedSalaryEmployees.ToList().ForEach(l => l.ToList().ForEach(n => Console.WriteLine(n)));


            Console.ReadKey();

        }
    }
}
