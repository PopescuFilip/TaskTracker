using System.ComponentModel.DataAnnotations;

namespace TaskAPI.Models
{
    public class Entity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
