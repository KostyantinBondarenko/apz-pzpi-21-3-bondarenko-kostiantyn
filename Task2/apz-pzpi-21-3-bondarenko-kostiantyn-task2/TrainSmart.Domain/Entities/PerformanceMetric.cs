﻿using TrainSmart.Domain.Enums;

namespace TrainSmart.Domain.Entities;

public class PerformanceMetric: BaseEntity
{
    public Guid SessionId { get; private set; }
    public Guid TeamAthleteId { get; private set; }
    public PerformanceMetricType MetricType { get; private set; }
    public double MetricValue { get; private set; }
    public DateTime TimeStamp { get; private set; }
    
    public PerformanceMetric(
        Guid sessionId, 
        Guid teamAthleteId, 
        PerformanceMetricType metricType, 
        double metricValue) : base(Guid.Empty)
    {
        SessionId = sessionId;
        TeamAthleteId = teamAthleteId;
        MetricType = metricType;
        MetricValue = metricValue;
        TimeStamp = DateTime.UtcNow;
    }
}