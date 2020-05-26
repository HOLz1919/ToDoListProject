using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListProject
{
    public class SubStep : INotifyPropertyChanged
    {
        private string name;
        private bool isFinishedSubStep;

        public SubStep() { }

        public SubStep(string name, bool isFinishedSubStep)
        {
            this.name = name;
            this.isFinishedSubStep = isFinishedSubStep;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value; OnPropertyChanged("View");
            }
        }
        public bool IsFinishedSubStep
        {
            get
            {
                return isFinishedSubStep;
            }
            set
            {
                isFinishedSubStep = value;
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
            return name;
        }
    }
}
