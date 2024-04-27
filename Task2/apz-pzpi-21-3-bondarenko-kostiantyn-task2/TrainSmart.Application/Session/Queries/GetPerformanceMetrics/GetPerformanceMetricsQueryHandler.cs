using AutoMapper;
using MediatR;
using TrainSmart.Application.Abstractions.Persistence;
using TrainSmart.Common.DTOs.PerformanceMetric;

namespace TrainSmart.Application.Session.Queries.GetPerformanceMetrics;

public class GetPerformanceMetricsQueryHandler: IRequestHandler<GetPerformanceMetricsQuery, List<PerformanceMetricDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetPerformanceMetricsQueryHandler(
        IUnitOfWork unitOfWork, 
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<PerformanceMetricDto>> Handle(
        GetPerformanceMetricsQuery request, 
        CancellationToken cancellationToken)
    {
        var session = await _unitOfWork
            .GetRepository<ISessionRepository>()
            .GetByIdAsync(request.SessionId, true, cancellationToken);
        if (session is null)
        {
            throw new ApplicationException("Session was not found");
        }

        var performanceMetrics = session.PerformanceMetrics.AsEnumerable();

        if (request.TeamAthleteId is not null)
        {
            performanceMetrics = performanceMetrics
                .Where(x => x.TeamAthleteId == request.TeamAthleteId);
        }

        if (request.MetricType is not null)
        {
            performanceMetrics = performanceMetrics
                .Where(x => x.MetricType == request.MetricType);
        }

        if (request.DateFrom is not null)
        {
            performanceMetrics = performanceMetrics
                .Where(x => x.TimeStamp >= request.DateFrom);
        }

        if (request.DateTo is not null)
        {
            performanceMetrics = performanceMetrics
                .Where(x => x.TimeStamp <= request.DateTo);
        }

        return _mapper.Map<List<PerformanceMetricDto>>(performanceMetrics);
    }
}