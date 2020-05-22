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

        public MainWindow()
        {
            InitializeComponent();
            InitilizeCollection();
            SelectDefaultItemsInComboBoxes();
            CategoryComboBox.ItemsSource = Enum.GetValues(typeof(Category));
            
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
                Task task = new Task((Category)addTask.CategoryComboBox.SelectedItem,false,(String)addTask.CreationDate.Content,null,Importance.Zwykly,addTask.Steps);
                Tasks.Add(task);
            }
            else
            {
                MessageBox.Show("Coś poszło nie tak");
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
                Tasks = new ObservableCollection<Task>();
            }
        }


    }
}
