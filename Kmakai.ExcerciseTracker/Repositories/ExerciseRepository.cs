

using Kmakai.ExerciseTracker.DataAccess;
using Kmakai.ExerciseTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace Kmakai.ExerciseTracker.Repositories;

public class ExerciseRepository:IRepository<Exercise>, IExerciseRepository
{
    
    private readonly ExerciseContext Context;

    public ExerciseRepository(ExerciseContext context)
    {
        Context = context;
    }

    public async Task<Exercise> GetAsync(int id)
    {
        return await Context.exercises.FindAsync(id) ?? new Exercise();
    }

    public async Task<IEnumerable<Exercise>> GetAllAsync()
    {
        return await Context.exercises.ToListAsync();
    }

    public async Task<Exercise> AddAsync(Exercise entity)
    {
        Context.exercises.Add(entity);
        await Context.SaveChangesAsync();
        return entity;
    }

    public async Task<Exercise> UpdateAsync(Exercise entity)
    {
        Context.exercises.Update(entity);
        await Context.SaveChangesAsync();
        return entity;
    }

    public async Task<Exercise> DeleteAsync(int id)
    {
        var entity = await Context.exercises.FindAsync(id);
        Context.exercises.Remove(entity);
        await Context.SaveChangesAsync();
        return entity;
    }

    public Exercise Get(int id)
    {
        return Context.exercises.Find(id) ?? new Exercise();
    }

    public IEnumerable<Exercise> GetAll()
    {
        return Context.exercises.ToList();
    }

    public Exercise Add(Exercise entity)
    {
        Context.exercises.Add(entity);
        Context.SaveChanges();
        return entity;
    }

    public Exercise Update(Exercise entity)
    {
        Context.exercises.Update(entity);
        Context.SaveChanges();
        return entity;
    }

    public Exercise Delete(int id)
    {
        var entity = Context.exercises.Find(id);
        Context.exercises.Remove(entity);
        Context.SaveChanges();
        return entity;
    }       
}
