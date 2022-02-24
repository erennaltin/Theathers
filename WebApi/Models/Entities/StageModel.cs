namespace WebApi.Models.Entities {
  public class StageModel : BaseEntity {
    public string? Name { get; set; }
    public string? Adress { get; set; }

    public List<TheatherModel> Theathers { get; set; }
  }
}