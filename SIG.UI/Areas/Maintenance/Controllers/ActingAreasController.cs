using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SIG.Core.Domain;
using SIG.Core.Domain.Interfaces;
using SIG.Services;

namespace SIG.UI.Areas.Maintenance
{
    [Area("Maintenance")]
    public class ActingAreasController : Controller
    {
        private readonly IActingAreaRepository _actingArea;
        private readonly IMapper _mapper;

        public ActingAreasController(IMapper mapper, IActingAreaRepository actingArea)
        {

            _mapper = mapper;
            _actingArea = actingArea;
        }

        /* public async Task<IActionResult> Index()
         {
             var br = await _actingArea.GetAll();
             var brm = _mapper.Map<IEnumerable<ActingAreaViewModel>>(br);

             return View(brm);
         }*/
        [Route("/Maintenance/actingAreas")]
        public async Task<IActionResult> Index(string searchString)
        {
            var str = searchString.IsNullOrEmpty() ? "" : searchString;
            var br = await _actingArea.GetByQueryReturnIEnumerable(x=>x.Name.Contains(str));
            var brm = _mapper.Map<IEnumerable<ActingAreaViewModel>>(br);

            return View(brm);
        }
        public async Task<IActionResult> Details(Guid id)
        {

            return View(_mapper.Map<ActingAreaViewModel>(await _actingArea.GetById(id)));
        }
        [HttpGet]
        [Route("/Maintenance/actingAreas/create")]
        public async Task<IActionResult> Create()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ActingAreaViewModel model)
        {
            if (!ModelState.IsValid) return View();

            await _actingArea.Add(_mapper.Map<ActingArea>(model));
            return RedirectToAction(nameof(Index));
        }

       
        public async Task<IActionResult> Edit(Guid id)
        {

            return View(_mapper.Map<ActingAreaViewModel>(await _actingArea.GetById(id)));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ActingAreaViewModel model)
        {
            if (!ModelState.IsValid) return View();

            await _actingArea.Update(_mapper.Map<ActingArea>(model));
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(Guid id)
        {

            return View(_mapper.Map<ActingAreaViewModel>(await _actingArea.GetById(id)));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(ActingAreaViewModel model)
        {
            

            await _actingArea.Remove(model.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
