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
    public partial class ShowAndEditDetails : Window
    {
        public ObservableCollection<Step> steps;
        public ShowAndEditDetails()
        {
            InitializeComponent();
            steps = new ObservableCollection<Step>();
            StepsListBox.ItemsSource = steps;
        }
    }
}
