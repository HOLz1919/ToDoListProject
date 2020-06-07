using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Collections.ObjectModel;
using ToDoListProject.Models;

namespace ToDoListProject.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("TaskDatabase")
        {
        }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<Step> Steps { get; set; }
        public DbSet<SubStep> SubSteps { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>().ToTable("Tbl_Tasks");
            modelBuilder.Entity<Step>().ToTable("Tbl_Steps");
            modelBuilder.Entity<SubStep>().ToTable("Tbl_SubSteps");

            base.OnModelCreating(modelBuilder);
        }


        public ObservableCollection<Task> GetTaskList()
        {
            List<Task> tasks = Tasks.ToList();
            var oc = new ObservableCollection<Task>(tasks);
            return oc;
        }



        public ObservableCollection<Step> GetStepList()
        {
            List<Step> steps = Steps.ToList();
            var oc = new ObservableCollection<Step>(steps);
            return oc;
        }

        public ObservableCollection<SubStep> GetSubStepsListGetStepList()
        {
            List<SubStep> subSteps = SubSteps.ToList();
            var oc = new ObservableCollection<SubStep>(subSteps);
            return oc;
        }

        public void AddTask(Task task)
        {
            Tasks.Add(task);
            SaveChanges();
        }

        public void RemoveTask(int id)
        {
            Tasks.Remove(Tasks.Find(id));
            SaveChanges();
        }

        public void EditTask(Task task)
        {
            Task _task = Tasks.FirstOrDefault(m => m.TaskId == task.TaskId);
            if (_task!=null)
            {
                _task = task;
                SaveChanges();
            }

        }



    }
}
