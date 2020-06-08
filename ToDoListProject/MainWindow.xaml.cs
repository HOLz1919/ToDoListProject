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
using ToDoListProject.Database;

namespace ToDoListProject
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        ObservableCollection<Task> Tasks { get; set; }
        ObservableCollection<Task> tempListCategory { get; set; }

        DatabaseContext db;

        public MainWindow()
        {
            InitializeComponent();
            db = new DatabaseContext();
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
                db.AddTask(task);
            }
        }

        private void DateCheckBox_Checked(object  sender, RoutedEventArgs e)
        {
            var checkbox = sender as CheckBox;
            if(checkbox.Name.Equals(DayCheckBox.Name) && checkbox.IsChecked==true)
            {
                DayCheckBox.IsChecked = true;
                MonthCheckBox.IsChecked = true;
                YearCheckBox.IsChecked = true;
            }
            else if (checkbox.Name.Equals(MonthCheckBox.Name) && checkbox.IsChecked==true)
            {
                DayCheckBox.IsChecked = false;
                MonthCheckBox.IsChecked = true;
                YearCheckBox.IsChecked = true;
            }
            else if (checkbox.Name.Equals(YearCheckBox.Name) && checkbox.IsChecked==true)
            {
                DayCheckBox.IsChecked = false;
                MonthCheckBox.IsChecked = false;
                YearCheckBox.IsChecked = true;
            }
            else
            {
                DayCheckBox.IsChecked = false;
                MonthCheckBox.IsChecked = false;
                YearCheckBox.IsChecked = false;
            }
            string dateTime = DateofSearch();
            SearchDate(dateTime);
        }

        private string DateofSearch()
        {
            string date;
            if (DayCheckBox.IsChecked == true)
            {
                date = DayComboBox.SelectedItem.ToString() + "." + (MonthComboBox.SelectedIndex + 1).ToString("D2") + "." + YearComboBox.SelectedItem.ToString();
            }
            else if(MonthCheckBox.IsChecked == true)
            {
                date = (MonthComboBox.SelectedIndex + 1).ToString("D2") + "." + YearComboBox.SelectedItem.ToString();
            }
            else if (YearCheckBox.IsChecked == true)
            {
                date = YearComboBox.SelectedItem.ToString();
            }
            else
            {
                date = null;
            }
            return date;
        }

        private void SearchDate(string date)
        {
            if (String.IsNullOrEmpty(date))
            {
                for (int i = 0; i < Tasks.Count; i++)
                {
                    (TasksListBox.ItemContainerGenerator.ContainerFromIndex(i) as ListBoxItem).Visibility = Visibility.Visible;
                }
            }
            else
            {
                for (int i = 0; i < Tasks.Count; i++)
                {
                    if (Tasks[i].DateOfCreate.Contains(date) || Tasks[i].DateOfEnd.Contains(date))
                    {
                        (TasksListBox.ItemContainerGenerator.ContainerFromIndex(i) as ListBoxItem).Visibility = Visibility.Visible;
                    }
                    else
                    {
                        (TasksListBox.ItemContainerGenerator.ContainerFromIndex(i) as ListBoxItem).Visibility = Visibility.Collapsed;
                    }
                }
            }
        }
       private void DateComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
       {
            string dateTime = DateofSearch();
            if (TasksListBox.ItemContainerGenerator.Status != 0)
            {
                SearchDate(dateTime);
            }
                
       }

        private void ShowDetailsInTask(object sender, MouseButtonEventArgs e)
        {

            Task selected = (Task)TasksListBox.SelectedItem;
            ShowDetails details = new ShowDetails(selected.ListOfSteps);
            details.Owner = this;
            details.DataContext = selected;
            if(details.ShowDialog() == true)
            {
                TasksListBox.Items.Refresh();
            }
            
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrEmpty(SearchTextBox.Text))
            {
                for(int i = 0; i < Tasks.Count; i++)
                {
                    (TasksListBox.ItemContainerGenerator.ContainerFromIndex(i) as ListBoxItem).Visibility = Visibility.Visible;
                }
            }
            else
            {
                for (int i = 0; i < Tasks.Count; i++)
                {
                    if (Tasks[i].AllSteps.Contains(SearchTextBox.Text))
                    {
                        (TasksListBox.ItemContainerGenerator.ContainerFromIndex(i) as ListBoxItem).Visibility = Visibility.Visible;
                    }
                    else
                    {
                        (TasksListBox.ItemContainerGenerator.ContainerFromIndex(i) as ListBoxItem).Visibility = Visibility.Collapsed;
                    }
                }
                
            }

        }
        private void EndTaskButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            int index = TasksListBox.Items.IndexOf(button.DataContext);
            Task selected = (Task)TasksListBox.Items[index];
            selected.IsFinishedTask = true;
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
                days.Add(i.ToString("D2"));
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
            //if(Tasks == null)
            //{
            //    Tasks = new ObservableCollection<Task>
            //    {
            //        new Task(Category.Dom, false, "", "", Importance.Pilny, new ObservableCollection<Step>
            //        {new Step("Chuj",false), 
            //        new Step("Drugi",false),
            //        new Step("Trzeci",false)
            //        }),
            //        new Task(Category.Inne, false, "", "", Importance.Wazny, new ObservableCollection<Step>
            //        {new Step("Pierwszy",false),
            //        new Step("Drugi",false),
            //        new Step("Trzeci",false)
            //        }),
            //        new Task(Category.Płatności, false, "", "", Importance.Wazny, new ObservableCollection<Step>
            //        {new Step("Pierwszy",false),
            //        new Step("Drugi",false),
            //        new Step("Trzeci",false)
            //        }),
            //        new Task(Category.Szkoła, false, "", "", Importance.Wazny, new ObservableCollection<Step>
            //        {new Step("Pierwszy",false),
            //        new Step("Drugi",false),
            //        new Step("Trzeci",false)
            //        }),
            //        new Task(Category.Zakupy, false, "", "", Importance.Zwykly, new ObservableCollection<Step>
            //        {new Step("Pierwszy",false),
            //        new Step("Drugi",false),
            //        new Step("Trzeci",false)
            //        }),
            //        new Task(Category.Zakupy, false, "", "", Importance.Pilny, new ObservableCollection<Step>
            //        {new Step("Pierwszy",false),
            //        new Step("Drugi",false),
            //        new Step("Trzeci",false)
            //        }),
            //        new Task(Category.Szkoła, false, "", "", Importance.Wazny, new ObservableCollection<Step>
            //        {new Step("Pierwszy",true,new ObservableCollection<SubStep>
            //        {
            //            new SubStep("pierwszy",true),
            //            new SubStep("Drugi",true),
            //            new SubStep("Trzeci",true)
            //        }),
            //        new Step("Drugi",true,new ObservableCollection<SubStep>
            //        {
            //        new SubStep("pierwszy",true),
            //        new SubStep("Drugi",true)
            //        })
            //        })
            //    };
            //}
            Tasks = db.GetTaskList();
        }

        private void CategoryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedCategory = CategoryComboBox.SelectedItem.ToString();

            //Pierwszy if potrzebny by uruchomić program bez błędu
            if (TasksListBox.ItemContainerGenerator.Status != 0)
            {
                if (selectedCategory.Equals(Category.Wszystkie.ToString()))
                {
                    for (int i = 0; i < Tasks.Count; i++)
                    {
                        (TasksListBox.ItemContainerGenerator.ContainerFromIndex(i) as ListBoxItem).Visibility = Visibility.Visible;
                    }
                }
                else
                {
                    for (int i = 0; i < Tasks.Count; i++)
                    {
                        if (Tasks[i].Category.ToString().Equals(selectedCategory))
                        {
                            (TasksListBox.ItemContainerGenerator.ContainerFromIndex(i) as ListBoxItem).Visibility = Visibility.Visible;
                        }
                        else
                        {
                            (TasksListBox.ItemContainerGenerator.ContainerFromIndex(i) as ListBoxItem).Visibility = Visibility.Collapsed;
                        }
                    }
   
                }
            }

        }


    }
}
