using final_project.Models;

namespace final_project
{
    public partial class MainPage : ContentPage
    {
        ObjectManager objectManager;
        EmployeeManager employeeManager;
        Entry createInputEntry;
        Entry searchInputEntry;
        Entry searchEmployeesInputEntry;
        Label outputLabel;
        ListView objectsListView;
        Picker dataObjectPicker;

        public MainPage()
        {
            InitializeComponent();
            objectManager = new ObjectManager();
            employeeManager = new EmployeeManager(objectManager);

            var createButton = new Button { Text = "Create Object" };
            var createEmployeeButton = new Button { Text = "Create Employee" };
            var showButton = new Button { Text = "Show Objects" };
            var showEmployeesButton = new Button { Text = "Show Employees" };
            var searchButton = new Button { Text = "Search" };
            var searchEmployeesButton = new Button { Text = "Search Employees" };
            createInputEntry = new Entry { Placeholder = "Enter object name" };
            searchInputEntry = new Entry { Placeholder = "Enter keyword" };
            searchEmployeesInputEntry = new Entry { Placeholder = "Enter keyword" };
            outputLabel = new Label();
            objectsListView = new ListView();
            dataObjectPicker = new Picker();

            createButton.Clicked += OnCreateClicked;
            createEmployeeButton.Clicked += OnCreateEmployeeClicked;
            showButton.Clicked += OnShowClicked;
            showEmployeesButton.Clicked += OnShowEmployeesClicked;
            searchButton.Clicked += OnSearchClicked;
            searchEmployeesButton.Clicked += OnSearchEmployeesClicked;

            Content = new StackLayout
            {
                Children = {
                    createButton,
                    createEmployeeButton,
                    showButton,
                    showEmployeesButton,
                    searchButton,
                    searchEmployeesButton,
                    createInputEntry,
                    searchInputEntry,
                    searchEmployeesInputEntry,
                    dataObjectPicker,
                    outputLabel,
                    objectsListView
                }
            };

            createInputEntry.IsVisible = false;
            objectsListView.IsVisible = false;
            searchInputEntry.IsVisible = false;
            searchEmployeesInputEntry.IsVisible = false;
            dataObjectPicker.IsVisible = false;

            createInputEntry.Completed += OnCreateInputEntryCompleted;
            searchInputEntry.Completed += OnSearchInputEntryCompleted;
            searchEmployeesInputEntry.Completed += OnSearchEmployeesInputEntryCompleted;
        }

        private void OnDataObjectSelected(object sender, EventArgs e)
        {
            var selectedDataObjectName = dataObjectPicker.SelectedItem?.ToString();
            if (selectedDataObjectName != null)
            {
                var selectedDataObject = objectManager.GetObjects().FirstOrDefault(d => d.Data == selectedDataObjectName);
                if (selectedDataObject != null)
                {
                    outputLabel.Text = employeeManager.CreateEmployee(selectedDataObjectName, "password", "Nume Prenume", "IT", "Developer", DateTime.Now, selectedDataObject);
                }
            }
        }

        private void OnCreateClicked(object sender, EventArgs e)
        {
            createInputEntry.IsVisible = true;
            objectsListView.IsVisible = false;
            searchInputEntry.IsVisible = false;
            dataObjectPicker.IsVisible = false;

            createInputEntry.Focus();

            outputLabel.Text = objectManager.CreateObject(createInputEntry.Text);
            createInputEntry.Text = "";
        }

        private void OnCreateEmployeeClicked(object sender, EventArgs e)
        {
            createInputEntry.IsVisible = false;
            objectsListView.IsVisible = false;
            searchInputEntry.IsVisible = false;
            searchEmployeesInputEntry.IsVisible = false;
            dataObjectPicker.IsVisible = true;

            employeeManager.PopulateDataObjectPicker(dataObjectPicker);
            dataObjectPicker.SelectedIndexChanged -= OnDataObjectSelected;
            dataObjectPicker.SelectedIndexChanged += OnDataObjectSelected;
        }

        private void OnShowClicked(object sender, EventArgs e)
        {
            createInputEntry.IsVisible = false;
            objectsListView.IsVisible = true;
            searchInputEntry.IsVisible = false;
            searchEmployeesInputEntry.IsVisible = false;
            dataObjectPicker.IsVisible = false;

            outputLabel.Text = objectManager.ShowObjects();
        }

        private void OnShowEmployeesClicked(object sender, EventArgs e)
        {
            createInputEntry.IsVisible = false;
            objectsListView.IsVisible = true;
            searchInputEntry.IsVisible = false;
            searchEmployeesInputEntry.IsVisible = false;
            dataObjectPicker.IsVisible = false;

            outputLabel.Text = employeeManager.ShowEmployees();
        }

        private void OnSearchClicked(object sender, EventArgs e)
        {
            createInputEntry.IsVisible = false;
            objectsListView.IsVisible = false;
            searchInputEntry.IsVisible = true;
            searchEmployeesInputEntry.IsVisible = false;
            dataObjectPicker.IsVisible = false;

            searchInputEntry.Focus();

            outputLabel.Text = objectManager.SearchObjects(searchInputEntry.Text);
            searchInputEntry.Text = "";
        }

        private void OnSearchEmployeesClicked(object sender, EventArgs e)
        {
            createInputEntry.IsVisible = false;
            objectsListView.IsVisible = false;
            searchInputEntry.IsVisible = false;
            searchEmployeesInputEntry.IsVisible = true;
            dataObjectPicker.IsVisible = false;

            searchInputEntry.Focus();

            outputLabel.Text = employeeManager.SearchEmployees(searchEmployeesInputEntry.Text);
            searchEmployeesInputEntry.Text = "";
        }

        private void OnCreateInputEntryCompleted(object sender, EventArgs e)
        {
            OnCreateClicked(sender, e);
        }

        private void OnSearchInputEntryCompleted(object sender, EventArgs e)
        {
            OnSearchClicked(sender, e);
        }

        private void OnSearchEmployeesInputEntryCompleted(object sender, EventArgs e)
        {
            OnSearchEmployeesClicked(sender, e);
        }
    }
}