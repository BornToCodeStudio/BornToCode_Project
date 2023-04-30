namespace DataContext.Solutions;

public class SolutionModel
{
    public int Id { get; set; }
    public int ExerciseId { get; set; }
    public int AuthorId { get; set; }
    
    public DateTime CreatedAt { get; set; }
    public bool IsCurrent { get; set; }
    public string? VersionDescription { get; set; }
    public int? FromSolution { get; set; }
    
    public string? Html { get; set; }
    public string? Css { get; set; }
    public string? Js { get; set; }
}