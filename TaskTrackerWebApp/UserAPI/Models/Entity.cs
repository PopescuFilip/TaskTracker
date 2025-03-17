using System.ComponentModel.DataAnnotations;

namespace UserAPI.Models
{
    public class Entity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
