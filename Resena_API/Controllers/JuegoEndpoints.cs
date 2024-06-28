using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using Resena_API.Data;
using Resena_API.Data.Models;
namespace Resena_API.Controllers;

public static class JuegoEndpoints
{
    public static void MapJuegoEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Juego").WithTags(nameof(Juego));

        group.MapGet("/", async (Resena_APIContext db) =>
        {
            return await db.Juego.ToListAsync();
        })
        .WithName("GetAllJuegos")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Juego>, NotFound>> (int id, Resena_APIContext db) =>
        {
            return await db.Juego.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is Juego model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetJuegoById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, Juego juego, Resena_APIContext db) =>
        {
            var affected = await db.Juego
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Id, juego.Id)
                    .SetProperty(m => m.Nombre, juego.Nombre)
                    .SetProperty(m => m.Descripcion, juego.Descripcion)
                    .SetProperty(m => m.FechaCreacion, juego.FechaCreacion)
                    .SetProperty(m => m.UrlImagen, juego.UrlImagen)
                    .SetProperty(m => m.CategoriaId, juego.CategoriaId)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateJuego")
        .WithOpenApi();

        group.MapPost("/", async (Juego juego, Resena_APIContext db) =>
        {
            db.Juego.Add(juego);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Juego/{juego.Id}",juego);
        })
        .WithName("CreateJuego")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, Resena_APIContext db) =>
        {
            var affected = await db.Juego
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteJuego")
        .WithOpenApi();
    }
}
