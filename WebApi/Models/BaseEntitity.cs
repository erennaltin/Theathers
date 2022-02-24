using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    public class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public Guid RowId { get; set; } = Guid.NewGuid();

        public bool IsDeleted { get; set; } = false;

        public DateTime DateCreatedUTC { get; set; } = DateTime.UtcNow;
        public DateTime? DateUpdatedUTC { get; set; }
        public DateTime? DateDeletedUTC { get; set; }
    }
}
