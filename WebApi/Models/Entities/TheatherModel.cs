using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models.Entities {
  public class TheatherModel : BaseEntity {
    public string? Name {get; set; }
    public string? Description {get; set; }
    public int AvailableSeats {get; set; }
    public DateTime Date {get; set; }
    public int StageId {get; set; }
    [ForeignKey("StageId")]
    public StageModel? Stage {get; set;}
    public int Cost {get; set; }
  }
}