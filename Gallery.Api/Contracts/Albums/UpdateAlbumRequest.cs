using System.ComponentModel.DataAnnotations;

namespace Gallery.Contracts.Albums;

public record UpdateAlbumRequest(
    [Required] string Title);