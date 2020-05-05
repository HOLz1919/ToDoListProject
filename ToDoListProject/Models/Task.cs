﻿using System;
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

        public Category Category
        {
            get
            {
                return category;
            }
            set
            {
                category = value;
            }
        }

        public bool IsFinishedTask
        {
            get
            {
                return isFinishedTask;
            }
            set
            {
                isFinishedTask = value;
            }
        }

        public string DateOfCreate
        {
            get
            {
                return dateOfCreate;
            }
            set
            {
                dateOfCreate = value;
            }
        }

        public string DateOfEnd
        {
            get
            {
                return dateOfEnd;
            }
            set
            {
                dateOfEnd = value;
            }
        }

        public Importance Importance
        {
            get
            {
                return importance;
            }
            set
            {
                importance = value;
            }
        }

        public ObservableCollection<Step> ListOfSteps
        {
            get
            {
                return listOfSteps;
            }
            set
            {
                listOfSteps = value;
            }
        }


    }
}