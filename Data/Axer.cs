using Microsoft.EntityFrameworkCore;
using RESTREST_2.Models;
namespace RESTREST_2.Data;

public class Axer : DbContext{
    public Axer(DbContextOptions<Axer> options) : base(options){
    }

    public DbSet<Profile> Profiles => Set<Profile>();
}