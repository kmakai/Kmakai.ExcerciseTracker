using Microsoft.Extensions.Hosting;
using Kmakai.ExerciseTracker.DataAccess;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Kmakai.ExerciseTracker.Controllers;
using Kmakai.ExerciseTracker.Repositories;
using Kmakai.ExerciseTracker.Services;

var connectionString = "Server=.;Database=ExerciseTracker;TrustServerCertificate=true;Trusted_Connection=True";
IHost host = Host.CreateDefaultBuilder()
    .ConfigureServices((services) =>
    {
        services.AddDbContext<ExerciseContext>( options => options.UseSqlServer(connectionString));
        services.AddTransient<IExerciseRepository, ExerciseRepository>();
        services.AddTransient<IExerciseService, ExerciseService>();
        services.AddTransient<ExerciseController>();
    })
    .Build();

var services = host.Services;

var exerciseController = services.GetRequiredService<ExerciseController>();
exerciseController.addExercise();


