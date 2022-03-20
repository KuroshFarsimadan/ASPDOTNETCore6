using ASPNET6Tutorial.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace ASPNET6Tutorial.Controllers
{
    [ApiController]
    [Authorize(Policy = "MustBeFromTehran")]
    // [controller] = api/files
    [Route("api/v{version:apiVersion}/files")]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    public class FilesController : ControllerBase
    {
        private readonly FileExtensionContentTypeProvider _fileExtensionContentTypeProvider;
        public FilesController(FileExtensionContentTypeProvider fileExtensionContentTypeProvider)
        {
            _fileExtensionContentTypeProvider = fileExtensionContentTypeProvider ?? throw new System.ArgumentNullException
                (nameof(fileExtensionContentTypeProvider));
        }

        [HttpGet("{fieldId}")]
        public ActionResult GetFile (string fileId)
        {
            // File id will be used to find the file. For demo purposes, the file is static
            var pathToFile = "soa-basics.pdf";

            // If the file was not found
            if(!System.IO.File.Exists(pathToFile))
            {
                return NotFound();
            }

            // The following section will get the file type based on the path
            if(!_fileExtensionContentTypeProvider.TryGetContentType(pathToFile, out var contentType))
            {
                contentType = "application/octet-stream";
            }

            // Read the file as bytes
            var bytes = System.IO.File.ReadAllBytes(pathToFile);

            return File(bytes, contentType, Path.GetFileName(pathToFile));
        }
    }
}
