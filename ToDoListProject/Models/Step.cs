using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListProject
{
    public class Step
    {
        private string mainStep;
        private bool isFinishedStep;
        private ObservableCollection<SubStep> subSteps;

        public Step() { }

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
                mainStep = value;
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
                subSteps = value;
            }
        }
    }
}
