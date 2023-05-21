using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SIG.Core.Domain;
using SIG.Core.Domain.Interfaces;
using SIG.Services;
using SIG.UI.Base;

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

        /* public async Task<IActionResult> Index()
         {
             var br = await _brand.GetAll();
             var brm = _mapper.Map<IEnumerable<BrandViewModel>>(br);

             return View(brm);
         }*/
        [Route("/Maintenance/brands")]
        public async Task<IActionResult> Index(string searchString)
        {
            
            var str = searchString.IsNullOrEmpty() ? "" : searchString;
            var br = await _brand.GetByQueryReturnIEnumerable(x=>x.Name.Contains(str));
            var brm = _mapper.Map<IEnumerable<BrandViewModel>>(br);
        
                return View(brm);
        }
        public async Task<IActionResult> Details(Guid id)
        {

            return View(_mapper.Map<BrandViewModel>(await _brand.GetById(id)));
        }
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

       
        public async Task<IActionResult> Edit(Guid id)
        {

            return View(_mapper.Map<BrandViewModel>(await _brand.GetById(id)));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(BrandViewModel model)
        {
            if (!ModelState.IsValid) return View();

            await _brand.Update(_mapper.Map<Brand>(model));
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(Guid id)
        {

            return View(_mapper.Map<BrandViewModel>(await _brand.GetById(id)));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(BrandViewModel model)
        {
            

            await _brand.Remove(model.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
