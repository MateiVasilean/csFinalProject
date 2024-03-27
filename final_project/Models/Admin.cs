namespace final_project.Models
{
    public class Admin
    {
        public string Role { get; set; }
        public DataObject DataObject { get; private set; }

        public Admin(string adminData)
        {
            DataObject = new DataObject(adminData);
        }
    }
}