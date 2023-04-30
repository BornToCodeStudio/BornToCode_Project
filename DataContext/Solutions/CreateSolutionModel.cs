namespace DataContext.Solutions;

public class CreateSolutionModel
{
    public int ExerciseId { get; set; }
    public int AuthorId { get; set; }
    
    public DateTime CreatedAt { get; set; }
    public string? VersionDescription { get; set; }
    public int? FromSolution { get; set; }
    
    public string? Html { get; set; }
    public string? Css { get; set; }
    public string? Js { get; set; }
}