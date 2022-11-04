using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace todoAPI.Models
{
    public class TaskItem
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        
        public DateTime? Due_date { get; set; }
        
        public int  Priority_id { get; set; }
        
        public bool Is_completed { get; set; } = false;
        
        public DateTime? Created_at { get; set; } = DateTime.Now;
    }
}
