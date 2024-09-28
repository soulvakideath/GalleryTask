using System.ComponentModel.DataAnnotations;

namespace Gallery.Contracts.Albums;

public record CreateAlbumsRequest(
    [Required] string Title);
