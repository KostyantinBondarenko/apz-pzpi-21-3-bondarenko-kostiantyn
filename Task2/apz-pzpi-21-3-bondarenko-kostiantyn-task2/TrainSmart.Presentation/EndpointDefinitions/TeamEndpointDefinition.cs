using MediatR;
using Microsoft.AspNetCore.Mvc;
using TrainSmart.Application.Team.Commands.AddAthlete;
using TrainSmart.Application.Team.Commands.Create;
using TrainSmart.Application.Team.Commands.RemoveAthlete;
using TrainSmart.Application.Team.Queries.GetAll;
using TrainSmart.Application.Team.Queries.GetById;
using TrainSmart.Common.Requests.Team;
using TrainSmart.Presentation.Abstractions;

namespace TrainSmart.Presentation.EndpointDefinitions;

public class TeamEndpointDefinition: IEndpointDefinition
{
    public void RegisterEndpoints(WebApplication app)
    {
        var teamGroup = app.MapGroup("/api/teams");

        teamGroup.MapGet("/", GetAllTeams);
        teamGroup.MapGet("/{id}", GetTeamById);
        teamGroup.MapPost("/", CreateTeam);
        teamGroup.MapPost("/{id}/athletes", AddAthleteToTeam);
        teamGroup.MapDelete("/{id}/athletes", RemoveAthleteFromTeam);
    }

    private static async Task<IResult> GetAllTeams(
        IMediator mediator)
    {
        var teams = await mediator.Send(new GetAllTeamsQuery());
        return Results.Ok(teams);
    }
    
    private static async Task<IResult> GetTeamById(
        IMediator mediator,
        [FromRoute] Guid id)
    {
        var team = await mediator.Send(new GetTeamByIdQuery(id));
        return Results.Ok(team);
    }
    
    private static async Task<IResult> CreateTeam(
        IMediator mediator,
        [FromBody] CreateTeamCommand createTeamCommand)
    {
        var team = await mediator.Send(createTeamCommand);
        return Results.Ok(team);
    }
    
    private static async Task<IResult> AddAthleteToTeam(
        IMediator mediator,
        [FromRoute] Guid id,
        [FromBody] AddAthleteToTeamRequest addAthleteToTeamRequest)
    {
        await mediator.Send(new AddAthleteToTeamCommand(id, addAthleteToTeamRequest.AthleteId));
        return Results.NoContent();
    }

    private static async Task<IResult> RemoveAthleteFromTeam(
        IMediator mediator,
        [FromRoute] Guid id,
        [FromBody] RemoveAthleteFromTeamRequest removeAthleteFromTeamRequest)
    {
        await mediator.Send(new RemoveAthleteFromTeamCommand(id, removeAthleteFromTeamRequest.AthleteId));
        return Results.NoContent();
    }
}