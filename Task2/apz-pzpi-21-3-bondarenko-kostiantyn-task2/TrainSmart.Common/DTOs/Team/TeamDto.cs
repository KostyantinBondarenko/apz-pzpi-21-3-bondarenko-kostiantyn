namespace TrainSmart.Common.DTOs.Team;

public class TeamDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string? CountryName { get; set; } = default;
    public Guid SportId { get; set; }
}