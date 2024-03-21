using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet7TrainingBatch.MVCApp.Models
{
    [Table("tbl_blogs")]
    public class BlogModel
    {
        [Key]
        public int blog_id { get; set; }
        public string blog_title { get; set; }
        public string blog_author { get; set; }
        public string blog_content { get; set; }

    }


    public class BlogResponseModel
    {
        public bool isSuccess { get; set; }
        public string message { get; set; }  
    }
}
