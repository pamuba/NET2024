using Azure_blob_demo.Models;
using Azure_blob_demo.Services;
using Microsoft.AspNetCore.Mvc;

namespace Azure_blob_demo.Controllers
{
    public class BlobController : Controller
    {
        private readonly IBlobService _blobService;

        public BlobController(IBlobService blobService)
        {
            _blobService = blobService;
        }
        [HttpGet]
        public async Task<IActionResult> Manage(string containerName)
        {
            var blobObjs = await _blobService.GetAllBlobs(containerName);
            return View(blobObjs);
        }
        [HttpGet]
        public IActionResult AddFile(string containerName)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddFile(string containerName, Blob blob, IFormFile file)
        {
            if (file == null || file.Length < 1) { return View(); }
            var fileName = Path.GetFileNameWithoutExtension(file.FileName) + "_" + Guid.NewGuid() + Path.GetExtension(file.FileName);
            var result = await _blobService.UploadBlob(fileName, file, containerName, blob);
            if (result)
                return RedirectToAction("Index", "Container");

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> ViewFile(string name, string containerName)
        {
            return Redirect(await _blobService.GetBlob(name, containerName));
        }
        public IActionResult DeleteFile(string name, string containerName)
        {
            var res = _blobService.DeleteBlob(name, containerName);
            return RedirectToAction("Index", "Home");
        }
    }
}
