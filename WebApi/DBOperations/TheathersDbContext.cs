using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Models.Entities;

namespace WebApi.DBOperations {
  public class TheathersDbContext : DbContext {
    public TheathersDbContext(DbContextOptions<TheathersDbContext> options) : base(options) {}

    public DbSet<TheatherModel> Theathers {get; set; }
    public DbSet<StageModel> Stages {get; set; }
  }
}