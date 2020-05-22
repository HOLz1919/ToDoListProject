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
using System.Windows.Shapes;
using ToDoListProject.ViewModels;

namespace ToDoListProject
{
    /// <summary>
    /// Logika interakcji dla klasy AddTask.xaml
    /// </summary>
    public partial class AddTask : Window
    {

        public ObservableCollection<Step> Steps;
        public AddTask()
        {
            InitializeComponent();
            InitializeCollection();
            StepsListBox.ItemsSource = Steps;
            CreationDate.Content = DateTime.Now.ToString("dd.MM.yyyy");
            DatePicker.BlackoutDates.AddDatesInPast();
        }

        private void AddStepButton_Click(object sender, RoutedEventArgs e)
        {
            
            Step step = new Step("", false);
            Steps.Add(step);

        }


        private void AddSubStepButton_Click(object sender, RoutedEventArgs e)
        {
            if (StepsListBox.SelectedIndex != -1)
            {
                if (Steps[StepsListBox.SelectedIndex].SubSteps != null)
                {
                    ObservableCollection<SubStep> subSteps = Steps[StepsListBox.SelectedIndex].SubSteps;
                    SubStepsListBox.ItemsSource = subSteps;
                    subSteps.Add(new SubStep("",false));
                }
                else
                {
                    ObservableCollection<SubStep> subSteps = new ObservableCollection<SubStep>();
                    Steps[StepsListBox.SelectedIndex].SubSteps = subSteps;
                    SubStepsListBox.ItemsSource = Steps[StepsListBox.SelectedIndex].SubSteps;
                    subSteps.Add(new SubStep("", false));
                }
            }


        //    int index = StepsListBox.SelectedIndex;

            //    foreach (var listbox in FindVisualChildren<ListBox>(this))
            //    {
            //        if(listbox.Name== "SubStepsListBox")
            //        {
            //            if (Steps[index].SubSteps == null)
            //            {
            //                ObservableCollection<SubStep> subSteps = new ObservableCollection<SubStep>();
            //                subSteps.Add(new SubStep("czesc", false));
            //                Steps[index].SubSteps = subSteps;
            //                listbox.Visibility = Visibility.Visible;

            //            }
            //            else
            //            {
            //                Steps[index].SubSteps.Add(new SubStep("dodaje nowe", false));

            //            }
            //        }
            //    }


        }

        private void InitializeCollection()
        {
            if (Steps == null)
            {
                Steps = new ObservableCollection<Step>();
            }
        }

        private void StepsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SubStepsListBox.ItemsSource = Steps[StepsListBox.SelectedIndex].SubSteps;
        }

        //public IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        //{
        //    if (depObj != null)
        //    {
        //        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
        //        {
        //            DependencyObject child = VisualTreeHelper.GetChild(depObj, i);

        //            if (child != null && child is T)
        //                yield return (T)child;

        //            foreach (T childOfChild in FindVisualChildren<T>(child))
        //                yield return childOfChild;
        //        }
        //    }
        //}

    }
}
