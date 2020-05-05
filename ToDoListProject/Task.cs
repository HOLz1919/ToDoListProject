using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListProject
{
    public class Task
    {
        private Category category;
        private bool isFinished;
        private string dateOfCreate;
        private string dateOfEnd;
        private enum Importance
        {
            Zwykly,
            Wazny,
            Pilny,
        }
        private ObservableCollection<Step> listOfSteps;


    }
}
