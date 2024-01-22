using Laboratorium_3___App.Controllers;
using Laboratorium_3___App.Models;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorium_9
{
    public class ContactControllerTest
    {
        private ContactController _controller;
        private IContactService _service;

        public ContactControllerTest()
        {
            IDateTimeProvider dateTimeProvider = new CurrentDateTimeProvider();
            _service = new MemoryContactService();
            _service.Add(new Contact() { Name = "Test 1" });
            _service.Add(new Contact() { Name = "Test 2" });
            _controller = new ContactController(_service);
        }

        [Fact]
        public void Test1()
        {
            var result = _controller.Index();
            Assert.IsType<ViewResult>(result);
            var view  = result as ViewResult;
            Assert.IsType<List<Contact>>(view.Model);
            var list = view.Model as List<Contact>;
            Assert.Equal(_service.FindAll().Count, list.Count);
        }
    }
}