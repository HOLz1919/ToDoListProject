using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListProject.Models;

namespace ToDoListProject
{
    public class Task
    {
        private Category category;
        private bool isFinishedTask;
        private string dateOfCreate;
        private string dateOfEnd;
        private Importance importance;
        
        private ObservableCollection<Step> listOfSteps;


    }
}
