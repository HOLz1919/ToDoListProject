using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListProject.Database
{
    public class SubStepDB
    {

        [Key]
        public int SubStepId { get; set; }

        public string Name { get; set; }
        public bool IsFinishedSubStep { get; set; }



        public int StepId { get; set; }
        public virtual StepDB StepDB { get; set; }


    }
}
