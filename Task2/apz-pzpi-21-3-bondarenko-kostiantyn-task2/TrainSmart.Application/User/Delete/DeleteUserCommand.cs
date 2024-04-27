using MediatR;

namespace TrainSmart.Application.User.Delete;

public record DeleteUserCommand(
    Guid Id): IRequest<Unit>;