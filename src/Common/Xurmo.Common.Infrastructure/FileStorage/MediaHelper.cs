namespace Xurmo.Common.Infrastructure.FileStorage;
#pragma warning disable CA1052 // Static holder types should be Static or NotInheritable
public class MediaHelper
#pragma warning restore CA1052 // Static holder types should be Static or NotInheritable
{
    public static string MakeImageName(string filename)
    {
        var fileInfo = new FileInfo(filename);
        string extension = fileInfo.Extension;
        string name = "IMG_" + Guid.NewGuid() + extension;
        return name;
    }

    public static string[] GetImageExtensions()
    {
        return new string[]
        {
            // JPG files
            ".jpg", ".jpeg",
            // Png files
            ".png",
            // Bmp files
            ".bmp",
            // Svg files
            ".svg"
        };
    }
}
