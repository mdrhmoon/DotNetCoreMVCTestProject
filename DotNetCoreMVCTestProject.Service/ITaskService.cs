using DotNetCoreMVCTestProject.Dto.Dto;
using DotNetCoreMVCTestProject.Dto.Models.Task;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetCoreMVCTestProject.Service
{
    public interface ITaskService
    {
        Task<List<MyTaskDto>> GetAllTask();
        Task<MyTaskDto> GetTaskById(int Id);
        Task<MyTaskDto> SaveTask(MyTaskDto taskDto);
        Task<MyTaskDto> UpdateTask(MyTaskDto taskDto);
        void DeleteTask(int Id);
    }
}