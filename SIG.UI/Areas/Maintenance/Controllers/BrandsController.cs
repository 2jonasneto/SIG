using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIG.Core.Domain;
using SIG.Core.Domain.Interfaces;
using SIG.Services;

namespace SIG.UI.Areas.Maintenance
{
    [Area("Maintenance")]
    public class BrandsController : Controller
    {
        private readonly IBrandRepository _brand;
        private readonly IMapper _mapper;

        public BrandsController(IMapper mapper, IBrandRepository brand)
        {

            _mapper = mapper;
            _brand = brand;
        }
        public async Task<IActionResult> Index()
        {
            var br = await _brand.GetAll();
            var brm = _mapper.Map<IEnumerable<BrandViewModel>>(br);

            return View(brm);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(BrandViewModel model)
        {
            if (!ModelState.IsValid) return View();

            await _brand.Add(_mapper.Map<Brand>(model));
            return RedirectToAction(nameof(Index));
        }
    }
}
