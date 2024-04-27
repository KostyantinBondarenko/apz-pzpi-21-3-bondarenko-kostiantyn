using TrainSmart.Application.Abstractions.Persistence;
using TrainSmart.Domain.AggregateRoots;
using TrainSmart.Domain.Entities;
using TrainSmart.Persistence.Context;

namespace TrainSmart.Persistence.Repositories;

public class AthleteRepository: GenericRepository<Athlete>, IAthleteRepository
{
    public AthleteRepository(AppDbContext context) : base(context)
    {
    }
}