using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models.Entities {
  public class StageModel {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Adress { get; set; }
  }
}