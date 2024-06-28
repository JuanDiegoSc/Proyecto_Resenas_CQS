using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using Resena_API.Data;
using Resena_API.Data.Models;
namespace Resena_API.Controllers;

public static class ResenaEndpoints
{
    public static void MapResenaEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Resena").WithTags(nameof(Resena));

        group.MapGet("/", async (Resena_APIContext db) =>
        {
            return await db.Resena.ToListAsync();
        })
        .WithName("GetAllResenas")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Resena>, NotFound>> (int id, Resena_APIContext db) =>
        {
            return await db.Resena.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is Resena model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetResenaById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, Resena resena, Resena_APIContext db) =>
        {
            var affected = await db.Resena
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Id, resena.Id)
                    .SetProperty(m => m.Puntuacion, resena.Puntuacion)
                    .SetProperty(m => m.Comentario, resena.Comentario)
                    .SetProperty(m => m.FechaResena, resena.FechaResena)
                    .SetProperty(m => m.JuegoId, resena.JuegoId)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateResena")
        .WithOpenApi();

        group.MapPost("/", async (Resena resena, Resena_APIContext db) =>
        {
            db.Resena.Add(resena);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Resena/{resena.Id}",resena);
        })
        .WithName("CreateResena")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, Resena_APIContext db) =>
        {
            var affected = await db.Resena
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteResena")
        .WithOpenApi();
    }
}
