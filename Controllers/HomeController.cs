using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ConsumeWebAPI_App.Models;
using System.Net.Http;
using ConsumeWebAPI_App.ServiceHelper;

namespace ConsumeWebAPI_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public readonly IServiceRepository _serviceRepository;

        public HomeController(IServiceRepository serviceRepository,ILogger<HomeController> logger)
        {
            _serviceRepository = serviceRepository;
            _logger = logger;
        }


        public IActionResult Index()
         {
            List<Teacher> teacherList = new List<Teacher>();
            var controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            HttpResponseMessage response = _serviceRepository.GetResponse(controllerName);
            response.EnsureSuccessStatusCode();
            teacherList = response.Content.ReadAsAsync<List<Teacher>>().Result;
            return View(teacherList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Teacher teacher)
        {
            var controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();

            if (ModelState.IsValid)
            {
                HttpResponseMessage response = _serviceRepository.PostResponse(controllerName, teacher);
                response.EnsureSuccessStatusCode();
                    return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Edit(int id)
        {
            Teacher teacher = new Teacher();
            var controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            HttpResponseMessage response = _serviceRepository.GetByIdResponse(controllerName, id.ToString());
            response.EnsureSuccessStatusCode();
            teacher = response.Content.ReadAsAsync<Teacher>().Result;
             
            return View(teacher);
        }

        [HttpPost]
        public IActionResult Edit(Teacher teacher)
        {
            var controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();

            if (ModelState.IsValid)
            {
                HttpResponseMessage response = _serviceRepository.PutResponse(controllerName, teacher);
                response.EnsureSuccessStatusCode();

                return RedirectToAction("Index");
            }
            else
                return View();
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            HttpResponseMessage response = _serviceRepository.DeleteResponse(controllerName, id.ToString());
            response.EnsureSuccessStatusCode();
            //var count = _teacherRepository.DeleteTeacher(id);
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
