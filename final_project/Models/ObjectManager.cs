namespace final_project.Models
{
    public class ObjectManager
    {
        private List<DataObject> dataObjects;

        public ObjectManager()
        {
            dataObjects = new List<DataObject>();
        }

        public string CreateObject(string input)
        {
            string name = input?.Trim();
            if (string.IsNullOrEmpty(name))
                return "Please enter a name";

            DataObject newDataObject = new DataObject(name);
            dataObjects.Add(newDataObject);

            return $"Object '{name}' created successfully";
        }

        public List<DataObject> GetObjects()
        {
            return dataObjects;
        }

        public string ShowObjects()
        {
            if (dataObjects.Count == 0)
                return "No objects to display";

            string output = "Objects:\n";
            for (int i = 0; i < dataObjects.Count; i++)
            {
                output += dataObjects[i].Data;
                if (i < dataObjects.Count - 1)
                    output += "\n";
            }
            return output;
        }

        public string SearchObjects(string input)
        {
            string keyword = input?.Trim();
            if (string.IsNullOrEmpty(keyword))
                return "Please enter a keyword";

            List<string> foundObjects = new List<string>();
            foreach (var dataObject in dataObjects)
            {
                if (dataObject.Contains(keyword))
                {
                    foundObjects.Add(dataObject.Data);
                }
            }

            if (foundObjects.Count == 0)
                return $"No objects found containing the keyword '{keyword}'";

            string output = "Found objects:\n";
            foreach (var foundObject in foundObjects)
            {
                output += foundObject + "\n";
            }
            return output;
        }
    }
}