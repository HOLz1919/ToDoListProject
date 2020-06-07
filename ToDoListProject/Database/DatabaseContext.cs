using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Collections.ObjectModel;

namespace ToDoListProject.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("TaskDatabase")
        {
        }

        public DbSet<TaskDB> Tasks { get; set; }
        public DbSet<StepDB> Steps { get; set; }
        public DbSet<SubStepDB> SubSteps { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskDB>().ToTable("Tbl_Tasks");
            modelBuilder.Entity<StepDB>().ToTable("Tbl_Steps");
            modelBuilder.Entity<SubStepDB>().ToTable("Tbl_SubSteps");

            base.OnModelCreating(modelBuilder);
        }


        public ObservableCollection<TaskDB> GetTaskList()
        {
            List<TaskDB> tasks = Tasks.ToList();
            var oc = new ObservableCollection<TaskDB>(tasks);
            return oc;
        }



        public ObservableCollection<StepDB> GetStepList()
        {
            List<StepDB> steps = Steps.ToList();
            var oc = new ObservableCollection<StepDB>(steps);
            return oc;
        }

        public ObservableCollection<SubStepDB> GetSubStepsListGetStepList()
        {
            List<SubStepDB> subSteps = SubSteps.ToList();
            var oc = new ObservableCollection<SubStepDB>(subSteps);
            return oc;
        }

        public void AddTask(TaskDB taskDB)
        {
            Tasks.Add(taskDB);
            SaveChanges();
        }

        public void RemoveTask(int id)
        {
            Tasks.Remove(Tasks.Find(id));
            SaveChanges();
        }

        public void EditTask(TaskDB taskDb)
        {
            TaskDB task = Tasks.FirstOrDefault(m => m.TaskId == taskDb.TaskId);
            if (task!=null)
            {
                task = taskDb;
                SaveChanges();
            }

        }



    }
}
