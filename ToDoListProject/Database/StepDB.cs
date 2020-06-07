using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListProject.Database
{
    public class StepDB
    {
        [Key]
        public int StepId { get; set; }

        public string MainStep { get; set; }
        public bool IsFinishedStep { get; set; }
        public virtual List<SubStepDB> SubSteps { get; set; }

        public int TaskId { get; set; }
        public virtual TaskDB TaskDB { get; set; }
    }
}
