using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models.Entities {
  public class TheatherModel : BaseEntity {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id {get; set; }
    public string? Name {get; set; }
    public string? Description {get; set; }
    public int AvailableSeats {get; set; }
    public DateTime Date {get; set; }
    public int? TheatherId {get; set; }
    public int Cost {get; set; }
  }
}