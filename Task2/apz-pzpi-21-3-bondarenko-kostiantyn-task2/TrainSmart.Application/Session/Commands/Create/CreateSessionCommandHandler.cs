using AutoMapper;
using MediatR;
using TrainSmart.Application.Abstractions.Persistence;
using TrainSmart.Common.DTOs.Session;

namespace TrainSmart.Application.Session.Commands.Create;

public class CreateSessionCommandHandler: IRequestHandler<CreateSessionCommand, SessionDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateSessionCommandHandler(
        IUnitOfWork unitOfWork, 
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<SessionDto> Handle(
        CreateSessionCommand request, 
        CancellationToken cancellationToken)
    {
        var team = await _unitOfWork
            .GetRepository<ITeamRepository>()
            .GetByIdAsync(request.TeamId, false, cancellationToken);
        if (team is null)
        {
            throw new ApplicationException("Team was not found");
        }

        var session = new Domain.AggregateRoots.Session(team.Id, request.Duration);

        await _unitOfWork
            .GetRepository<ISessionRepository>()
            .CreateAsync(session, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map<SessionDto>(session);
    }
}