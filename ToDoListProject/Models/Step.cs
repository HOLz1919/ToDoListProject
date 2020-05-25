using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListProject
{
    public class Step : INotifyPropertyChanged
    {
        private string mainStep;
        private bool isFinishedStep;
        private ObservableCollection<SubStep> subSteps;

        public Step() { }

        public Step(string mainStep, bool isFinishedStep)
        {
            this.mainStep = mainStep;
            this.isFinishedStep = isFinishedStep;
            //this.subSteps = subSteps;
        }

        public string MainStep
        { 
            get
            {
                return mainStep;
            }
            set
            {
                mainStep = value; OnPropertyChanged("View");
            }
        }
        public bool IsFinishedStep
        {
            get
            {
                return isFinishedStep;
            }
            set
            {
                isFinishedStep = value;
            }
        }
        public ObservableCollection<SubStep> SubSteps
        {
            get
            {
                return subSteps;
            }
            set
            {
                subSteps = value; OnPropertyChanged("View");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this,
                new PropertyChangedEventArgs(property));
        }

        public override string ToString()
        {
           
            return mainStep;
        }
    }
}
