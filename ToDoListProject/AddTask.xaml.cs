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

namespace ToDoListProject
{
    /// <summary>
    /// Logika interakcji dla klasy AddTask.xaml
    /// </summary>
    public partial class AddTask : Window
    {

        public ObservableCollection<Step> Steps { get; set; }
        public AddTask()
        {
            InitializeComponent();
            InitializeCollection();
            StepsListBox.ItemsSource = Steps;
        }

        private void AddStepButton_Click(object sender, RoutedEventArgs e)
        {
            if (StepsListBox.Visibility == Visibility.Collapsed)
            {
                StepsListBox.Visibility = Visibility.Visible;
            }
            Step step = new Step("Siemanko",false,null);
            Steps.Add(step);
        }

        private void AddSubStepButton_Click(object sender, RoutedEventArgs e)
        {

            
            int index = StepsListBox.SelectedIndex;

            foreach (var listbox in FindVisualChildren<ListBox>(this))
            {
                if(listbox.Name== "SubStepsListBox")
                {
                    if (Steps[index].SubSteps == null)
                    {
                        ObservableCollection<SubStep> subSteps = new ObservableCollection<SubStep>();
                        subSteps.Add(new SubStep("czesc", false));
                        Steps[index].SubSteps = subSteps;
                        listbox.Visibility = Visibility.Visible;

                    }
                    else
                    {
                        Steps[index].SubSteps.Add(new SubStep("dodaje nowe", false));
                        
                    }
                }
            }

            


            
        }

        private void InitializeCollection()
        {
            if (Steps == null)
            {
                Steps = new ObservableCollection<Step>();
            }
        }

        public IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);

                    if (child != null && child is T)
                        yield return (T)child;

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                        yield return childOfChild;
                }
            }
        }

    }
}
