using Imagekit.Sdk;

namespace SoloProject.Services;

public interface IImagekitAPIService
{
    Task<string> UploadImageAsync(IFormFile imageFile);
}

public class ImagekitAPIService : IImagekitAPIService
{
    private readonly ImagekitClient _imagekit;
    private readonly IConfiguration _configuration;
    private readonly string _privateKey;

    public ImagekitAPIService(IConfiguration configuration)
    {
        _configuration = configuration;
        _privateKey = _configuration["private_MkeLXX1O2Vt0M2rEj9/oo+F+0zY="]!;
        _imagekit = new ImagekitClient(
            "public_yO/NHtyEtaaUBTpXM+7RJ+sC/uQ=", // change to your public key
            "private_MkeLXX1O2Vt0M2rEj9/oo+F+0zY=",
            "https://ik.imagekit.io/ddwtaiztt/" // change to your endpoint
        );
    }

    public async Task<string> UploadImageAsync(IFormFile imageFile)
    {
        if (imageFile == null || imageFile.Length == 0)
        {
            throw new ArgumentException("Invalid image file.");
        }

        var base64Image = await ConvertToBase64Async(imageFile);
        var fileName = Path.GetRandomFileName() + Path.GetExtension(imageFile.FileName);
        var request = new FileCreateRequest()
        {
            file = base64Image,
            fileName = fileName,
            // folder = "collection_imgs", 
        };

        var response = await _imagekit.UploadAsync(request);

        if (response.HttpStatusCode != 200)
        {
            throw new Exception("Image upload failed.");
        }

        return response.url;
    }

    public async Task<string> ConvertToBase64Async(IFormFile? file)
    {
        if (file == null || file.Length == 0)
        {
            throw new ArgumentException("Invalid file.");
        }

        using var memoryStream = new MemoryStream();
        await file.CopyToAsync(memoryStream);
        var fileBytes = memoryStream.ToArray();
        return Convert.ToBase64String(fileBytes);
    }
}