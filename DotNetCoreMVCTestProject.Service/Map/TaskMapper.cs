using AutoMapper;
using DotNetCoreMVCTestProject.Dto.Dto;
using DotNetCoreMVCTestProject.Dto.Models.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreMVCTestProject.Service.Map
{
    public class TaskMapper
    {
        public MyTask myTaskMapper(MyTaskDto task)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<MyTaskDto, MyTask>();
            });

            return config.CreateMapper().Map<MyTaskDto, MyTask>(task);
        }

        public MyTaskDto mapMyTaskDto(MyTask task)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MyTask, MyTaskDto>();
            });

            return config.CreateMapper().Map<MyTask, MyTaskDto>(task);
        }
    }
}
