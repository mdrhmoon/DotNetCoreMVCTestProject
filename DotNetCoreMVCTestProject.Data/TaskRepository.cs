using DotNetCoreMVCTestProject.Dto.Models.Task;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreMVCTestProject.Data
{
    public class TaskRepository : ITaskRepository
    {
        private readonly DbContext context;
        public IDbContextTransaction transaction = null;

        public TaskRepository(IConfiguration Config)
        {
            this.context = new TaskContext(Config);
        }


        public async Task<Boolean> BEGIN_TRANSACTION()
        {
            this.transaction = await this.context.Database.BeginTransactionAsync();
            return true;
        }


        public async Task<Boolean> COMMIT()
        {
            if (this.transaction != null) await this.transaction.CommitAsync();
            return true;
        }


        public async Task<Boolean> ROLL_BACK()
        {
            if (this.transaction != null) await this.transaction.RollbackAsync();
            return true;
        }


        public async Task<MyTask> SaveTask(MyTask entity)
        {
            var result = await new GenericRepository<MyTask>(this.context).Insert(entity);
            return result;
        }


        public async Task<List<MyTask>> GetAllTask()
        {
            var result = await new GenericRepository<MyTask>(this.context).GetAll();
            return result;
        }


        public async Task<MyTask> GetTaskByID(int Id)
        {
            var result = await new GenericRepository<MyTask>(this.context).FindOne(i => i.Id == Id);
            return result;
        }


        public async Task<MyTask> UpdateTask(MyTask task)
        {
            var result = await new GenericRepository<MyTask>(this.context).Update(task, i => i.Id == task.Id);
            return result;
        }


        public void DeleteTask(int Id)
        {
            new GenericRepository<MyTask>(this.context).Delete(i => i.Id == Id);
        }
    }
}
