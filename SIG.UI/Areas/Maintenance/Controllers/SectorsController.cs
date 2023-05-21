using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SIG.Core.Domain;
using SIG.Core.Domain.Interfaces;
using SIG.Services;

namespace SIG.UI.Areas.Maintenance
{
    [Area("Maintenance")]
    public class SectorsController : Controller
    {
        private readonly ISectorRepository _sector;
        private readonly IMapper _mapper;

        public SectorsController(IMapper mapper, ISectorRepository sector)
        {

            _mapper = mapper;
            _sector = sector;
        }

        /* public async Task<IActionResult> Index()
         {
             var br = await _sector.GetAll();
             var brm = _mapper.Map<IEnumerable<SectorViewModel>>(br);

             return View(brm);
         }*/
        [Route("/Maintenance/sectors")]
        public async Task<IActionResult> Index(string searchString)
        {
            var str = searchString.IsNullOrEmpty() ? "" : searchString;
            var br = await _sector.GetByQueryReturnIEnumerable(x=>x.Name.Contains(str));
            var brm = _mapper.Map<IEnumerable<SectorViewModel>>(br);

            return View(brm);
        }
        public async Task<IActionResult> Details(Guid id)
        {

            return View(_mapper.Map<SectorViewModel>(await _sector.GetById(id)));
        }
        public async Task<IActionResult> Create()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(SectorViewModel model)
        {
            if (!ModelState.IsValid) return View();

            await _sector.Add(_mapper.Map<Sector>(model));
            return RedirectToAction(nameof(Index));
        }

       
        public async Task<IActionResult> Edit(Guid id)
        {

            return View(_mapper.Map<SectorViewModel>(await _sector.GetById(id)));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(SectorViewModel model)
        {
            if (!ModelState.IsValid) return View();

            await _sector.Update(_mapper.Map<Sector>(model));
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(Guid id)
        {

            return View(_mapper.Map<SectorViewModel>(await _sector.GetById(id)));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(SectorViewModel model)
        {
            

            await _sector.Remove(model.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
