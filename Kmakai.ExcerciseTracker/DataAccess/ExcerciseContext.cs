using Kmakai.ExcerciseTracker.Models;
using Microsoft.EntityFrameworkCore;


namespace Kmakai.ExcerciseTracker.DataAccess;

public class ExcerciseContext: DbContext
{
    public ExcerciseContext(DbContextOptions<ExcerciseContext> options)
        : base(options)
    {
    }

    public DbSet<Excercise> Excercises { get; set; } = null!;

}
