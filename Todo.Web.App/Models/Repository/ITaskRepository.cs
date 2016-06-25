using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Web.App.Models.Repository
{
    public interface ITaskRepository
    {
        IEnumerable<Task> GetAllTasks();
        Task FindTaskById(int id);
        Task AddTask(Task newTask);
        Task EditTask(int id, Task task);
        Task DeleteTask(int id);
        void Save();
    }
}
