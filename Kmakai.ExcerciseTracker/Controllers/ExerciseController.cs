﻿using Kmakai.ExerciseTracker.Models;
using Kmakai.ExerciseTracker.Services;
using Spectre.Console;
using System.Globalization;
using System.Linq.Expressions;

namespace Kmakai.ExerciseTracker.Controllers;

public class ExerciseController
{
    private readonly IExerciseService ExerciseService;

    public ExerciseController(IExerciseService exerciseService)
    {
        ExerciseService = exerciseService;
    }

    public void GetExercises()
    {
        var exercises = ExerciseService.GetAllAsync().Result.ToList();
        
        Display.DisplayTable(exercises);

    }

    public void AddExercise()
    {
        Exercise exercise = new();

        Console.WriteLine("Enter the date and time you started");
        var Start = UserInput.GetDateAndTime();

        Console.WriteLine("Enter the date and time you finished");
        var End = UserInput.GetDateAndTime();

        var comment = UserInput.GetComment();

        
        exercise.DateStart = Start;
        exercise.DateEnd = End;
        exercise.Comments = comment;
        
        ExerciseService.AddAsync(exercise);

        Console.WriteLine("Exercise added successfully");

        Display.DisplayTable(ExerciseService.GetAllAsync().Result.ToList());
        
    }

    public void UpdateExercise()
    {
        var exercises = ExerciseService.GetAllAsync().Result.ToList();
        Display.DisplayTable(exercises);
        
        Console.WriteLine("Enter the id of the exercise you want to update");
        var id = UserInput.GetId(exercises);

        var exercise = exercises.FirstOrDefault(x => x.Id == id);

        if (exercise == null) { Console.WriteLine("Exercise not found"); return; }
        
        exercise.DateStart = AnsiConsole.Confirm("Would you like to update startTime? ") ? UserInput.GetDateAndTime() : exercise.DateStart;
        exercise.DateEnd = AnsiConsole.Confirm("Would you like to update endTime? ") ? UserInput.GetDateAndTime() : exercise.DateEnd;
        exercise.Comments = AnsiConsole.Confirm("Would you like to update comments? ") ? UserInput.GetComment() : exercise.Comments;

       var updatedExercise = ExerciseService.UpdateAsync(exercise).Result;

        Console.Clear();

        Console.WriteLine("Exercise updated successfully");
        Display.DisplayExercise(updatedExercise);
        
    }
}
  