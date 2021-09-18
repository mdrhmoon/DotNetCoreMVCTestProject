using System;
using System.Collections.Generic;

#nullable disable

namespace DotNetCoreMVCTestProject.Dto.Models.Task
{
    public partial class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
