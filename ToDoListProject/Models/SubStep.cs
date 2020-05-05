using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListProject
{
    public class SubStep
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
                name = value;
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

        public override string ToString()
        {
            return name;
        }
    }
}
