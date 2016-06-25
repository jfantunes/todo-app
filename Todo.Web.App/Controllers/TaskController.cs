using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Todo.Web.App.Models;
using Todo.Web.App.Models.Repository;

namespace Todo.Web.App.MailService
{
    public class TaskController : Controller
    {
        protected ITaskRepository repository;
    
        public TaskController(ITaskRepository repository)
        {
            this.repository = repository;
        }

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
                    Task task = this.repository.FindTaskById(id.Value);
                    if (task != null)
                        return Json(new { Success="False", responseText="Couldnt get task"});
                    else
                        return Json(task, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    List<Task> tasks = this.repository.GetAllTasks().ToList();
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
                var editedTask = this.repository.EditTask(id, task);
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
                var addedTask = this.repository.AddTask(task);
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
                var deletedTask = this.repository.DeleteTask(id);
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


        public bool DeleteTasks(int id)
        {
            try
            {
                var deletedTask = this.repository.DeleteTask(id);
                if (deletedTask != null)
                {
                    return true;
                }
                else
                    return false;

            }
            catch (Exception e)
            {
                return false;
            }

        }


    }
}
