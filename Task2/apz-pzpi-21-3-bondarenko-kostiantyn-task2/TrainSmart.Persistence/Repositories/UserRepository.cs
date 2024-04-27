using TrainSmart.Application.Abstractions.Persistence;
using TrainSmart.Domain.AggregateRoots;
using TrainSmart.Domain.Entities;
using TrainSmart.Persistence.Context;

namespace TrainSmart.Persistence.Repositories;

public class UserRepository: GenericRepository<User>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }
}