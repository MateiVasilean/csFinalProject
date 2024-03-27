namespace final_project.Models
{
    public class EmployeeManager
    {
        private List<Employee> employees;
        private ObjectManager objectManager;

        public EmployeeManager()
        {
            employees = new List<Employee>();
        }

        public EmployeeManager(ObjectManager objectManager)
        {
            this.objectManager = objectManager;
        }

        public string CreateEmployee(string username, string password, string fullName, string department, string position, DateTime dateOfBirth, DataObject dataObject)
        {
            if (dataObject == null)
            {
                return "Cannot create employee without associated data object";
            }

            if (employees == null)
            {
                employees = new List<Employee>();
            }

            if (employees.Any(e => e.Username == username))
            {
                return $"An employee with the username '{username}' already exists";
            }

            var employee = new Employee(dataObject, username, password, fullName, department, position, dateOfBirth);
            employees.Add(employee);

            return $"Employee '{username}' created successfully";
        }

        public List<Employee> GetEmployees()
        {
            return employees;
        }

        public string ShowEmployees()
        {
            if (employees.Count == 0)
                return "No employees to display";

            string output = "Employees:\n";
            for (int i = 0; i < employees.Count; i++)
            {
                output += $"{employees[i].Username} - {employees[i].FullName} - {employees[i].Department}";
                if (i < employees.Count - 1)
                    output += "\n";
            }
            return output;
        }

        public string SearchEmployees(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
                return "Please enter a keyword";

            List<string> foundEmployees = new List<string>();
            foreach (var employee in employees)
            {
                if (employee.Username.Contains(keyword) || employee.FullName.Contains(keyword) || employee.Department.Contains(keyword))
                {
                    foundEmployees.Add($"{employee.Username} - {employee.FullName} - {employee.Department}");
                }
            }

            if (foundEmployees.Count == 0)
                return $"No employees found matching the keyword '{keyword}'";

            string output = "Found employees:\n";
            foreach (var foundEmployee in foundEmployees)
            {
                output += foundEmployee + "\n";
            }
            return output;
        }

        public void PopulateDataObjectPicker(Picker picker)
        {
            picker.Items.Clear();

            var dataObjects = objectManager.GetObjects();

            foreach (var dataObject in dataObjects)
            {
                picker.Items.Add(dataObject.Data);
            }
        }

    }
}