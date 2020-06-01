using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ToDoListProject.Models;

namespace ToDoListProject
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        ObservableCollection<Task> Tasks { get; set; }
        ObservableCollection<Task> tempListCategory { get; set; }

        ObservableCollection<Task> tasksByText { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            InitilizeCollection();
            SelectDefaultItemsInComboBoxes();
            CategoryComboBox.ItemsSource = Enum.GetValues(typeof(Category));
            TasksListBox.ItemsSource = Tasks;
            
        }




        // ---------------------------- EVENTS -----------------------------------
        // -----------------------------------------------------------------------
        // -----------------------------------------------------------------------
        // -----------------------------------------------------------------------
        // -----------------------------------------------------------------------

        private void SearchTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(SearchTextBox.Text))
            {
                SearchTextBox.Visibility = Visibility.Collapsed;
                HintTextBox.Visibility = Visibility.Visible;
            }
        }

        private void HintTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            HintTextBox.Visibility = Visibility.Collapsed;
            SearchTextBox.Visibility = Visibility.Visible;
            SearchTextBox.Focus();
        }

        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            AddTask addTask = new AddTask
            {
                Owner = this
            };
            if (addTask.ShowDialog() == true)
            {
                RadioButton radio = addTask.GroupBox.Children.OfType<RadioButton>().FirstOrDefault(r => r.IsChecked == true);
                int ww = Int32.Parse(radio.Tag.ToString());
                Importance imp = (Importance)ww;
                Task task = new Task((Category)addTask.CategoryComboBox.SelectedItem, false, (String)addTask.CreationDate.Content, addTask.date,imp, addTask.Steps);
                Tasks.Add(task);
            }
        }


        private void DayCheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void DayCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void MonthCheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void MonthCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void YearCheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void YearCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {

        }
        private void ShowDetailsInTask(object sender, MouseButtonEventArgs e)
        {

            Task selected = (Task)TasksListBox.SelectedItem;
            ShowDetails details = new ShowDetails(selected.ListOfSteps);
            details.Owner = this;
            details.DataContext = selected;
            details.Show();
            

        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            tasksByText = new ObservableCollection<Task>();
            if (String.IsNullOrEmpty(SearchTextBox.Text))
            {
                TasksListBox.ItemsSource = Tasks;
            }
            else
            {
                foreach (Task task in Tasks)
                {
                    if (task.AllSteps.Contains(SearchTextBox.Text))
                    {
                        tasksByText.Add(task);
                    }
                }
                TasksListBox.ItemsSource = tasksByText;
            }

        }






        // --------------------------- INITIALIZE --------------------------------------------------
        // --------------------------------------------------------------------------------------------
        // --------------------------------------------------------------------------------------------
        // --------------------------------------------------------------------------------------------
        // --------------------------------------------------------------------------------------------
        private void SelectDefaultItemsInComboBoxes()
        {
            DayComboBox.ItemsSource = GenerateDaysToComboBox();
            MonthComboBox.ItemsSource = GenerateMonthsToComboBox();
            YearComboBox.ItemsSource = GenerateYearsToComboBox();

            DayComboBox.SelectedIndex = DateTime.Now.Day - 1;
            MonthComboBox.SelectedIndex = DateTime.Now.Month - 1;
            List<string> years = YearComboBox.ItemsSource as List<string>;
            int index = years.IndexOf(DateTime.Now.Year.ToString());
            YearComboBox.SelectedIndex = index;

        }


        private List<string> GenerateDaysToComboBox()
        {
            List<string> days = new List<string>();
            for(int i = 1; i < 32; i++)
            {
                days.Add(i.ToString());
            }

            return days;
        } 
        private List<string> GenerateMonthsToComboBox()
        {
            List<string> months = new List<string>
            {
                "Styczeń",
                "Luty",
                "Marzec",
                "Kwiecień",
                "Maj",
                "Czerwiec",
                "Lipiec",
                "Sierpień",
                "Wrzesień",
                "Październik",
                "Listopad",
                "Grudzień"
            };

            return months;
        }

        private List<string> GenerateYearsToComboBox()
        {
            List<string> years = new List<string>();
            int actualYear = DateTime.Now.Year;


            for (int i = actualYear-5; i < actualYear+5; i++)
            {
                years.Add(i.ToString());
            }

            return years;
        }
        private void InitilizeCollection()
        {
            if(Tasks == null)
            {
                Tasks = new ObservableCollection<Task>
                {
                    new Task(Category.Dom, false, "", "", Importance.Pilny, new ObservableCollection<Step>
                    {new Step("Chuj",false), 
                    new Step("Drugi",false),
                    new Step("Trzeci",false)
                    }),
                    new Task(Category.Inne, false, "", "", Importance.Wazny, new ObservableCollection<Step>
                    {new Step("Pierwszy",false),
                    new Step("Drugi",false),
                    new Step("Trzeci",false)
                    }),
                    new Task(Category.Płatności, false, "", "", Importance.Wazny, new ObservableCollection<Step>
                    {new Step("Pierwszy",false),
                    new Step("Drugi",false),
                    new Step("Trzeci",false)
                    }),
                    new Task(Category.Szkoła, false, "", "", Importance.Wazny, new ObservableCollection<Step>
                    {new Step("Pierwszy",false),
                    new Step("Drugi",false),
                    new Step("Trzeci",false)
                    }),
                    new Task(Category.Zakupy, false, "", "", Importance.Zwykly, new ObservableCollection<Step>
                    {new Step("Pierwszy",false),
                    new Step("Drugi",false),
                    new Step("Trzeci",false)
                    }),
                    new Task(Category.Zakupy, false, "", "", Importance.Pilny, new ObservableCollection<Step>
                    {new Step("Pierwszy",false),
                    new Step("Drugi",false),
                    new Step("Trzeci",false)
                    }),
                    new Task(Category.Szkoła, false, "", "", Importance.Wazny, new ObservableCollection<Step>
                    {new Step("Pierwszy",true,new ObservableCollection<SubStep>
                    {
                        new SubStep("pierwszy",true),
                        new SubStep("Drugi",true),
                        new SubStep("Trzeci",true)
                    }),
                    new Step("Drugi",true,new ObservableCollection<SubStep>
                    {
                    new SubStep("pierwszy",true),
                    new SubStep("Drugi",true)
                    })
                    })
                };
            }
        }

        private void CategoryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            Button button = sender as Button;
            if (CategoryComboBox.SelectedItem.Equals(Category.Zakupy))
            { 
               tempListCategory  = new ObservableCollection<Task>( );
                foreach (Task task in Tasks)
                { 
                    
                        if (task.Category.Equals(Category.Zakupy) ) 
                        tempListCategory.Add(task);
                        
                }
                TasksListBox.ItemsSource = tempListCategory;
            }
            if (CategoryComboBox.SelectedItem.Equals(Category.Dom))
            {
                tempListCategory = new ObservableCollection<Task>();
                foreach (Task task in Tasks)
                {

                    if (task.Category.Equals(Category.Dom))
                        tempListCategory.Add(task);

                }
                TasksListBox.ItemsSource = tempListCategory;
            }
            if (CategoryComboBox.SelectedItem.Equals(Category.Inne))
            {
                tempListCategory = new ObservableCollection<Task>();
                foreach (Task task in Tasks)
                {

                    if (task.Category.Equals(Category.Inne))
                        tempListCategory.Add(task);

                }
                TasksListBox.ItemsSource = tempListCategory;
            }
            if (CategoryComboBox.SelectedItem.Equals(Category.Płatności))
            {
                tempListCategory = new ObservableCollection<Task>();
                foreach (Task task in Tasks)
                {

                    if (task.Category.Equals(Category.Płatności))
                        tempListCategory.Add(task);

                }
                TasksListBox.ItemsSource = tempListCategory;
            }
            if (CategoryComboBox.SelectedItem.Equals(Category.Szkoła))
            {
                tempListCategory = new ObservableCollection<Task>();
                foreach (Task task in Tasks)
                {

                    if (task.Category.Equals(Category.Szkoła))
                        tempListCategory.Add(task);

                }
                TasksListBox.ItemsSource = tempListCategory;
            }
            if (CategoryComboBox.SelectedItem.Equals(Category.Wszystkie))
                {
                       
                       TasksListBox.ItemsSource = Tasks;
                };

            }


    }
}
