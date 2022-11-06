using System.ComponentModel.DataAnnotations.Schema;

namespace todoAPI.Entities
{
    [Table("priorities")]
    public class Priority
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}