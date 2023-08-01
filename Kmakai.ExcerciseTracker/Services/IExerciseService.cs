using Kmakai.ExerciseTracker.Models;

namespace Kmakai.ExerciseTracker.Services;

public interface IExerciseService
{
    Exercise Add(Exercise entity);
    Task<Exercise> AddAsync(Exercise entity);
    Task<Exercise> DeleteAsync(int id);
    Exercise Get(int id);
    IEnumerable<Exercise> GetAll();
    Task<IEnumerable<Exercise>> GetAllAsync();
    Task<Exercise> GetAsync(int id);
    Task<Exercise> UpdateAsync(Exercise entity);
}