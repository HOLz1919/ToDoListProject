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
    }
}
