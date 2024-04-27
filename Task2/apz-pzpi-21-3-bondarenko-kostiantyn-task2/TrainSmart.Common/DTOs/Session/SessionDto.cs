namespace TrainSmart.Common.DTOs.Session;

public class SessionDto
{
    public Guid Id { get; set; }
    public Guid TeamId { get; set; }
    public int Duration { get; set; }
    public DateTime Date { get; set; }
}