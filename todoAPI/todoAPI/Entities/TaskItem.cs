using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace todoAPI.Entities
{
    [Table("tasks")]
    public class TaskItem
    {
        public int Id { get; set; }
        
        public string Title { get; set; }
        
        public DateTime? Due_date { get; set; }
        
        public int  Priority_id { get; set; }
        
        public bool Is_completed { get; set; } = false;
        
        public DateTime Created_at { get; set; } = DateTime.Now;
    }
}
