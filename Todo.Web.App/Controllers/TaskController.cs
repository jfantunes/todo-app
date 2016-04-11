using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Todo.Web.App.Models;
using Todo.Web.App.Models.Repository;

namespace Todo.Web.App.Controllers
{
    public class TaskController : Controller
    {
        private TaskRepository repository = new TaskRepository();

        public ActionResult Index()
        {

            return View();
        }


        // Get Tasks
        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult Tasks(int? id)
        {
            try
            {
                if (id.HasValue)
                {
                    Task task = repository.FindTaskById(id.Value);
                    if (task != null)
                        return Json(new { Success="False", responseText="Couldnt get task"});
                    else
                        return Json(task, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    List<Task> tasks = repository.GetAllTasks().ToList();
                    return Json(tasks, JsonRequestBehavior.AllowGet);
                }
            }
            catch(Exception e)
            {
                return Json(new { Success="False", responseText="Couldnt get tasks"});
            }
            return Json(new { Success = "False"}, JsonRequestBehavior.DenyGet);
        }


        // Update Task
        [AcceptVerbs(HttpVerbs.Put)]
        public JsonResult Tasks(int id, Task task)
        {
            try
            {
                var editedTask = repository.EditTask(id, task);
                if (editedTask != null)
                    return Json(editedTask, JsonRequestBehavior.DenyGet);
                else
                    return Json(new { Success = "False" }, JsonRequestBehavior.DenyGet);
            }
            catch (Exception e)
            {
                return Json(new { Success = "False" }, JsonRequestBehavior.DenyGet);
            }
            
       }         
     

        // Add Task

        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult Tasks(Task task)
        {
            try
            {
                var addedTask = repository.AddTask(task);
                return Json(addedTask, JsonRequestBehavior.DenyGet);
            }
            catch (Exception e)
            {
                return Json(new { Success = "False" }, JsonRequestBehavior.DenyGet);
            }
        }

        [AcceptVerbs(HttpVerbs.Delete)]
        public JsonResult Tasks(int id)
        {
            try
            {
                var deletedTask = repository.DeleteTask(id);
                if (deletedTask != null)
                    return Json(deletedTask, JsonRequestBehavior.DenyGet);
                else
                     return Json(new { Success = "False" }, JsonRequestBehavior.DenyGet);

            }
            catch (Exception e)
            {
                return Json(new { Success = "False", responseText = "Couldnt delete task" });
            }
        
        }

    }
}
