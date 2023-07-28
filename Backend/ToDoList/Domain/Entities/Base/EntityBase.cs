using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Base
{
    public abstract class EntityBase
    {
        [Key]
        public Guid Id { get; set; }
        public string Titulo { get; set; }
    }
}
