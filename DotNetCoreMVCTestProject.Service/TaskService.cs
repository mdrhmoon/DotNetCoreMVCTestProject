using DotNetCoreMVCTestProject.Data;
using DotNetCoreMVCTestProject.Dto.Dto;
using DotNetCoreMVCTestProject.Dto.Models.Task;
using DotNetCoreMVCTestProject.Service.Map;
using DotNetCoreMVCTestProject.Service.Validation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreMVCTestProject.Service
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            this.taskRepository = taskRepository;
        }


        // Save new Task
        public async Task<MyTaskDto> SaveTask(MyTaskDto taskDto)
        {
            // Mapped Task
            MyTask task = new TaskMapper().myTaskMapper(taskDto);
            if (task == null) throw new Exception("Failed to map task. Please try again.");

            // Initialize task
            MyTask initializedTask = InitializeMyTaskDto(task);
            if (initializedTask == null) throw new Exception("Failed to initialize task. Please try again.");

            // Validate task
            ValidationResult result = new TaskValidation().Validate(task);
            if (!result.IsValid) throw new Exception(result.ToString(" ~"));

            // save task
            var insertedTask = await taskRepository.SaveTask(task);
            if (insertedTask == null) throw new Exception("Failed to save task. Please try again.");

            return new TaskMapper().mapMyTaskDto(insertedTask);;
        }


        private MyTask InitializeMyTaskDto(MyTask task)
        {
            task.IsActive = true;
            task.CreatedOn = System.DateTime.Now;

            return task;
        }


        public async Task<List<MyTaskDto>> GetAllTask()
        {
            var result = await taskRepository.GetAllTask();
            List<MyTaskDto> taskDtoList = result.Select(c => new TaskMapper().mapMyTaskDto(c)).ToList();
            return taskDtoList;
        }


        public async Task<MyTaskDto> GetTaskById(int Id)
        {
            var result = await taskRepository.GetTaskByID(Id);
            MyTaskDto taskDto = new TaskMapper().mapMyTaskDto(result);

            return taskDto;
        }


        public async Task<MyTaskDto> UpdateTask(MyTaskDto taskDto)
        {
            // map task dto to task
            MyTask mappedTask = await MapMyTaskForUpdate(taskDto);

            // Validate task
            ValidationResult result = new TaskValidation().Validate(mappedTask);
            if (!result.IsValid) throw new Exception(result.ToString(" ~"));

            // Update task 
            var updatedTask = await taskRepository.UpdateTask(mappedTask);
            if (updatedTask == null) throw new Exception("Failed to update task. Please try again.");

            // map task to task dto
            MyTaskDto newTask = new TaskMapper().mapMyTaskDto(updatedTask);
            if (newTask == null) throw new Exception("Failed to update task. Please try again.");

            return newTask;
        }


        private async Task<MyTask> MapMyTaskForUpdate(MyTaskDto taskDto)
        {
            MyTask task = await taskRepository.GetTaskByID(taskDto.Id);

            task.TaskStatus = taskDto.TaskStatus;
            task.LastModifiedOn = System.DateTime.Now;

            task.IsActive = taskDto.IsActive;
            task.TaskTitle = taskDto.TaskTitle;
            task.Description = taskDto.Description;

            return task;
        }


        public void DeleteTask(int Id)
        {
            taskRepository.DeleteTask(Id);
        }
    }
}
