using AutoMapper;
using MediatR;
using TrainSmart.Application.Abstractions.Persistence;
using TrainSmart.Common.DTOs.HealthMetric;

namespace TrainSmart.Application.Session.Queries.GetHealthMetrics;

public class GetHealthMetricsQueryHandler: IRequestHandler<GetHealthMetricsQuery, List<HealthMetricDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetHealthMetricsQueryHandler(
        IUnitOfWork unitOfWork, 
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<HealthMetricDto>> Handle(
        GetHealthMetricsQuery request, 
        CancellationToken cancellationToken)
    {
        var session = await _unitOfWork
            .GetRepository<ISessionRepository>()
            .GetByIdAsync(request.SessionId, true, cancellationToken);
        if (session is null)
        {
            throw new ApplicationException("Session was not found");
        }

        var healthMetrics = session.HealthMetrics.AsEnumerable();

        if (request.TeamAthleteId is not null)
        {
            healthMetrics = healthMetrics
                .Where(x => x.TeamAthleteId == request.TeamAthleteId);
        }

        if (request.MetricType is not null)
        {
            healthMetrics = healthMetrics
                .Where(x => x.MetricType == request.MetricType);
        }

        if (request.DateFrom is not null)
        {
            healthMetrics = healthMetrics
                .Where(x => x.TimeStamp >= request.DateFrom);
        }

        if (request.DateTo is not null)
        {
            healthMetrics = healthMetrics
                .Where(x => x.TimeStamp <= request.DateTo);
        }

        return _mapper.Map<List<HealthMetricDto>>(healthMetrics);
    }
}