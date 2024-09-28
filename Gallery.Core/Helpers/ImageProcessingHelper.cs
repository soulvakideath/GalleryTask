using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;

namespace Gallery.Core.Helpers;

public static class ImageProcessingHelper
{
    public static string ResizeImageToBase64(byte[] imageBytes, int maxWidth, int maxHeight)
    {
        // Load the image from the byte array
        using var inputStream = new MemoryStream(imageBytes);
        using var image = Image.Load(inputStream);

        // Perform image resizing
        image.Mutate(x => x.Resize(new ResizeOptions
        {
            Mode = ResizeMode.Max,
            Size = new Size(maxWidth, maxHeight)
        }));

        // Convert the image to a Base64 string
        using var outputStream = new MemoryStream();
        image.Save(outputStream, new JpegEncoder()); // Save as JPEG
        var resizedImageBytes = outputStream.ToArray();

        return Convert.ToBase64String(resizedImageBytes);
    }
}