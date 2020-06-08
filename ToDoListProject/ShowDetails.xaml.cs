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
    /// Logika interakcji dla klasy ShowAndEditDetails.xaml
    /// </summary>
    public partial class ShowDetails : Window
    {
        public ObservableCollection<Step> steps;
        public ShowDetails(ObservableCollection<Step> steps_)
        {
            InitializeComponent();
            steps = steps_;
            StepsListBox.ItemsSource = steps;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            var cb = sender as CheckBox;
            var item = cb.DataContext;
            StepsListBox.SelectedItem = item; 
            Step step =(Step) StepsListBox.SelectedItem;
            if (step.SubSteps != null)
            {
                foreach (SubStep i in step.SubSteps)
                {
                    i.IsFinishedSubStep = true;
                }
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            EditTask editTask = new EditTask(steps);
            editTask.Owner = this;
            editTask.DataContext = this.DataContext;
            editTask.ShowDialog();
        }

        private void EndTaskButton_Click(object sender, RoutedEventArgs e)
        {
            Task task =(Task) DataContext;
            task.IsFinishedTask = true;
            StepsListBox.IsEnabled = false;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DialogResult = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Task task = (Task)DataContext;
            if (task.IsFinishedTask) StepsListBox.IsEnabled = false;
        }
    }
}
