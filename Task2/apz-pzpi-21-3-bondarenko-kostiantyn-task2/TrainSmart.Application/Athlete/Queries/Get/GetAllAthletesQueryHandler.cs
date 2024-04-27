using AutoMapper;
using MediatR;
using TrainSmart.Application.Abstractions.Persistence;
using TrainSmart.Common.DTOs.Athlete;

namespace TrainSmart.Application.Athlete.Queries.Get;

public class GetAllAthletesQueryHandler: IRequestHandler<GetAllAthletesQuery, List<AthleteDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllAthletesQueryHandler(
        IUnitOfWork unitOfWork, 
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<AthleteDto>> Handle(GetAllAthletesQuery request, CancellationToken cancellationToken)
    {
        var athletes = await _unitOfWork
            .GetRepository<IAthleteRepository>()
            .GetAllAsync(true, cancellationToken);

        return _mapper.Map<List<AthleteDto>>(athletes);
    }
}