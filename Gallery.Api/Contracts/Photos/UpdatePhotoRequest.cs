using System.ComponentModel.DataAnnotations;

namespace Gallery.Contracts.Photos;

public record UpdatePhotoRequest(
    [Required] string url);