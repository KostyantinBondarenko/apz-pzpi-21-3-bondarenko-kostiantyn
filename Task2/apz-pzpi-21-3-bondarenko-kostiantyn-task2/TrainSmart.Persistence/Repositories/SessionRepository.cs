using Microsoft.EntityFrameworkCore;
using TrainSmart.Application.Abstractions.Persistence;
using TrainSmart.Domain.AggregateRoots;
using TrainSmart.Persistence.Context;

namespace TrainSmart.Persistence.Repositories;

public class SessionRepository: GenericRepository<Session>, ISessionRepository
{
    public SessionRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Session>> GetByTeamId(
        Guid teamId, 
        bool asNoTracking, 
        CancellationToken cancellationToken = default)
    {
        return asNoTracking
            ? await DbSet.AsNoTracking().Where(x => x.TeamId == teamId).ToListAsync(cancellationToken)
            : await DbSet.Where(x => x.TeamId == teamId).ToListAsync(cancellationToken);
    }
}