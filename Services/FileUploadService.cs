public class FileUploadService
{
	private readonly IWebHostEnvironment _hostingEnvironment;

	public FileUploadService(IWebHostEnvironment hostingEnvironment)
	{
		_hostingEnvironment = hostingEnvironment;
	}

	public string UploadFile(IFormFile file, string folderName)
	{
		if (file != null && file.Length > 0)
		{
			var uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images", folderName);
			if (!Directory.Exists(uploadsFolder))
			{
				Directory.CreateDirectory(uploadsFolder);
			}

			var fileName = Path.GetFileName(file.FileName);
			var filePath = Path.Combine(uploadsFolder, fileName);

			using (var fileStream = new FileStream(filePath, FileMode.Create))
			{
				file.CopyTo(fileStream);
			}

			return $"/images/{folderName}/{fileName}";
		}
		return null;
	}
}
