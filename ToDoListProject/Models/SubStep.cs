using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListProject
{
    public class SubStep : INotifyPropertyChanged
    {
        private string name;
        private bool isFinishedSubStep;

        [Key]
        public int SubStepId { get; set; }

        public int StepId { get; set; }
        public virtual Step Step { get; set; }

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
                name = value; NotifyPropertyChanged();
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
                isFinishedSubStep = value; NotifyPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return name;
        }
    }
}
