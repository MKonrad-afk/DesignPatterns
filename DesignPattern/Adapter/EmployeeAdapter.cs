// In case you need some guidance: https://refactoring.guru/design-patterns/adapter
namespace DesignPattern.Adapter
{
    public class EmployeeAdapter : ITarget
    {
        private readonly BillingSystem thirdPartyBillingSystem = new();

        public void ProcessCompanySalary(string[,] employeesArray)
        {
            List<Employee> employees = new List<Employee>();
            int totalEmployees = employeesArray.GetLength(0);
            
            for (int i = 0; i < totalEmployees; i++)
            {
                var emp = new Employee(
                    int.Parse(employeesArray[i, 0]),
                    employeesArray[i, 1],
                    employeesArray[i, 2],
                    decimal.Parse(employeesArray[i, 3])
                );

                employees.Add(emp);
            }

            Console.WriteLine("Adapter just converted string[,] to List<Employee>\n");
            thirdPartyBillingSystem.ProcessSalary(employees);
        }
    }
}
