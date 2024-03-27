namespace final_project.Models
{
    public class DataObject
    {
        public string Data { get; set; }

        public DataObject(string data)
        {
            Data = data;
        }

        public bool Contains(string keyword)
        {
            return Data.Contains(keyword);
        }
    }
}