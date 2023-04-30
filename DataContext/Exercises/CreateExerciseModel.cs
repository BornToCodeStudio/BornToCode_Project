namespace DataContext.Exercises;

public class CreateExerciseModel
{
    public string Title { get; set; } = null!;
    public int AuthorId { get; set; }
    public string ShortDescription { get; set; } = null!;
    public string? FullDescription { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? CodeExample { get; set; }
}