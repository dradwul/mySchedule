namespace AutoLife.Domain.Models;

public class WeeklyPlan
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public List<WeeklyPlanItem> Items { get; set; } = [];
}
