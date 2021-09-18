using DotNetCoreMVCTestProject.Dto.Models.Task;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetCoreMVCTestProject.Data
{
    public interface ITaskRepository
    {
        Task<List<MyTask>> GetAllTask();
        Task<MyTask> GetTaskByID(int Id);
        Task<MyTask> SaveTask(MyTask entity);
        Task<MyTask> UpdateTask(MyTask task);
        void DeleteTask(int Id);
    }
}