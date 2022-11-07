using System;
using System.ComponentModel.DataAnnotations;

namespace todoAPI.Entities
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
        
        public DateTime Created_at { get; set; } = DateTime.Now;
    }
}
