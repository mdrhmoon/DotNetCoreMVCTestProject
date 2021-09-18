using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreMVCTestProject.Dto.Dto
{
    public class MyTaskDto
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Title")]
        public string TaskTitle { get; set; }
        public string Description { get; set; }

        [Required]
        [DisplayName("Status")]
        public int TaskStatus { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastModifiedOn { get; set; }
    }
}
