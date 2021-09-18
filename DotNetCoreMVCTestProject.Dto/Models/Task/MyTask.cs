using System;
using System.Collections.Generic;

#nullable disable

namespace DotNetCoreMVCTestProject.Dto.Models.Task
{
    public partial class MyTask
    {
        public int Id { get; set; }
        public string TaskTitle { get; set; }
        public string Description { get; set; }
        public int TaskStatus { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastModifiedOn { get; set; }
    }
}
