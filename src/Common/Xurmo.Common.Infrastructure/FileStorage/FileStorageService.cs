using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Xurmo.Common.Application.FileStorage;

namespace Xurmo.Common.Infrastructure.FileStorage;
public class FileStorageService : IFileStorageService
{
    private readonly string MEDIA = "media";
    private readonly string IMAGES = "images";
    private readonly string ROOTPATH;

    public FileStorageService(IWebHostEnvironment webHostEnvironment)
    {
        ROOTPATH = webHostEnvironment.WebRootPath;
    }

    public async Task<string> UploadAsync(IFormFile image, CancellationToken cancellationToken = default)
    {
        string newImageName = MediaHelper.MakeImageName(image.FileName);
        string subpath = Path.Combine(MEDIA, IMAGES, newImageName);
        string path = Path.Combine(ROOTPATH, subpath);

        var stream = new FileStream(path, FileMode.Create);
        await image.CopyToAsync(stream, cancellationToken);
        stream.Close();

        return subpath;
    }

    public async Task<bool> DeleteAsync(string imageId)
    {
        string path = Path.Combine(ROOTPATH, imageId);
        if (File.Exists(path))
        {
            await Task.Run(() =>
            {
                File.Delete(path);
            });
            return true;
        }
        else
        {
            return false;
        }
    }
}
