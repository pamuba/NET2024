using Azure_blob_demo.Models;
using Azure_blob_demo.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Azure_blob_demo.Controllers
{
    public class HomeController : Controller
    {
        public IContainerService _containerService;
        private readonly IBlobService _blobService;

        public HomeController(IContainerService containerService, IBlobService blobService)
        {
            _containerService = containerService;
            _blobService = blobService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _containerService.GetAllContainerAndBlobs());
        }

        public async Task<IActionResult> Images()
        {
            return View(await _blobService.GetAllBlobsWithUri("images"));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}