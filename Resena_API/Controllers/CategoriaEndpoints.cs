using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using Resena_API.Data;
using Resena_API.Data.Models;
namespace Resena_API.Controllers;

public static class CategoriaEndpoints
{
    public static void MapCategoriaEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Categoria").WithTags(nameof(Categoria));

        group.MapGet("/", async (Resena_APIContext db) =>
        {
            return await db.Categoria.ToListAsync();
        })
        .WithName("GetAllCategoria")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Categoria>, NotFound>> (int id, Resena_APIContext db) =>
        {
            return await db.Categoria.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is Categoria model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetCategoriaById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, Categoria categoria, Resena_APIContext db) =>
        {
            var affected = await db.Categoria
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Id, categoria.Id)
                    .SetProperty(m => m.Nombre, categoria.Nombre)
                    .SetProperty(m => m.Orden, categoria.Orden)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateCategoria")
        .WithOpenApi();

        group.MapPost("/", async (Categoria categoria, Resena_APIContext db) =>
        {
            db.Categoria.Add(categoria);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Categoria/{categoria.Id}",categoria);
        })
        .WithName("CreateCategoria")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, Resena_APIContext db) =>
        {
            var affected = await db.Categoria
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteCategoria")
        .WithOpenApi();
    }
}
