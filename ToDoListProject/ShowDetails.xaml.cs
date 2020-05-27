﻿using System;
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
        public ShowDetails()
        {
            InitializeComponent();
            steps = new ObservableCollection<Step>();
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
    }
}
