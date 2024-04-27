using AutoMapper;
using MediatR;
using TrainSmart.Application.Abstractions.Persistence;
using TrainSmart.Common.DTOs.Team;

namespace TrainSmart.Application.Team.Queries.GetAll;

public class GetAllTeamsQueryHandler: IRequestHandler<GetAllTeamsQuery, List<TeamDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllTeamsQueryHandler(
        IUnitOfWork unitOfWork, 
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<TeamDto>> Handle(GetAllTeamsQuery request, CancellationToken cancellationToken)
    {
        var teams = await _unitOfWork
            .GetRepository<ITeamRepository>()
            .GetAllAsync(true, cancellationToken);

        return _mapper.Map<List<TeamDto>>(teams);
    }
}