

namespace Kmakai.ExcerciseTracker.Models;

public class Excercise
{
    int Id { get; set; }
    DateTime DateStart { get; set; }
    DateTime DateEnd { get; set; }
    TimeSpan Duration
    {
        get { return DateEnd - DateStart; }
    }
    string? Comments { get; set; }
}
