namespace Gallery.Persistence.Entities;

public class AlbumEntity
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public List<PhotoEntity> Photos { get; set; } = [];
}