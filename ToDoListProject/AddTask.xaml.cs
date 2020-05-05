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


            if (Steps[index].SubSteps == null)
            {
                ObservableCollection<SubStep> subSteps = new ObservableCollection<SubStep>();
                subSteps.Add(new SubStep("", false));
                Steps[index].SubSteps = subSteps;

            }
            else
            {
                Steps[index].SubSteps.Add(new SubStep("", false));
            }
        }

        private void InitializeCollection()
        {
            if (Steps == null)
            {
                Steps = new ObservableCollection<Step>();
            }
        }



    }
}
