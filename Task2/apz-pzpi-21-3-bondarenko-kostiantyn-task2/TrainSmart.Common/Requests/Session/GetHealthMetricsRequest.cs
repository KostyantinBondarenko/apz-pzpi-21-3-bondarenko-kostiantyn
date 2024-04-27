using TrainSmart.Domain.Enums;

namespace TrainSmart.Common.Requests.Session;

public class GetHealthMetricsRequest
{
    public Guid? TeamAthleteId { get; set; }
    public HealthMetricType? MetricType { get; set; }
    public DateTime? DateFrom { get; set; }
    public DateTime? DateTo { get; set; }
}