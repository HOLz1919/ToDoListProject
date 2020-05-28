using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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
    /// Logika interakcji dla klasy EditTask.xaml
    /// </summary>
    public partial class EditTask : Window
    {
        public ObservableCollection<Step> Steps;
        public EditTask(ObservableCollection<Step> steps)
        {
            InitializeComponent();
            Steps = steps;
            StepsListBox.ItemsSource = Steps;
            CategoryComboBox.ItemsSource = Enum.GetValues(typeof(Category));
        }

        private void StepsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var list = sender as ListBox;
            var selected = list.SelectedItem as Step;
            SubStepsListBox.ItemsSource = selected.SubSteps;
        }

        private void MainStepTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            var tb = sender as TextBox;
            StepsListBox.SelectedItem = tb.DataContext;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void AddStep_Click(object sender, RoutedEventArgs e)
        {
            Steps.Add(new Step("", false));
        }

        private void AddSubStep_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<SubStep> subSteps;
            if (Steps[StepsListBox.SelectedIndex].SubSteps != null)
            {
                subSteps = Steps[StepsListBox.SelectedIndex].SubSteps;
                SubStepsListBox.ItemsSource = subSteps;
            }
            else
            {
                subSteps = new ObservableCollection<SubStep>();
                Steps[StepsListBox.SelectedIndex].SubSteps = subSteps;
                SubStepsListBox.ItemsSource = Steps[StepsListBox.SelectedIndex].SubSteps; 
            }
            subSteps.Add(new SubStep("", false));
        }

        private void DeleteStepButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            var item = (Step)button.DataContext;
            Steps.Remove(item);
        }

        private void DeleteSubStepButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            var item = (SubStep)button.DataContext;
            Steps[StepsListBox.SelectedIndex].SubSteps.Remove(item);
        }
    }

    public class RadioBoolToIntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string parameterString = parameter as string;
            if (parameterString == null)
                return DependencyProperty.UnsetValue;

            if (Enum.IsDefined(value.GetType(), value) == false)
                return DependencyProperty.UnsetValue;

            object parameterValue = Enum.Parse(value.GetType(), parameterString);

            return parameterValue.Equals(value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string parameterString = parameter as string;
            if (parameterString == null)
                return DependencyProperty.UnsetValue;

            return Enum.Parse(targetType, parameterString);
        }
    }
}

