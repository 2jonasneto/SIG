using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Tokens;
using SIG.Core.Domain;
using SIG.Core.Domain.Interfaces;
using SIG.Services;
using System.Numerics;

namespace SIG.UI.Areas.Maintenance
{
    [Area("Maintenance")]
    public class HistoricsController : Controller
    {
        private readonly IHistoricRepository _historic;
        private readonly IMapper _mapper;
        private readonly IComputerRepository _computer;
        public HistoricsController(IMapper mapper, IHistoricRepository historic, IComputerRepository computer)
        {

            _mapper = mapper;
            _historic = historic;
            _computer = computer;
        }

        /* public async Task<IActionResult> Index()
         {
             var br = await _historic.GetAll();
             var brm = _mapper.Map<IEnumerable<HistoricViewModel>>(br);

             return View(brm);
         }*/
        [Route("/Maintenance/historics")]
        public async Task<IActionResult> Index(string searchString)
        {
          

            var str = searchString.IsNullOrEmpty() ? "" : searchString;
            var br = await _historic.GetByQueryReturnIEnumerable(x=>x.Description.Contains(str));
            var brm = _mapper.Map<IEnumerable<HistoricViewModel>>(br);

            return View(brm);
        }
        public async Task<IActionResult> Details(Guid id)
        {

            return View(_mapper.Map<HistoricViewModel>(await _historic.GetById(id)));
        }
        public async Task<IActionResult> Create()
        {
            var computer = await _computer.GetAll();
            ViewBag.ComputerId = new SelectList(_mapper.Map<IEnumerable<ComputerViewModel>>(computer), "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(HistoricViewModel model)
        {
            if (!ModelState.IsValid) return View();

            await _historic.Add(_mapper.Map<Historic>(model));
            return RedirectToAction(nameof(Index));
        }

       
        public async Task<IActionResult> Edit(Guid id)
        {
            var computer = await _computer.GetAll();
            ViewBag.ComputerId = new SelectList(_mapper.Map<IEnumerable<ComputerViewModel>>(computer), "Id", "Name");

            return View(_mapper.Map<HistoricViewModel>(await _historic.GetById(id)));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(HistoricViewModel model)
        {
            if (!ModelState.IsValid) return View();

            await _historic.Update(_mapper.Map<Historic>(model));
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(Guid id)
        {

            return View(_mapper.Map<HistoricViewModel>(await _historic.GetById(id)));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(HistoricViewModel model)
        {
            

            await _historic.Remove(model.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
