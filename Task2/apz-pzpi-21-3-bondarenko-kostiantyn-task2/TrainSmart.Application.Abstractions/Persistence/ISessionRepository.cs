using TrainSmart.Domain.AggregateRoots;

namespace TrainSmart.Application.Abstractions.Persistence;

public interface ISessionRepository: IGenericRepository<Session>
{
    Task<IEnumerable<Session>> GetByTeamId(Guid teamId, bool asNoTracking, CancellationToken cancellationToken = default);
}