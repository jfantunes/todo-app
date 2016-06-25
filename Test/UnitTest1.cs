using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Web.App.Models.Repository;
using Todo.Web.App.MailService;
using Moq;
using Todo.Web.App.Models;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var mockRepo = new Moq.Mock<ITaskRepository>();
            var mockEmail = new Moq.Mock<IEmailService>();
           
            mockRepo.Setup(repo => repo.DeleteTask(It.IsAny<int>())).Returns(new Task()); 
            mockEmail.Setup(client =>client.Send(It.IsAny<string>())).Verifiable();

            var Controller = new TaskController(mockRepo.Object,mockEmail.Object);

            Controller.DeleteTasks(323);

            mockRepo.Verify(repo => repo.DeleteTask(323),Times.Once);

            mockEmail.Verify(email => email.Send(It.IsAny<string>()),Times.Once);

            
        }
    }
}
