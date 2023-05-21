using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Tokens;
using SIG.Core.Domain;
using SIG.Core.Domain.Interfaces;
using SIG.Services;

namespace SIG.UI.Areas.Maintenance
{
    [Area("Maintenance")]
    public class LocacitiesController : Controller
    {
        private readonly ILocacityRepository _locacity;
        private readonly IMapper _mapper;
        private readonly IActingAreaRepository _actingArea;
        public LocacitiesController(IMapper mapper, ILocacityRepository locacity, IActingAreaRepository actingAreaRepository)
        {

            _mapper = mapper;
            _locacity = locacity;
            _actingArea = actingAreaRepository;
        }

        /* public async Task<IActionResult> Index()
         {
             var br = await _locacity.GetAll();
             var brm = _mapper.Map<IEnumerable<LocacityViewModel>>(br);

             return View(brm);
         }*/
        [Route("/Maintenance/Locacities/")]
        public async Task<IActionResult> Index(string searchString)
        {
            var area = _mapper.Map<IEnumerable<ActingAreaViewModel>>(await _actingArea.GetAll());

            var str = searchString.IsNullOrEmpty() ? "" : searchString;
            var br = await _locacity.GetAllWithArea(x => x.Name.Contains(str));
            var brm = _mapper.Map<IEnumerable<LocacityViewModel>>(br);
            
            return View(brm);
        }
        public async Task<IActionResult> Details(Guid id)
        {

            return View(_mapper.Map<LocacityViewModel>(await _locacity.GetById(id)));
        }
        [HttpGet]
        [Route("/Maintenance/Locacities/Create")]
        public async Task<IActionResult> Create()
        {
            var areas = await _actingArea.GetAll();
            ViewBag.ActingAreaId = new SelectList(_mapper.Map<IEnumerable<ActingAreaViewModel>>(areas), "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(LocacityViewModel model)
        {
           ModelState.Remove("ActingArea.Name");
            model.ActingArea = null;
            if (!ModelState.IsValid) return View();

            await _locacity.Add(_mapper.Map<Locacity>(model));
            return RedirectToAction(nameof(Index));
        }

       
        public async Task<IActionResult> Edit(Guid id)
        {
            var areas = await _actingArea.GetAll();
            ViewBag.ActingAreaId = new SelectList(_mapper.Map<IEnumerable<ActingAreaViewModel>>(areas), "Id", "Name");

            return View(_mapper.Map<LocacityViewModel>(await _locacity.GetById(id)));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(LocacityViewModel model)
        {
            ModelState.Remove("ActingArea.Name");
            model.ActingArea = null;
            if (!ModelState.IsValid) return View();

            await _locacity.Update(_mapper.Map<Locacity>(model));
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(Guid id)
        {

            return View(_mapper.Map<LocacityViewModel>(await _locacity.GetById(id)));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(LocacityViewModel model)
        {
            

            await _locacity.Remove(model.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
