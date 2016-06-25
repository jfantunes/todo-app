using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Todo.Web.App.Models.Context;

namespace Todo.Web.App.Models.Repository
{
    public class TaskRepository:ITaskRepository
    {
        private TaskContext db = new TaskContext();

        //Query Methods

        public IEnumerable<Task> GetAllTasks()
        {
                var tasks=db.Tasks;
                return tasks;
        }

        public Task FindTaskById(int id)
        {
            var foundTask = db.Tasks.Find(id);
            if (foundTask != null)
                return foundTask;
            else
                return null;
        }


        //Insert,Modify,Delete Methods
        public Task AddTask(Task newTask)
        {
            db.Tasks.Add(newTask);
            this.Save();
            return newTask;

        }

        public Task EditTask(int id, Task task)
        {
            
            var foundTask = db.Tasks.Find(id);

            if (foundTask != null)
            {
                foundTask.Description = task.Description;
                foundTask.Name = task.Name;
                this.Save();
                return foundTask;
            }
            return null;

        }

        public Task DeleteTask(int id)
        {
            var foundTask = db.Tasks.Find(id);

            if (foundTask != null)
            {
                db.Tasks.Remove(foundTask);
                this.Save();
            }
            return null;

        }


        public void Save()
        {
            db.SaveChanges();
        }


    }
}