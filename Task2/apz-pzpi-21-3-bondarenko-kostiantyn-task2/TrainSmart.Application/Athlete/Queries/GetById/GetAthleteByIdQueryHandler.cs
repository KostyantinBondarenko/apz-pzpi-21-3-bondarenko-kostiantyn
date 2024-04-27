using AutoMapper;
using MediatR;
using TrainSmart.Application.Abstractions.Persistence;
using TrainSmart.Common.DTOs.Athlete;

namespace TrainSmart.Application.Athlete.Queries.GetById;

public class GetAthleteByIdQueryHandler: IRequestHandler<GetAthleteByIdQuery, AthleteDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAthleteByIdQueryHandler(
        IUnitOfWork unitOfWork, 
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<AthleteDto> Handle(GetAthleteByIdQuery request, CancellationToken cancellationToken)
    {
        var athlete = await _unitOfWork
            .GetRepository<IAthleteRepository>()
            .GetByIdAsync(request.Id, true, cancellationToken);
        if (athlete is null)
        {
            throw new ApplicationException("Athlete was not found");
        }

        return _mapper.Map<AthleteDto>(athlete);
    }
}