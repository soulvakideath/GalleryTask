using System.ComponentModel.DataAnnotations;

namespace Gallery.Contracts.Photos;

public record CreatePhotoRequest(
    [Required] string url);