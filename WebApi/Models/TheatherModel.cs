namespace WebApi.Models {
  public class TheatherModel {
    public int Id {get; set; }
    public string? Name {get; set; }
    public string? Description {get; set; }
    public int AvailableSeats {get; set; }
    public DateTime Date {get; set; }
    public int? TheatherId {get; set; }
    public int Cost {get; set; }
  }
}