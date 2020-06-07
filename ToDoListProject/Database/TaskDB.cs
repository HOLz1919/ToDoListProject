using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListProject.Models;

namespace ToDoListProject.Database
{
    public class TaskDB
    {
        [Key]
        public int TaskId { get; set; }

        public Category Category { get; set; }
        public bool IsFinishedTask { get; set; }
        public string DateOfCreate { get; set; }
        public string DateOfEnd { get; set; }
        public Importance Importance { get; set; }
        public virtual List<StepDB> Steps { get; set; }
    }
}
