using TrainSmart.Application.Abstractions.Persistence;
using TrainSmart.Domain.AggregateRoots;
using TrainSmart.Domain.Entities;
using TrainSmart.Persistence.Context;

namespace TrainSmart.Persistence.Repositories;

public class SportRepository: GenericRepository<Sport>, ISportRepository
{
    public SportRepository(AppDbContext context) : base(context)
    {
    }
}