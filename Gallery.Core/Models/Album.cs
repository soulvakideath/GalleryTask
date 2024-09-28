namespace Gallery.Core.Models;

public class Album
{
    private readonly List<Photo> _photos = [];

    private Album(
        Guid id,
        string title)
    {
        Id = id;
        Title = title;
    }
    
    public Guid Id { get; }
    
    public string Title { get; } = string.Empty;

    public IReadOnlyList<Photo>? Photos => _photos;

    public static Album Create(Guid id, string title)
    {
        if (string.IsNullOrEmpty(title)) throw new ArgumentException("Title cannot be null!");
        return new Album(id, title);
    }
}