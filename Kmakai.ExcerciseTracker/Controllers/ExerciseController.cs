using Kmakai.ExerciseTracker.Models;
using Kmakai.ExerciseTracker.Services;

namespace Kmakai.ExerciseTracker.Controllers;

public class ExerciseController
{
    private readonly IExerciseService ExerciseService;

    public ExerciseController(IExerciseService exerciseService)
    {
        ExerciseService = exerciseService;
    }

    public void addExercise()
    {
        var exercise = new Exercise
        {
            DateStart = DateTime.Now,
            DateEnd = DateTime.Now.AddHours(1),
            Comments = "This is a comment"
        };

        ExerciseService.Add(exercise);

    }
}
