using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SIG.Core.Domain;
using SIG.Core.Domain.Interfaces;
using SIG.Services;

namespace SIG.UI.Areas.Maintenance
{
    [Area("Maintenance")]
    public class EquipTypesController : Controller
    {
        private readonly IEquipTypeRepository _equipType;
        private readonly IMapper _mapper;

        public EquipTypesController(IMapper mapper, IEquipTypeRepository equipType)
        {

            _mapper = mapper;
            _equipType = equipType;
        }

        /* public async Task<IActionResult> Index()
         {
             var br = await _equipType.GetAll();
             var brm = _mapper.Map<IEnumerable<EquipTypeViewModel>>(br);

             return View(brm);
         }*/
        [Route("/Maintenance/equipTypes")]
        public async Task<IActionResult> Index(string searchString)
        {
            var str = searchString.IsNullOrEmpty() ? "" : searchString;
            var br = await _equipType.GetByQueryReturnIEnumerable(x=>x.Name.Contains(str));
            var brm = _mapper.Map<IEnumerable<EquipTypeViewModel>>(br);

            return View(brm);
        }
        public async Task<IActionResult> Details(Guid id)
        {

            return View(_mapper.Map<EquipTypeViewModel>(await _equipType.GetById(id)));
        }
        public async Task<IActionResult> Create()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(EquipTypeViewModel model)
        {
            if (!ModelState.IsValid) return View();

            await _equipType.Add(_mapper.Map<EquipType>(model));
            return RedirectToAction(nameof(Index));
        }

       
        public async Task<IActionResult> Edit(Guid id)
        {

            return View(_mapper.Map<EquipTypeViewModel>(await _equipType.GetById(id)));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EquipTypeViewModel model)
        {
            if (!ModelState.IsValid) return View();

            await _equipType.Update(_mapper.Map<EquipType>(model));
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(Guid id)
        {

            return View(_mapper.Map<EquipTypeViewModel>(await _equipType.GetById(id)));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(EquipTypeViewModel model)
        {
            

            await _equipType.Remove(model.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
