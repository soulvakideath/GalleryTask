using Gallery.Application.Services;
using Gallery.Contracts.Albums;
using Gallery.Core.Enums;
using Gallery.Core.Models;
using Gallery.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Gallery.Endpoints;

public static class AlbumEndpoints
{
    public static IEndpointRouteBuilder MapAlbumsEndpoints(this IEndpointRouteBuilder app)
    {
        var endpoints = app.MapGroup("album");

        endpoints.MapPost(string.Empty, CreateAlbum)
            .RequirePermissions(Permission.Create);

        endpoints.MapGet(string.Empty, GetAlbums)
            .RequirePermissions(Permission.Read);

        endpoints.MapGet("{id:guid}", GetAlbumById)
            .RequirePermissions(Permission.Read);

        endpoints.MapPut("{id:guid}", UpdateAlbum)
            .RequirePermissions(Permission.Update);

        endpoints.MapDelete("{id:guid}", DeleteAlbum)
            .RequirePermissions(Permission.Delete);

        return endpoints;
    }

    private static async Task<IResult> CreateAlbum(
        [FromBody] CreateAlbumsRequest request,
        HttpContext context,
        AlbumService albumsService)
    {
        var album = Album.Create(
            Guid.NewGuid(),
            request.Title);

        await albumsService.CreateAlbum(album);

        return Results.Ok();
    }

    private static async Task<IResult> GetAlbums(
        AlbumService albumsService, HttpContext context)
    {
        var albums = await albumsService.GetAlbums();

        var response = albums
            .Select(a => new GetAlbumsResponse(a.Id, a.Title));

        return Results.Ok(response);
    }

    private static async Task<IResult> GetAlbumById(
        [FromRoute] Guid id,
        AlbumService albumsService)
    {
        var album = await albumsService.GetAlbumById(id);

        var response = new GetAlbumsResponse(album.Id, album.Title);

        return Results.Ok(response);
    }

    private static async Task<IResult> UpdateAlbum(
        [FromRoute] Guid id,
        [FromBody] UpdateAlbumRequest request,
        AlbumService albumsService)
    {
        await albumsService.UpdateAlbum(id, request.Title);

        return Results.Ok();
    }

    private static async Task<IResult> DeleteAlbum(
        [FromRoute] Guid id,
        AlbumService albumsService)
    {
        await albumsService.DeleteAlbum(id);

        return Results.Ok();
    }
}