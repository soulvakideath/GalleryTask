using System.Security.Claims;
using Gallery.Contracts.Photos;
using Gallery.Infrastructure.Authentication;

namespace Gallery.Endpoints;
using Gallery.Application.Services;
using Gallery.Core.Models;
using Microsoft.AspNetCore.Mvc;


public static class PhotoEndpoints
{
    public static IEndpointRouteBuilder MapPhotosEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("photos/{albumId:guid}", CreatePhoto);

        app.MapGet("photos/album/{albumId:guid}", GetPhotos);

        app.MapGet("photos/{id:guid}", GetPhotoById);

        app.MapPut("photos/{id:guid}", UpdatePhoto);

        app.MapDelete("photos/{id:guid}", DeletePhoto);

        return app;
    }

    private static async Task<IResult> CreatePhoto(
        [FromRoute] Guid albumId,
        [FromBody] CreatePhotoRequest request,
        PhotoService photoService)
    {
        var photo = Photo.Create(
            Guid.NewGuid(),
            albumId,
            request.url);

        await photoService.CreatePhoto(photo);

        return Results.Ok();
    }

    private static async Task<IResult> GetPhotos(
        [FromRoute] Guid albumId,
        PhotoService photoService)
    {
        var photos = await photoService.GetPhotos(albumId);

        var response = photos
            .Select(p => new GetPhotosReponse(p.Id, p.AlbumId, p.Url));

        return Results.Ok(response);
    }

    private static async Task<IResult> GetPhotoById(
        [FromRoute] Guid id,
        PhotoService photoService)
    {
        var photo = await photoService.GetPhotoByID(id);

        var response = new GetPhotosReponse(photo.Id, photo.AlbumId, photo.Url);

        return Results.Ok(response);
    }

    private static async Task<IResult> UpdatePhoto(
        [FromRoute] Guid id,
        [FromBody] UpdatePhotoRequest request,
        PhotoService photoService)
    {
        await photoService.UpdatePhoto(
            id,
            request.url);

        return Results.Ok();
    }

    private static async Task<IResult> DeletePhoto(
        [FromRoute] Guid id,
        PhotoService photoService)
    {
        await photoService.DeletePhoto(id);

        return Results.Ok();
    }
}
