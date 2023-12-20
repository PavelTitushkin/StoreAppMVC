using Microsoft.AspNetCore.Mvc;
using StoreApp_Core.Contracts;
using StoreApp_Core.DTOs;
using StoreAppMVC.Models.Providers;

namespace StoreAppMVC.Controllers
{
    public class ProvidersController : Controller
    {
        private readonly IProviderService _providerService;

        public ProvidersController(IProviderService providerService)
        {
            _providerService = providerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProviders()
        {
            var dtos = await _providerService.GetAllProvidersAsync();

            return View(dtos);
        }

        [HttpGet]
        public async Task<IActionResult> CreateProvider()
        {
            var model = new ProviderModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProvider(ProviderModel model)
        {
            if (ModelState.IsValid)
            {
                var dto = new ProviderDTO()
                {
                    Name = model.Name,
                };
                await _providerService.CreateProviderAsync(dto);

                return RedirectToAction("GetAllProviders");
            }

            return View(model);
        }
    }
}
