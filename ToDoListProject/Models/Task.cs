using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ToDoListProject.Models;

namespace ToDoListProject
{
    public class Task : INotifyPropertyChanged
    {
        private Category category;
        private bool isFinishedTask;
        private string dateOfCreate;
        private string dateOfEnd;
        private Importance importance;
        private ObservableCollection<Step> listOfSteps;

        public Task(Category category, bool isFinishedTask, string dateOfCreate, string dateOfEnd, Importance importance, ObservableCollection<Step> listOfSteps)
        {
            Category = category;
            IsFinishedTask = isFinishedTask;
            DateOfCreate = dateOfCreate;
            DateOfEnd = dateOfEnd;
            Importance = importance;
            ListOfSteps = listOfSteps;
        }

        public Task() { }

        public Category Category
        {
            get
            {
                return category;
            }
            set
            {
                category = value;
                NotifyPropertyChanged();
            }
        }

        public bool IsFinishedTask
        {
            get
            {
                return isFinishedTask;
            }
            set
            {
                isFinishedTask = value;
                NotifyPropertyChanged();
            }
        }

        public string DateOfCreate
        {
            get
            {
                return dateOfCreate;
            }
            set
            {
                dateOfCreate = value;
                NotifyPropertyChanged();
            }
        }

        public string DateOfEnd
        {
            get
            {
                return dateOfEnd;
            }
            set
            {
                dateOfEnd = value;
                NotifyPropertyChanged();
            }
        }

        public Importance Importance
        {
            get
            {
                return importance;
            }
            set
            {
                importance = value;
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<Step> ListOfSteps
        {
            get
            {
                return listOfSteps;
            }
            set
            {
                listOfSteps = value;
                NotifyPropertyChanged();
            }
        }

        public string AllSteps
        {
            get
            {
              return getAllSteps();
            }
        }

        private string getAllSteps()
        {
            StringBuilder stringBuilder = new StringBuilder();
            int i = 1;
            foreach(Step step in ListOfSteps)
            {
                stringBuilder.Append(i + ". ").Append(step);
                i++;
            }
            return stringBuilder.ToString();
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public static explicit operator Task(ListBox v)
        {
            throw new NotImplementedException();
        }
    }
}
