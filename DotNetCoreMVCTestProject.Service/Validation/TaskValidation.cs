using DotNetCoreMVCTestProject.Dto.Models.Task;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreMVCTestProject.Service.Validation
{
    public class TaskValidation: AbstractValidator<MyTask>
    {
        public TaskValidation()
        {
            RuleFor(c => c.IsActive).NotNull().WithMessage("Active status can not be null.");
            RuleFor(c => c.CreatedOn).NotNull().WithMessage("Create date time can not be null.");
            RuleFor(c => c.TaskStatus).GreaterThan(0).NotNull().WithMessage("Task status can not be null or not assigned.");
            RuleFor(c => c.TaskTitle).NotNull().WithMessage("Task Title can not be null.");
        }
    }
}
