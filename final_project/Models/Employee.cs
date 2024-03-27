namespace final_project.Models
{
    public class Employee
    {
        public string Username { get; private set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DataObject DataObject { get; private set; }

        public Employee(DataObject dataObject, string username, string password, string fullName, string department, string position, DateTime dateOfBirth)
        {
            if (dataObject == null)
            {
                throw new ArgumentNullException(nameof(dataObject));
            }

            Username = username;
            Password = password;
            FullName = fullName;
            Department = department;
            Position = position;
            DateOfBirth = dateOfBirth;
            DataObject = dataObject;
        }
    }
}