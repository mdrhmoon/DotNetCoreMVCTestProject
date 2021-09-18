using DotNetCoreMVCTestProject.Dto.Dto;
using DotNetCoreMVCTestProject.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreMVCTestProject.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskService taskService;

        public TaskController(ITaskService taskService)
        {
            this.taskService = taskService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await taskService.GetAllTask();
            return View("Task", result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(MyTaskDto task)
        {
            if (!ModelState.IsValid) throw new Exception("Failed to fetch data. Please try again.");
            var result = await taskService.SaveTask(task);

            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == 0 || id == null) throw new Exception("Invalid id. Please try again.");

            var result = await taskService.GetTaskById(id.GetValueOrDefault());
            return View(result);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(MyTaskDto task)
        {
            if (!ModelState.IsValid) throw new Exception("Failed to fetch data. Please try again.");
            var result = await taskService.UpdateTask(task);

            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == 0 || id == null) throw new Exception("Invalid id. Please try again.");

            var result = await taskService.GetTaskById(id.GetValueOrDefault());
            return View(result);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == 0 || id == null) throw new Exception("Invalid id. Please try again.");

            var result = await taskService.GetTaskById(id.GetValueOrDefault());
            return View(result);
        }


        [HttpPost]
        public IActionResult Delete(MyTaskDto taskDto)
        {
            if (taskDto.Id == 0) throw new Exception("Invalid id. Please try again.");

            taskService.DeleteTask(taskDto.Id);

            return RedirectToAction("Index");
        }
    }
}
