using TrainSmart.Domain.Enums;

namespace TrainSmart.Common.Requests.Session;

public class CreateHealthMetricRequest
{
    public Guid TeamAthleteId { get; set; }
    public HealthMetricType MetricType { get; set; }
    public double MetricValue { get; set; }
}