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
        }

        public Step(string mainStep, bool isFinishedStep, ObservableCollection<SubStep> subSteps)
        {
            this.mainStep = mainStep;
            this.isFinishedStep = isFinishedStep;
            this.subSteps = subSteps;
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
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(mainStep).Append("\n");
            if (SubSteps!=null)
            {
                foreach (SubStep item in SubSteps)
                {
                    stringBuilder.Append(" - ").Append(item.Name).Append(" \n");
                }
            }
            
            return stringBuilder.ToString(); 
        }
    }
}
