using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Todo.Web.App.Models.Context
{
    public class TaskContext : DbContext
    {
        public TaskContext()
            : base("name=TasksContext")
        {
        }

        public DbSet<Task> Tasks { get; set; }
    }
}