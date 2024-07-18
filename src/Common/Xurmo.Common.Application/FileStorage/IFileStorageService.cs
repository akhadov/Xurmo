using Microsoft.AspNetCore.Http;

namespace Xurmo.Common.Application.FileStorage;
public interface IFileStorageService
{
    public Task<string> UploadAsync(IFormFile image, CancellationToken cancellationToken = default);
    public Task<bool> DeleteAsync(string imageId);
}
